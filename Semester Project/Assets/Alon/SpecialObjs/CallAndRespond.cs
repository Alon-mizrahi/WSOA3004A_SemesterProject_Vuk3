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

    string Notes;

    AudioClip[] SoundOrder = new AudioClip[6];

    int SongIndex = 0;

    public GameObject Player;

    //public bool PlayerResponse = false;

    public int LayerNumber=1;
    // Start is called before the first frame update
    void Start()
    {
        Notes = gameObject.GetComponent<Song>().Notes;
        //StopCoroutine("StartCall");
        for (int i = 0; i < 6; i++) 
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
        if (other.gameObject.tag == "Player" && other.GetType() == typeof(BoxCollider2D)) { StopCoroutine("StartCall"); }
    }


    IEnumerator StartCall()
    {
        Debug.Log("Started Call");

        for (int x = 0; x <  2 * LayerNumber; x++) 
        {
            AS.clip = SoundOrder[SongIndex + x];
            AS.Play();
            yield return new WaitForSeconds(0.8f);
            //AS.Stop();
        }

        //call another func to time, if time exceded restart coroutine

        yield return new WaitUntil(PlayerResponse); //calls function every frame and waits until it returns true
        //PlayerResponse = false;
        Debug.Log("RESPONDED");


        LayerNumber++;


        yield return new WaitForSeconds(1.5f);
        Player.GetComponent<SongDetection>().ClearSong();


        if (LayerNumber >= 4)// add to song book
        { 
            StopCoroutine("StartCall");
            gameObject.GetComponent<Song>().AddtoSongBook();
        }
        else { StartCoroutine("StartCall"); }
        
    }
    public bool PlayerResponse() 
    {
            int count = 0;
            for (int x = 0; x < Player.GetComponent<SongDetection>().CurrentSong.Length; x++) 
            {
                if (Player.GetComponent<SongDetection>().CurrentSong[x] == Notes[x])
                {
                    //return true;
                    count++;
                }
                else { StartCoroutine("FailedSong"); return false; }
                if (LayerNumber == 1 && count == 2 ) { return true; }
                else if(LayerNumber == 2 && count == 4) { return true; }
                else if (LayerNumber == 3 && count == 6) { return true; }
            }
            return false;
    }

    IEnumerator FailedSong() 
    {
        //play some fail audio here
        Player.GetComponent<Player>().MusicBlock = true;
        Debug.Log("FAILED"); 
        StopCoroutine("StartCall");
        LayerNumber = 1;
        Player.GetComponent<SongDetection>().ClearSong();
        yield return new WaitForSeconds(1f);
        StartCoroutine("StartCall");
        Player.GetComponent<Player>().MusicBlock = false;
    }
}
