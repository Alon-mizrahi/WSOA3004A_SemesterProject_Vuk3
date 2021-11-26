using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTutorial : MonoBehaviour
{
    public GameObject CurrentTut;

    public bool FirstRound = true;


    public void AtTutorial(GameObject Tut) //called from collision with tut , this starts tut
    {
        CurrentTut = Tut;
        CurrentTut.GetComponent<TutorialScript>().TutorialUItxt.enabled = true;
    }

    public void LeftTutorial() 
    {
        if (CurrentTut != null) 
        {
            CurrentTut.GetComponent<TutorialScript>().TutorialUItxt.enabled = false;
            CurrentTut = null; 
        }
    }


    public void ActivateTutorial() //called from pressing interact at tut
    {
        if (CurrentTut != null && FirstRound) 
        {
            CurrentTut.GetComponent<TutorialScript>().ShowTutorial();
        }
    }

    public void CallNextTut(InputAction.CallbackContext TutContext) 
    {
        if (CurrentTut != null && TutContext.started)
        {
            CurrentTut.GetComponent<TutorialScript>().NextText();
        }
    }


    public void EndTut() 
    {
        gameObject.GetComponent<PlayerInput>().SwitchCurrentActionMap("Player");
    }

}
