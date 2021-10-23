using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Song : MonoBehaviour
{

    public string SongTitle;
    public string Notes;
    public GameObject Songbook;

    GameObject Player;

    void Start() 
    {
        gameObject.name = "Learning Area "+SongTitle;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void AddtoSongBook()
    {
        Debug.Log("HERE");
        Songbook.GetComponent<SongBook>().AddSong(gameObject.GetComponent<Song>());
        Songbook.GetComponent<SongBook>().ToggleBook();
        Player.GetComponent<PlayerInput>().SwitchCurrentActionMap("UI");

        int count = 0;
        for (int i = 0; i < Songbook.GetComponent<SongBook>().Songlist.Length; i++) 
        {
            if (Songbook.GetComponent<SongBook>().Songlist[i] != null) 
            {
                count++;
            }
        }

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

        gameObject.SetActive(false);

    }
}
