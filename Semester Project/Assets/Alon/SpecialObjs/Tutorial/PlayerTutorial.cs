using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTutorial : MonoBehaviour
{
    public GameObject CurrentTut;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Tutorial" && other.GetComponent<TutorialScript>().Collided == true) 
        {
            CurrentTut = other.gameObject;
            CurrentTut.GetComponent<TutorialScript>().TutorialUItxt.text = "Press A to Interact";
            CurrentTut.GetComponent<TutorialScript>().TutorialUItxt.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Tutorial" && other.GetComponent<TutorialScript>().Collided == false) 
        {
            if (CurrentTut != null) 
            {
                CurrentTut.GetComponent<TutorialScript>().TutorialUItxt.enabled = false;
                CurrentTut = null; 
            }
        }
    }


    public void ActivateTutorial() 
    {
        if (CurrentTut != null) 
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
