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

    public Slider SelectedSlider;
    public int MusicVolStart;
    public int SfxVolStart;

    //GameObject myEventSystem;




    //Controls PlayerContSys;

    // Start is called before the first frame update
    void Start()
    {
        //myEventSystem = GameObject.Find("EventSystem");
        ControllerHandler();

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

        //clean buttons
        for (int x = 0; x < Buttons.Length; x++) { Buttons[x] = null; }


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
        SelectedBtn = Buttons[index];

        if (InputScheme.currentControlScheme == "Gamepad") { ControllerUIChanger(); }
        
    }

    public void ControllerNextBtn(InputAction.CallbackContext NxtContext) 
    {
        //myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
        if (NxtContext.started) 
        {
            if (index < Length-1) { SelectedBtn = Buttons[index + 1]; index++; ControllerUIChanger(); }
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
        Debug.Log("Quite");
        Application.Quit(); 
    }


    void InitializeVolume() 
    {
        
    }

}
