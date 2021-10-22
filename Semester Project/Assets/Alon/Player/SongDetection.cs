using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongDetection : MonoBehaviour
{
    //song is going to be a string of notes

    public string CurrentSong = "";

    public float MaxIdleTime = 5f;
    public float IdleTimer;
    public GameObject NotesUI;

    GetInteractables GetInteractablesScript;

    SongBook SongBook;

    public SpriteRenderer RangeUI;
    bool isRangeUIOn = false;

    // Start is called before the first frame update
    void Start()
    {
        SongBook = GameObject.Find("SongBookBackground").GetComponent<SongBook>();
        SongBook.gameObject.SetActive(false);
        IdleTimer = MaxIdleTime;
        GetInteractablesScript = gameObject.GetComponent<GetInteractables>();
        NotesUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //GetNote();
        IdleSong();
    }

    void IdleSong() 
    {
        if (IdleTimer > 0 && CurrentSong != "")
        {
            IdleTimer -= Time.deltaTime;

        }
        else if(IdleTimer <= 0)
        {
            ClearSong();
            NotesUI.SetActive(false);
        }

        
    }

    public void ClearSong()
    {
        IdleTimer = MaxIdleTime;
        CurrentSong = "";
        Debug.Log("song cleared");

        StartCoroutine("PauseBeforeClear");

        

    }

    IEnumerator PauseBeforeClear() 
    {
        yield return new WaitForSeconds(0.8f);
        for (int i = 1; i <= 6; i++)
        {
            yield return new WaitForSeconds(0.3f);
            NotesUI.transform.Find("Note" + i).GetComponent<Image>().color = Color.white;
            NotesUI.transform.Find("Note" + i).transform.rotation = Quaternion.identity;
        }
    }

    public void GetNote(string Key) 
    {
        StopCoroutine("PauseBeforeClear");

        Image Note = NotesUI.transform.Find("Note1").GetComponent<Image>();
        if (CurrentSong.Length == 1-1) { Note = NotesUI.transform.Find("Note1").GetComponent<Image>(); }
        else if (CurrentSong.Length == 2-1) { Note = NotesUI.transform.Find("Note2").GetComponent<Image>(); }
        else if (CurrentSong.Length == 3-1) { Note = NotesUI.transform.Find("Note3").GetComponent<Image>(); }
        else if (CurrentSong.Length == 4-1) { Note = NotesUI.transform.Find("Note4").GetComponent<Image>(); }
        else if (CurrentSong.Length == 5-1) { Note = NotesUI.transform.Find("Note5").GetComponent<Image>(); }
        else if (CurrentSong.Length == 6-1) { Note = NotesUI.transform.Find("Note6").GetComponent<Image>(); }

        if (CurrentSong.Length == 0)
        {
            for (int i = 1; i <= 6; i++)
            {
                NotesUI.transform.Find("Note" + i).GetComponent<Image>().color = Color.white;
                NotesUI.transform.Find("Note" + i).transform.rotation = Quaternion.identity;
            }
        }


        NotesUI.SetActive(true);
        if (Key == "Up") 
        {
            CurrentSong += "1";//whatever note this will be
            IdleTimer = MaxIdleTime; //only if input detected
            Debug.Log("Song: " + CurrentSong);
            Note.color = Color.red;
            Note.transform.Rotate(Vector3.forward, 0f);
        }
        else if (Key == "Down")
        {
            CurrentSong += "3";//whatever note this will be
            IdleTimer = MaxIdleTime; //only if input detected
            Debug.Log("Song: " + CurrentSong);
            Note.color = Color.blue;
            Note.transform.Rotate(Vector3.forward, 180f);
        }
        else if (Key == "Left")
        {
            CurrentSong += "4";//whatever note this will be
            IdleTimer = MaxIdleTime; //only if input detected
            Debug.Log("Song: " + CurrentSong);
            Note.color = Color.green;
            Note.transform.Rotate(Vector3.forward, 90f);
        }
        else if (Key == "Right")
        {
            CurrentSong += "2";//whatever note this will be
            IdleTimer = MaxIdleTime; //only if input detected
            Debug.Log("Song: " + CurrentSong);
            Note.color = Color.yellow;
            Note.transform.Rotate(Vector3.forward, -90f);
        }

        if (isRangeUIOn == true) { StopCoroutine("RangeIndicator"); isRangeUIOn = false; }
        StartCoroutine("RangeIndicator");

        if (CurrentSong.Length == 6) 
        {
            CheckSong();
            ClearSong();
        }
        
    }

    void CheckSong() 
    {
        for (int i = 0; i < SongBook.Songlist.Length; i++) 
        {
            if (SongBook.Songlist[i] != null) 
            {
                if (CurrentSong == SongBook.Songlist[i].Notes) 
                {
                    Debug.Log("Played " + SongBook.Songlist[i].SongTitle);
                    GetInteractablesScript.SongPlayed(SongBook.Songlist[i].SongTitle);
                    break;
                }
            }

        }
    }


    IEnumerator RangeIndicator() //Called when playing a note
    {
        //turn indicator on
        RangeUI.enabled = true;
        isRangeUIOn = true;
        yield return new WaitForSeconds(4f);
        //turn indicator off
        RangeUI.enabled = false;
    }


}
