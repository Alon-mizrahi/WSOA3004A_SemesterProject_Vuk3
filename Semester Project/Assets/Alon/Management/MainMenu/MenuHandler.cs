using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MenuHandler : MonoBehaviour
{

    public GameObject Screen1, Screen2, Screen3;

    Button[] Buttons = new Button[5];

    public PlayerInput InputScheme;

    public Button SelectedBtn;

    int index = 0;
    int Length = 0;

    //sliders
    public Slider SelectedSlider;
    public Slider[] Sliders = new Slider[5];
    public int MusicVol = 70;
    public int SfxVol = 80;
    int SIndex = 0;
    int SLength = 0;


    // Start is called before the first frame update
    void Start()
    {
        //myEventSystem = GameObject.Find("EventSystem");
        ControllerHandler();
        //InitializeVolume();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ControllerHandler()
    {
        //Debug.Log(InputScheme.currentControlScheme);
        //Debug.Log("HANDLER");
        Length = 0;
        index = 0;
        SIndex = 0;
        SLength = 0;
        //clean buttons
        for (int x = 0; x < Buttons.Length; x++) { Buttons[x] = null; }
        for (int x = 0; x < Sliders.Length; x++) { Sliders[x] = null; }


        if (Screen1.activeSelf)
        {
            for (int j = 0; j < Screen1.transform.childCount; j++)
            {
                if (Screen1.transform.GetChild(j).GetComponent<Button>() != null)
                {
                    Buttons[index] = Screen1.transform.GetChild(j).GetComponent<Button>();
                    index++;
                    Length++;
                }
            }
        }
        else if (Screen2.activeSelf)
        {
            for (int j = 0; j < Screen2.transform.childCount; j++)
            {
                if (Screen2.transform.GetChild(j).GetComponent<Button>() != null)
                {
                    Buttons[index] = Screen2.transform.GetChild(j).GetComponent<Button>();
                    index++;
                    Length++;
                }
                if (Screen2.transform.GetChild(j).GetComponent<Slider>() != null)
                {
                    Sliders[SIndex] = Screen2.transform.GetChild(j).GetComponent<Slider>();
                    SIndex++;
                    SLength++;
                }
            }
        }
        else if (Screen3.activeSelf)
        {
            for (int j = 0; j < Screen3.transform.childCount; j++)
            {
                if (Screen3.transform.GetChild(j).GetComponent<Button>() != null)
                {
                    Buttons[index] = Screen3.transform.GetChild(j).GetComponent<Button>();
                    index++;
                    Length++;
                }
            }
        }

        index = 0;
        SIndex = 0;
        SelectedBtn = Buttons[index];
        SelectedSlider = Sliders[SIndex];
        if (InputScheme.currentControlScheme == "Gamepad") { ControllerUIChanger(); }

    }

    public void ControllerNextBtn(InputAction.CallbackContext NxtContext)
    {
        //myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
        if (NxtContext.started)
        {
            if (SIndex < SLength - 1) { SelectedSlider = Sliders[SIndex + 1]; SIndex++; }
            else if (index < Length - 1) { SelectedBtn = Buttons[index + 1]; index++; ControllerUIChanger(); }
        }
    }

    public void ControllerPrevBtn(InputAction.CallbackContext PrevContext)
    {
        //myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
        if (PrevContext.started)
        {
            if (index > 0) { SelectedBtn = Buttons[index - 1]; index--; ControllerUIChanger(); }
        }
    }

    public void ControllerSelectBtn(InputAction.CallbackContext SelectContext)
    {
        if (SelectContext.started)
        {
            SelectedBtn.onClick.Invoke();
        }
    }

    void ControllerUIChanger()
    {
        for (int i = 0; i < Buttons.Length; i++)
        {
            if (Buttons[i] != null) { Buttons[i].gameObject.GetComponent<Outline>().enabled = false; }
        }
        SelectedBtn.gameObject.GetComponent<Outline>().enabled = true;
    }


    public void Play()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void Quite()
    {
        Application.Quit();
    }



    public void SFXValChange()
    {
        
    }

    public void MusicValChange()
    {
        //MusicVol = Mu
    }


}
