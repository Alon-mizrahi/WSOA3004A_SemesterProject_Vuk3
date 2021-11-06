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
            
        }
    }

    public void AtTutorial(GameObject Tut) 
    {
        CurrentTut = Tut;
        if (gameObject.GetComponent<PlayerInput>().currentControlScheme == "Gamepad") { CurrentTut.GetComponent<TutorialScript>().TutorialUItxt.text = "Press 'A' to Interact"; }
        else if (gameObject.GetComponent<PlayerInput>().currentControlScheme == "Keyboard&Mouse") { CurrentTut.GetComponent<TutorialScript>().TutorialUItxt.text = "Press 'Space' to Interact"; }

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

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Tutorial" && other.GetComponent<TutorialScript>().Collided == false) 
        {
            
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
