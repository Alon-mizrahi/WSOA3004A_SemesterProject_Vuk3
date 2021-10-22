using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallAndRespond : MonoBehaviour
{
    public AudioClip flute1;
    public AudioClip flute2;
    public AudioClip flute3;
    public AudioClip flute4;
    public AudioSource AS;

    string SongNotes;
    string SongName;
    AudioClip[] SoundOrder = new AudioClip[6];

    public bool inRage = false;
    bool completed = false;
    int SongIndex = 0;

    public GameObject Player;
    GameObject SongBook;
    public int LayerNumber=1;
    // Start is called before the first frame update
    void Start()
    {
        SongBook = GameObject.Find("SongBook");
        inRage = false;
        SongName = gameObject.GetComponent<Song>().SongTitle;
        SongNotes = gameObject.GetComponent<Song>().Notes;

        //StopCoroutine("StartCall");
        for (int i = 0; i < 6; i++) 
        {
            if (SongNotes[i] == '1') { SoundOrder[i] = flute1; }
            else if (SongNotes[i] == '2') { SoundOrder[i] = flute2; }
            else if (SongNotes[i] == '3') { SoundOrder[i] = flute3; }
            else if (SongNotes[i] == '4') { SoundOrder[i] = flute4; }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && completed == false) { inRage = true; StartCoroutine("StartCall"); Player.GetComponent<SongDetection>().ClearSong(); }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") { inRage = false; StopCoroutine("StartCall"); }
    }


    IEnumerator StartCall()
    {
        Debug.Log("Started Call");

        for (int x = 0; x <  2 * LayerNumber; x++) 
        {
            AS.clip = SoundOrder[SongIndex + x];
            AS.Play();
            yield return new WaitForSeconds(0.5f);
            //AS.Stop();
        }

        yield return new WaitForSeconds(4f);

        for (int y = 1; y < 4; y++) 
        {
            if (LayerNumber == y)
            {
                Debug.Log("Y in for loop: "+ y);
                if (Player.GetComponent<SongDetection>().CurrentSong.Length == 2*y)
                {
                    Debug.Log("First statement of checker");
                    if (CheckResponse()) { Debug.Log("Checked respons is true"); LayerNumber++; }
                    else { LayerNumber = 1; }
                    break;
                }
            }
        }


        yield return new WaitForSeconds(2f);
        Player.GetComponent<SongDetection>().ClearSong();

        if (LayerNumber >= 4)// add to song book
        { 
            StopCoroutine("StartCall");
            completed = true;
            //SongBook.GetComponent<SongBook>().AddSong(gameObject.GetComponent<Song>());
        }
        else { StartCoroutine("StartCall"); }
        
    }

    bool CheckResponse() 
    {
        if (inRage == true) 
        {
            for (int j = 0; j < 2*LayerNumber; j++) //LN 2, 4, 6
            {
                    if (LayerNumber == 1 && j == 1) //notes 0, 1
                    {
                        if (Player.GetComponent<SongDetection>().CurrentSong[j] == SongNotes[j] && Player.GetComponent<SongDetection>().CurrentSong[j-1] == SongNotes[j-1]) 
                        {
                            return true;
                        }
                    }
                    else if (LayerNumber == 2 && j ==3) //notes 0, 1, 2, 3
                    {
                        if (Player.GetComponent<SongDetection>().CurrentSong[j] == SongNotes[j] && Player.GetComponent<SongDetection>().CurrentSong[j - 1] == SongNotes[j - 1] && Player.GetComponent<SongDetection>().CurrentSong[j - 2] == SongNotes[j - 2] && Player.GetComponent<SongDetection>().CurrentSong[j - 3] == SongNotes[j - 3])
                        {
                            return true;
                        }
                    } 
                    else if (LayerNumber == 3 && j == 5) //notes 0, 1, 2, 3, 4, 5
                    {
                        if (Player.GetComponent<SongDetection>().CurrentSong[j] == SongNotes[j] && Player.GetComponent<SongDetection>().CurrentSong[j - 1] == SongNotes[j - 1] && Player.GetComponent<SongDetection>().CurrentSong[j - 2] == SongNotes[j - 2] && Player.GetComponent<SongDetection>().CurrentSong[j - 3] == SongNotes[j - 3] && Player.GetComponent<SongDetection>().CurrentSong[j - 4] == SongNotes[j - 4] && Player.GetComponent<SongDetection>().CurrentSong[j - 5] == SongNotes[j - 5])
                        {
                            return true;
                        }
                    }     
            }
           return false;
        }
        return false;
    }

}
