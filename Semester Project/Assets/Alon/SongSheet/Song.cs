using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Song : MonoBehaviour
{

    public string SongTitle;
    public string Notes;
    public GameObject Songbook;

    void Start() 
    {
        gameObject.name = "Learning Area "+SongTitle;
    }

    public void AddtoSongBook()
    {
        Debug.Log("HERE");
        Songbook.GetComponent<SongBook>().AddSong(gameObject.GetComponent<Song>());
        gameObject.SetActive(false);
    }
}
