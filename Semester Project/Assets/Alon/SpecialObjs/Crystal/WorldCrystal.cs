using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCrystal : MonoBehaviour
{
    public AudioClip flute1, flute2, flute3, flute4;
    public AudioClip FailSound;
    public AudioSource AS;

    public string Notes;


    public GameObject Particals1, Particals2, Particals3;
    SpriteRenderer Crystal;

    AudioClip[] SoundOrder = new AudioClip[12];

    //int SongIndex = 0;

    public GameObject Player;

    public int LayerNumber = 1;

    public int NoteBarCount = 1;

    public int count = 0;

    public bool Correct = false;

    BackgroundMusic MusicScript;

    GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        Crystal = gameObject.GetComponent<SpriteRenderer>();
        //StopCoroutine("StartCall");
        for (int i = 0; i < Notes.Length; i++)
        {
            if (Notes[i] == '1') { SoundOrder[i] = flute1; }
            else if (Notes[i] == '2') { SoundOrder[i] = flute2; }
            else if (Notes[i] == '3') { SoundOrder[i] = flute3; }
            else if (Notes[i] == '4') { SoundOrder[i] = flute4; }
        }

        MusicScript = GameObject.FindGameObjectWithTag("BackGroundMusic").GetComponent<BackgroundMusic>();
        GM = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && other.GetType() == typeof(BoxCollider2D)) 
        {
            Player.GetComponent<SongDetection>().CurrentCrystal = gameObject;
            StartCoroutine("StartCall"); Player.GetComponent<SongDetection>().ClearSong();

            MusicScript.AS.volume = 0.6f;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && other.GetType() == typeof(BoxCollider2D)) 
        { 
            StopCoroutine("StartCall");
            Particals1.SetActive(false);
            Particals2.SetActive(false);
            Particals3.SetActive(false);
            Crystal.color = Color.white;
            Player.GetComponent<SongDetection>().CurrentCrystal = null;

            MusicScript.AS.volume = 0.8f;
        }
    }

    IEnumerator StartCall()
    {
        Debug.Log("Started Call");

        for (int x = 0; x < 3 * LayerNumber; x++) //3,6,9,12
        {
            AS.clip = SoundOrder[x]; //012 //345 //678 //91011
            AS.Play();

            if (Notes[x] == '1') { Crystal.color = Color.red; }//red
            else if (Notes[x] == '2') { Crystal.color = Color.yellow; }//yellow
            else if (Notes[x] == '3') { Crystal.color = Color.blue; }//blue
            else if (Notes[x] == '4') { Crystal.color = Color.green; }//green


            yield return new WaitForSeconds(0.8f);
            //AS.Stop();
        }

        //call another func to time, if time exceded restart coroutine

        count = 0;
        NoteBarCount = 1;
        StartCoroutine("Timer");
        //yield return new WaitUntil(PlayerResponse); //calls function every frame and waits until it returns true

        yield return new WaitUntil(()=>Correct);
        //PlayerResponse = false;
        StopCoroutine("Timer");

        Debug.Log("RESPONDED");
        Correct = false;
        LayerNumber++;


        yield return new WaitForSeconds(1.5f);
        Player.GetComponent<SongDetection>().ClearSong();


        if (LayerNumber - 1 == 1) { Particals1.SetActive(true); }
        else if (LayerNumber - 1 == 2) { Particals2.SetActive(true); }
        else if (LayerNumber - 1 == 3) { Particals3.SetActive(true); }



        if (LayerNumber >= 5)// Finished
        {
            Debug.Log("FINISHED CRYSTAL");

            StopCoroutine("StartCall");

            //Change Scene here call something in a game manager script
            gameObject.GetComponent<BoxCollider2D>().enabled = false;

            //MusicScript.PlayMusic();

            StartCoroutine(GM.LoadNextScene());
            
        }
        else { StartCoroutine("StartCall"); }

    }


    public void PlayerResponse()
    {
        //count = 0;

        if (NoteBarCount == 1)
        {
            for (int x = 0; x < Player.GetComponent<SongDetection>().CurrentSong.Length; x++)
            {
                if (Player.GetComponent<SongDetection>().CurrentSong[x] == Notes[x])
                {
                    count++;
                }
                else { Debug.Log("F1"); StartCoroutine("FailedSong"); }
            }
            
            
            if (LayerNumber == 1 && count == 3) { NoteBarCount = 1; Correct = true; return; }
            else if (LayerNumber == 2 && count == 9)
            {
                if (NoteBarCount == 1) { Correct = true; return; }
            }

            if (LayerNumber >= 3 && Player.GetComponent<SongDetection>().CurrentSong.Length == 6) { NoteBarCount++; Debug.Log("INCREAE NOTE BAR "+NoteBarCount); }


        }

        else if (NoteBarCount == 2 && LayerNumber >= 3)
        {
            for (int x = 0; x < Player.GetComponent<SongDetection>().CurrentSong.Length; x++)
            {
                Debug.Log("NOTES: " + Player.GetComponent<SongDetection>().CurrentSong[x]+ " " + Notes[x + 6]);

                if (Player.GetComponent<SongDetection>().CurrentSong[x] == Notes[x + 6]) // x 0,1,2,3,4,5 //Notes 6,7,8,9,10,11
                {
                    count++;
                }
                else { Debug.Log("F2"); StartCoroutine("FailedSong"); }
            }
        }



        if (LayerNumber == 3 && count == 12) { Correct = true; }
        else if (LayerNumber == 4 && count == 18) { Correct = true; }



        //NoteBarCount = 1;
        //Correct = false;
    }



    IEnumerator Timer()
    {
        yield return new WaitForSeconds(30f);
        StopCoroutine("StartCall");
        StartCoroutine("FailedSong");
    }


    IEnumerator FailedSong()
    {
        //play some fail audio here
        AS.clip = FailSound;
        AS.Play();

        Correct = false;
        Particals1.SetActive(false);
        Particals2.SetActive(false);
        Particals3.SetActive(false);
        Crystal.color = Color.white;

        Player.GetComponent<Player>().MusicBlock = true;
        Debug.Log("FAILED");
        StopCoroutine("StartCall");
        NoteBarCount = 1;
        LayerNumber = 1;
        Player.GetComponent<SongDetection>().ClearSong();
        yield return new WaitForSeconds(1f);
        StartCoroutine("StartCall");
        Player.GetComponent<Player>().MusicBlock = false;
    }
}
