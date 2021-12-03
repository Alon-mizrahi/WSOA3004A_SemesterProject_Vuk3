using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HoldToSkip : MonoBehaviour
{
    public float MaxTime =3f;
    float timeLeft;

    public bool Holding = false;

    public Image FadeOut;

    public Image TimerBar;

    public Image GpadImage;

    public Text Skiptxt;

    public PlayerInput InputMap;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = MaxTime;
    }

    // Update is called once per frame
    void Update()
    {

        CheckScheme();




        if (Holding)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                TimerBar.fillAmount = timeLeft / MaxTime;
            }
            else 
            {
                StartCoroutine("OutroFade");
            }


            //MaxTime = Time.time;


        }
        else { timeLeft = MaxTime; TimerBar.fillAmount = 0;  }

        //if(Timer)


    }


    void CheckScheme() 
    {
        //Debug.Log(InputMap.currentControlScheme);

        if (InputMap.currentControlScheme == "KeyboardMouse")
        {
            GpadImage.enabled = false;
            Skiptxt.text = "Hold Space to Skip";

        }
        else if (InputMap.currentControlScheme == "Gamepad") 
        {
            GpadImage.enabled = true;
            Skiptxt.text = "Hold to Skip";
        }
    
    }



    public void HoldSikp(InputAction.CallbackContext HoldContext) 
    {


        if (HoldContext.started) 
        {
            Holding = true;
        }

        if (HoldContext.canceled)
        {
            Holding = false;
        }


    }



    IEnumerator OutroFade()
    {
        Holding = false;
        float Fade = 0f;
        for (int i = 0; i <= 200; i++)
        {
            yield return new WaitForSeconds(0.005f);
            FadeOut.color = new Color(FadeOut.color.r, FadeOut.color.g, FadeOut.color.b, Fade);

            Fade += 0.005f;
        }

        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }


}
