using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image FadeOut;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape)) { QuitGame(); }
    }




    public IEnumerator LoadNextScene()
    {
        float Fade = 0f;
        for (int i = 0; i <= 20; i++) 
        {
            yield return new WaitForSeconds(0.15f);
            FadeOut.color = new Color(FadeOut.color.r, FadeOut.color.g, FadeOut.color.b, Fade);

            Fade += 0.05f;
        }


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
