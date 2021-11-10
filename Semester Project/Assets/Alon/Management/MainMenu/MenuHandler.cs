using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MenuHandler : MonoBehaviour
{

    public GameObject Screen1, Screen2, Screen3;

    public Button[] Buttons = new Button[5];

    public PlayerInput InputScheme;

    public Button SelectedBtn;

    public int index = 0;

    public int Length = 0;

    GameObject myEventSystem;


    //Controls PlayerContSys;

    // Start is called before the first frame update
    void Start()
    {
        myEventSystem = GameObject.Find("EventSystem");
        ControllerHandler();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { Quite(); }
    }

    void ControllerHandler() 
    {
        Debug.Log(InputScheme.currentControlScheme);
        Debug.Log("HANDLER");
        Length=0;


        //clean buttons
        for (int x = 0; x < Buttons.Length; x++) { Buttons[x] = null; }


        if (Screen1.activeSelf) 
        {
            for (index = 0; index < Screen1.transform.childCount; index++) 
            {
                if (Screen1.transform.GetChild(index).GetComponent<Button>() != null) 
                {
                    Buttons[index] = Screen1.transform.GetChild(index).GetComponent<Button>();
                }
            }
            for (int i = 0; i < Screen1.transform.childCount; i++) 
            {
                if (Screen1.transform.GetChild(i).GetComponent<Button>() != null) { Length++; }
            }
        }
        else if (Screen2.activeSelf)
        {
            for (index = 0; index < Screen2.transform.childCount; index++)
            {
                if (Screen2.transform.GetChild(index).GetComponent<Button>() != null)
                {
                    Buttons[index] = Screen2.transform.GetChild(index).GetComponent<Button>();
                }
            }
            for (int i = 0; i < Screen2.transform.childCount; i++)
            {
                if (Screen2.transform.GetChild(i).GetComponent<Button>() != null) { Length++; }
            }
        }
        else if (Screen3.activeSelf)
        {
            for (index = 0; index < Screen3.transform.childCount; index++)
            {
                if (Screen3.transform.GetChild(index).GetComponent<Button>() != null)
                {
                    Buttons[index] = Screen3.transform.GetChild(index).GetComponent<Button>();
                }
            }
            for (int i = 0; i < Screen3.transform.childCount; i++)
            {
                if (Screen3.transform.GetChild(i).GetComponent<Button>() != null) { Length++; }
            }
        }

        index = 0;
        SelectedBtn = Buttons[index];

        ControllerUIChanger();

    }

    public void ControllerNextBtn(InputAction.CallbackContext NxtContext) 
    {
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
        if (NxtContext.started) 
        {
            if (index < Length-1) { SelectedBtn = Buttons[index + 1]; index++; ControllerUIChanger(); }
        }
    }

    public void ControllerPrevBtn(InputAction.CallbackContext PrevContext)
    {
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
        if (PrevContext.started) 
        { 
            if (index > 0) { SelectedBtn = Buttons[index - 1]; index--; ControllerUIChanger(); }
        }
    }
    public void ControllerSelectBtn(InputAction.CallbackContext SelectContext)
    {
        if (SelectContext.started) 
        {
            SelectedBtn.Select();
        }
        if (SelectContext.performed) { SelectedBtn.Select(); }
    }

    void ControllerUIChanger() 
    {
        for (int i = 0; i < Buttons.Length; i++) 
        {
            if (Buttons[i] != null) { Buttons[i].gameObject.GetComponent<Outline>().enabled = false; }        
        }
        SelectedBtn.gameObject.GetComponent<Outline>().enabled = true;
    }





    public void Settings() 
    {
        ChangeScreen("Settings");
    }

    public void Credits()
    {
        ChangeScreen("Credits");
    }

    public void Back() 
    {
        ChangeScreen("Main");
    }

    void ChangeScreen(string GoToScreen) 
    {
        if (GoToScreen == "Settings") 
        {
            Screen1.SetActive(false);
            Screen2.SetActive(true);
            Screen3.SetActive(false);
        }
        else if (GoToScreen == "Credits")
        {
            Screen1.SetActive(false);
            Screen2.SetActive(false);
            Screen3.SetActive(true);
        }
        else if (GoToScreen == "Main")
        {
            Screen1.SetActive(true);
            Screen2.SetActive(false);
            Screen3.SetActive(false);
        }
        if (InputScheme.currentControlScheme == "Gamepad") { ControllerHandler(); }
    }

    public void Play() 
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    void Quite() 
    { 
        Application.Quit(); 
    }

}
