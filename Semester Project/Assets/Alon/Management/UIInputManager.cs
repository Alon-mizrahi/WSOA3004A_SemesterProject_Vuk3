using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIInputManager : MonoBehaviour
{
    public PlayerInput InputMap;

    //Top right corner UI arrows
    public GameObject ArrowUI;
    public GameObject NumUI;

    //other ui changes



    // Update is called once per frame
    void Update()
    {
        ChangeCanvaseArrows(); //Top right corner arrows
        Debug.Log("Current Input: " + InputMap.currentControlScheme);
    }

    void ChangeCanvaseArrows() 
    {
        if (InputMap.currentControlScheme == "Gamepad") //player using xbox
        {
            if (ArrowUI.activeSelf == false) { ArrowUI.SetActive(true); }
            if (NumUI.activeSelf == true) { NumUI.SetActive(false); }
        }
        else if (InputMap.currentControlScheme == "dog") //player using PS
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
}
