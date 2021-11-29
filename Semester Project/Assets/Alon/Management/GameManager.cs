using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public AudioSource[] BackgroundMusicLayers;
    int MusicIndex = 0;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape)) { QuitGame(); }
    }



    public void BackgroundMusic() 
    {
        if (MusicIndex <= 3 && MusicIndex >= 0) 
        {
            BackgroundMusicLayers[MusicIndex].Play();

            if (MusicIndex != 0) 
            {
                BackgroundMusicLayers[MusicIndex].timeSamples = BackgroundMusicLayers[0].timeSamples;
            }

            MusicIndex++;
        }
    }





    public void QuitGame() 
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
        else { Application.Quit(); }
    }




}
