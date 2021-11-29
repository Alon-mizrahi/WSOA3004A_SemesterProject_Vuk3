using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    AudioSource AS;
    public AudioClip[] Layer;
    public int LayerIndex = 0;

    public float CurrentTime = 0f;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        AS = gameObject.GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        if (LayerIndex != 0) 
        {
            CurrentTime = AS.time;
        }

        AS.clip = Layer[LayerIndex];
        AS.time = CurrentTime;
        AS.Play();
        LayerIndex++;
    }



}
