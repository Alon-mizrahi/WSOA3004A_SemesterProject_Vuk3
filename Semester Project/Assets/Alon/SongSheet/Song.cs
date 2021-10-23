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

        if (Songbook.GetComponent<SongBook>().Songlist.Length == 1) 
        {
            Songbook.GetComponent<SongBook>().ActivePage = 1;
        }
        else if (Songbook.GetComponent<SongBook>().Songlist.Length == 2)
        {
            Songbook.GetComponent<SongBook>().ActivePage = 1;
        }
        else if (Songbook.GetComponent<SongBook>().Songlist.Length == 3)
        {
            Songbook.GetComponent<SongBook>().ActivePage = 2;
        }
        else if (Songbook.GetComponent<SongBook>().Songlist.Length == 4)
        {
            Songbook.GetComponent<SongBook>().ActivePage = 2;
        }
        else if (Songbook.GetComponent<SongBook>().Songlist.Length == 5)
        {
            Songbook.GetComponent<SongBook>().ActivePage = 3;
        }
        else if (Songbook.GetComponent<SongBook>().Songlist.Length == 6)
        {
            Songbook.GetComponent<SongBook>().ActivePage = 3;
        }

        Songbook.GetComponent<SongBook>().ChangePage();

        gameObject.SetActive(false);

    }
}
