using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongList : MonoBehaviour
{
    public Song[] ConstSongList;


    void Awake() 
    {
        DontDestroyOnLoad(transform.gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
