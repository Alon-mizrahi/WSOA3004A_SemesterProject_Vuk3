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

    // Start is called before the first frame update
    void Start()
    {
        SongBook = GameObject.Find("SongBook").GetComponent<SongBook>();
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

    void ClearSong()
    {
        IdleTimer = MaxIdleTime;
        CurrentSong = "";
        Debug.Log("song cleared");

        for (int i = 1; i <= 6; i++) 
        {
            NotesUI.transform.Find("Note"+i).GetComponent<Image>().color = Color.white;
        }

    }

    public void GetNote(string Key) 
    {
        Image Note = NotesUI.transform.Find("Note1").GetComponent<Image>();
        if (CurrentSong.Length == 1-1) { Note = NotesUI.transform.Find("Note1").GetComponent<Image>(); }
        else if (CurrentSong.Length == 2-1) { Note = NotesUI.transform.Find("Note2").GetComponent<Image>(); }
        else if (CurrentSong.Length == 3-1) { Note = NotesUI.transform.Find("Note3").GetComponent<Image>(); }
        else if (CurrentSong.Length == 4-1) { Note = NotesUI.transform.Find("Note4").GetComponent<Image>(); }
        else if (CurrentSong.Length == 5-1) { Note = NotesUI.transform.Find("Note5").GetComponent<Image>(); }
        else if (CurrentSong.Length == 6-1) { Note = NotesUI.transform.Find("Note6").GetComponent<Image>(); }




        NotesUI.SetActive(true);
        if (Key == "Up") 
        {
            CurrentSong += "1";//whatever note this will be
            IdleTimer = MaxIdleTime; //only if input detected
            Debug.Log("Song: " + CurrentSong);
            Note.color = Color.red;
        }
        else if (Key == "Down")
        {
            CurrentSong += "2";//whatever note this will be
            IdleTimer = MaxIdleTime; //only if input detected
            Debug.Log("Song: " + CurrentSong);
            Note.color = Color.blue;
        }
        else if (Key == "Left")
        {
            CurrentSong += "3";//whatever note this will be
            IdleTimer = MaxIdleTime; //only if input detected
            Debug.Log("Song: " + CurrentSong);
            Note.color = Color.green;
        }
        else if (Key == "Right")
        {
            CurrentSong += "4";//whatever note this will be
            IdleTimer = MaxIdleTime; //only if input detected
            Debug.Log("Song: " + CurrentSong);
            Note.color = Color.yellow;
        }


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



}
