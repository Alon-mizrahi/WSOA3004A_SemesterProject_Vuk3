using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Song : MonoBehaviour
{

    public string SongTitle;
    public string Notes;
    public GameObject Songbook;

    public GameObject NewSongNotif;


    SongList GlobalSongs;


    GameObject Player;

    public GameObject[] TargetObjs = new GameObject[5];

    void Start() 
    {
        gameObject.name = "Learning Area "+SongTitle;
        Player = GameObject.FindGameObjectWithTag("Player");

        GlobalSongs = GameObject.FindGameObjectWithTag("SongList").GetComponent<SongList>();

    }

    public void AddtoSongBook()
    {
        ActivateSong();

        //open songbook and switch input map
        Debug.Log("HERE");
        Songbook.GetComponent<SongBook>().AddSong(gameObject.GetComponent<Song>());

        GlobalSongs.AddtoList(this);
        //Songbook.GetComponent<SongBook>().ToggleBook();
        //Player.GetComponent<PlayerInput>().SwitchCurrentActionMap("UI");

        NewSongNotif.SetActive(true);
        //StartCoroutine(NewSongNotif.GetComponent<NotifFlash>().Flash());
        //foreach (Transform Child in NewSongNotif.transform) 
        //{
        //    StartCoroutine(Child.gameObject.GetComponent<NotifFlash>().Flash());
        //}


        Songbook.GetComponent<SongBook>().NewSong = true;

        //open songbook
        
        /*
        int count = 0;
        for (int i = 0; i < Songbook.GetComponent<SongBook>().Songlist.Length; i++) 
        {
            if (Songbook.GetComponent<SongBook>().Songlist[i] != null) 
            {
                count++;
            }
        }

        //go to right page
        if (count ==1 || count == 2) 
        {
            Songbook.GetComponent<SongBook>().ActivePage = 1;
        }
        else if (count == 3 || count == 4)
        {
            Songbook.GetComponent<SongBook>().ActivePage = 2;
        }
        else if (count == 5 || count == 6)
        {
            Songbook.GetComponent<SongBook>().ActivePage = 3;
        }

        Songbook.GetComponent<SongBook>().ChangePage();

        */

        gameObject.SetActive(false);

    }

    void ActivateSong() 
    {
        for (int i = 0; i < TargetObjs.Length; i++) 
        {
            if (TargetObjs[i] != null)
            {
                TargetObjs[i].GetComponent<InteractableSongDetection>().SongCheck(SongTitle);
            }
        }
        
    }
}
