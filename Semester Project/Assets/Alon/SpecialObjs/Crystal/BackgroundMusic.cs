using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackgroundMusic : MonoBehaviour
{
    public AudioSource AS;
    public AudioClip[] Layer;
    public int LayerIndex = 0;

    public float CurrentTime = 0f;

    void Awake()
    {
        //DontDestroyOnLoad(transform.gameObject);
        AS = gameObject.GetComponent<AudioSource>();
    }


    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2) { AS.clip = Layer[0]; AS.Play(); }
        else if (SceneManager.GetActiveScene().buildIndex == 3) { AS.clip = Layer[1]; AS.Play(); }
        else if (SceneManager.GetActiveScene().buildIndex == 4) { AS.clip = Layer[2]; AS.Play(); }
        else if (SceneManager.GetActiveScene().buildIndex == 5) { AS.clip = Layer[3]; AS.Play(); }
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
