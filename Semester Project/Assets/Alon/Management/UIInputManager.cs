using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIInputManager : MonoBehaviour
{
    public PlayerInput InputMap;

    public string PrevScheme;

    public GameObject SongBook;

    //Top right corner UI arrows
    public GameObject ArrowUI;
    public GameObject NumUI;

    //SongBook Notification control
    public GameObject SBnotifGpad;
    public GameObject SBnotifMK;

    //Tutorial objects
    public GameObject TutorialHolder;

    //other ui changes

    private void Start()
    {
        PrevScheme = InputMap.currentControlScheme;

        ChangeCanvaseArrows();
        ChangeSongBookNotif();
        ChangeTutorialTxt();
        UpdateSongBookNotes();
    }



    // Update is called once per frame
    void Update()
    {
        if (PrevScheme != InputMap.currentControlScheme) 
        {
            ChangeCanvaseArrows(); //Top right corner arrows
            ChangeSongBookNotif(); //song book notif
            ChangeTutorialTxt(); // tutorial messages
            UpdateSongBookNotes(); // change song book notes

            PrevScheme = InputMap.currentControlScheme;
        }
    }

    void UpdateSongBookNotes() 
    {
        SongBook.GetComponent<SongBook>().ChangeUIScheme();
    }

    void ChangeCanvaseArrows() 
    {
        if (InputMap.currentControlScheme == "Gamepad") //player using xbox
        {
            if (ArrowUI.activeSelf == false) { ArrowUI.SetActive(true); }
            if (NumUI.activeSelf == true) { NumUI.SetActive(false); }
        }
        else if (InputMap.currentControlScheme == "") //player using PS
        {
            if (ArrowUI.activeSelf == false) { ArrowUI.SetActive(true); }
            if (NumUI.activeSelf == true) { NumUI.SetActive(false); }
        }
        else if (InputMap.currentControlScheme == "Keyboard&Mouse") //player using M and K
        {
            if (ArrowUI.activeSelf == true) { ArrowUI.SetActive(false); }
            if (NumUI.activeSelf == false) { NumUI.SetActive(true); }
        }
    }


    void ChangeSongBookNotif() 
    {
        if (InputMap.currentControlScheme == "Gamepad") //player using xbox
        {
            if (SBnotifGpad.activeSelf == false) { SBnotifGpad.SetActive(true); }
            if (SBnotifMK.activeSelf == true) { SBnotifMK.SetActive(false); }
        }
        else if (InputMap.currentControlScheme == "") //player using PS
        {
            if (SBnotifGpad.activeSelf == false) { SBnotifGpad.SetActive(true); }
            if (SBnotifMK.activeSelf == true) { SBnotifMK.SetActive(false); }
        }
        else if (InputMap.currentControlScheme == "Keyboard&Mouse") //player using M and K
        {
            if (SBnotifGpad.activeSelf == true) { SBnotifGpad.SetActive(false); }
            if (SBnotifMK.activeSelf == false) { SBnotifMK.SetActive(true); }
        }
    }

    void ChangeTutorialTxt() 
    {
        for (int i = 0; i < TutorialHolder.transform.childCount; i++) 
        {
            if (InputMap.currentControlScheme == "Gamepad") //player using xbox
            {
                TutorialHolder.transform.GetChild(i).GetComponent<TutorialScript>().ChangeSchemeGpad();
            }
            else if (InputMap.currentControlScheme == "Keyboard&Mouse") //player using M&K
            {
                TutorialHolder.transform.GetChild(i).GetComponent<TutorialScript>().ChangeSchemeMandK();
            }      
        }
    }
}
