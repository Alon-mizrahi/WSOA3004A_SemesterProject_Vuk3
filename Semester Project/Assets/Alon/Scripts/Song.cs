using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Song : MonoBehaviour
{

    public string SongTitle;
    public string Notes;
    GameObject SongBook;

    void Start() 
    {
        gameObject.name = SongTitle;
        SongBook = GameObject.Find("SongBook");
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") 
        {
            //add to songbook
            //transform.SetParent(SongBook.transform);
            SongBook.GetComponent<SongBook>().AddSong(gameObject.GetComponent<Song>());

        }
    }
}
