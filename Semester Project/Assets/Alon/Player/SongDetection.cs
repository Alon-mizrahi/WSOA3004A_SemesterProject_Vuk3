using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongDetection : MonoBehaviour
{
    //song is going to be a string of notes

    public string CurrentSong = "";

    public float MaxIdleTime = 5f;
    public float IdleTimer;

    GetInteractables GetInteractablesScript;

    SongBook SongBook;

    // Start is called before the first frame update
    void Start()
    {
        SongBook = GameObject.Find("SongBook").GetComponent<SongBook>();
        IdleTimer = MaxIdleTime;
        GetInteractablesScript = gameObject.GetComponent<GetInteractables>();
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
        }

        
    }

    void ClearSong()
    {
        IdleTimer = MaxIdleTime;
        CurrentSong = "";
        Debug.Log("song cleared");
    }

    public void GetNote(string Key) 
    {
        if (Key == "Up") 
        {
            CurrentSong += "1";//whatever note this will be
            IdleTimer = MaxIdleTime; //only if input detected
            Debug.Log("Song: " + CurrentSong);
        }
        else if (Key == "Down")
        {
            CurrentSong += "2";//whatever note this will be
            IdleTimer = MaxIdleTime; //only if input detected
            Debug.Log("Song: " + CurrentSong);
        }
        else if (Key == "Left")
        {
            CurrentSong += "3";//whatever note this will be
            IdleTimer = MaxIdleTime; //only if input detected
            Debug.Log("Song: " + CurrentSong);
        }
        else if (Key == "Right")
        {
            CurrentSong += "4";//whatever note this will be
            IdleTimer = MaxIdleTime; //only if input detected
            Debug.Log("Song: " + CurrentSong);
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
