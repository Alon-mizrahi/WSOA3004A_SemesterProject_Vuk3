using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCrystal : MonoBehaviour
{
    public AudioClip flute1;
    public AudioClip flute2;
    public AudioClip flute3;
    public AudioClip flute4;
    public AudioSource AS;

    public string Notes;

    AudioClip[] SoundOrder = new AudioClip[12];

    //int SongIndex = 0;

    public GameObject Player;

    //public GameObject Obstacle;

    public int LayerNumber = 1;

    public int NoteBarCount = 1;

    public int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        //StopCoroutine("StartCall");
        for (int i = 0; i < Notes.Length; i++)
        {
            if (Notes[i] == '1') { SoundOrder[i] = flute1; }
            else if (Notes[i] == '2') { SoundOrder[i] = flute2; }
            else if (Notes[i] == '3') { SoundOrder[i] = flute3; }
            else if (Notes[i] == '4') { SoundOrder[i] = flute4; }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && other.GetType() == typeof(BoxCollider2D)) { StartCoroutine("StartCall"); Player.GetComponent<SongDetection>().ClearSong(); }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") { StopCoroutine("StartCall"); }
    }

    IEnumerator StartCall()
    {
        Debug.Log("Started Call");

        for (int x = 0; x < 3 * LayerNumber; x++) //3,6,9,12
        {
            AS.clip = SoundOrder[x]; //012 //345 //678 //91011
            AS.Play();
            yield return new WaitForSeconds(0.8f);
            //AS.Stop();
        }

        //call another func to time, if time exceded restart coroutine

        StartCoroutine("Timer");
        yield return new WaitUntil(PlayerResponse); //calls function every frame and waits until it returns true
        //PlayerResponse = false;
        StopCoroutine("Timer");

        Debug.Log("RESPONDED");

        LayerNumber++;


        yield return new WaitForSeconds(1.5f);
        Player.GetComponent<SongDetection>().ClearSong();


        if (LayerNumber >= 5)// add to song book
        {
            Debug.Log("FINISHED CRYSTAL");
            StopCoroutine("StartCall");

            //gameObject.GetComponent<Song>().AddtoSongBook();
        }
        else { StartCoroutine("StartCall"); }

    }

    public bool PlayerResponse()
    {
        // public int count = 0;
        //int 
        count = 0;

        //for (int j = 0; j < 2; j++) 
        //{
            if (NoteBarCount == 1)
            {
                for (int x = 0; x < Player.GetComponent<SongDetection>().CurrentSong.Length; x++)
                {
                    if (Player.GetComponent<SongDetection>().CurrentSong[x] == Notes[x])
                    {
                        count++;
                    }
                    else { Debug.Log("F1"); StartCoroutine("FailedSong"); return false; }
                }

            }
            else if (NoteBarCount == 2)
            {
                for (int x = 0; x < Player.GetComponent<SongDetection>().CurrentSong.Length; x++)
                {
                    if (Player.GetComponent<SongDetection>().CurrentSong[x] == Notes[x + 6]) // x 0,1,2,3,4,5 //Notes 6,7,8,9,10,11
                    {
                        count++;
                    }
                    else { Debug.Log("F2"); StartCoroutine("FailedSong"); return false; }
                }
            }

            //if (LayerNumber == 2 && count == 6) { NoteBarCount++; }

            if (LayerNumber == 1 && count == 3) { NoteBarCount = 1; return true; }
            else if (LayerNumber == 2 && count == 6) 
            {
                if (NoteBarCount == 1) { return true; }
                NoteBarCount++;
            }
            else if (LayerNumber == 3 && count == 9) { return true; }
            else if (LayerNumber == 4 && count == 12) { return true; }


        //}

        NoteBarCount = 1;
        return false;
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
