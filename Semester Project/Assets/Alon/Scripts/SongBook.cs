using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongBook : MonoBehaviour
{

    public Song[] Songlist;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddSong(Song song) //get children of gameobject component songs
    {
        Songlist[Songlist.Length] = song;
        
    }

    void SetUI() 
    {

    }

}
