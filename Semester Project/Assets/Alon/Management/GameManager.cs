using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public Image FadeOut;
    public SongBook SB;

    private void Awake()
    {
        SB.ToggleBook();
        SB.ToggleBook();
        StartCoroutine("IntroFade");

    }

    IEnumerator IntroFade() 
    {
        float Fade = 1f;
        for (int i = 200; i >= 0; i--)
        {
            yield return new WaitForSeconds(0.005f);
            FadeOut.color = new Color(FadeOut.color.r, FadeOut.color.g, FadeOut.color.b, Fade);

            Fade -= 0.005f;
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.O)) { StartCoroutine("LoadNextScene"); }
    }


    public void RestartLevel(InputAction.CallbackContext RestartContext) 
    {
        if (RestartContext.started) 
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }



    public IEnumerator LoadNextScene()
    {
        float Fade = 0f;
        for (int i = 0; i <= 200; i++) 
        {
            yield return new WaitForSeconds(0.005f);
            FadeOut.color = new Color(FadeOut.color.r, FadeOut.color.g, FadeOut.color.b, Fade);

            Fade += 0.005f;
        }

        yield return new WaitForSeconds(1f);

        int Index = SceneManager.GetActiveScene().buildIndex;
        Index++;
        SceneManager.LoadScene(Index, LoadSceneMode.Single);
        
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
