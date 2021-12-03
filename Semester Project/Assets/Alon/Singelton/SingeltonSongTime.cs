using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingeltonSongTime : MonoBehaviour
{
    private static SingeltonSongTime _instance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject.transform);

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    GameObject BackGroundMusic;
    public float Time=0;

    // Start is called before the first frame update
    void Start()
    {
        BackGroundMusic = GameObject.FindGameObjectWithTag("BackGroundMusic");

        if (BackGroundMusic != null) 
        {
            BackGroundMusic.GetComponent<BackgroundMusic>().AS.time = Time;
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        if (BackGroundMusic != null)
        {
            Time = BackGroundMusic.GetComponent<BackgroundMusic>().AS.time;
        }
    }
}
