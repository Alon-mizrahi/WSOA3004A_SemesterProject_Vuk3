using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    [SerializeField] VideoClip Video;
    public float TimeElapsed;
    public float TimeofVideo;

    private void Update()
    {
        TimeElapsed += Time.deltaTime;
        EndVideo();
    }

    public void EndVideo()
    {
        if(TimeElapsed >= TimeofVideo)
        {
            SceneManager.LoadScene(2);
        }
    }
}
