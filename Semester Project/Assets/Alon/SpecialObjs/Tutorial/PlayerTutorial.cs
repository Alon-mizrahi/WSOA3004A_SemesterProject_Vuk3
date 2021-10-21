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
        if (other.tag == "Tutorial") 
        {
            CurrentTut.GetComponent<TutorialScript>().TutorialUItxt.enabled = false;
            CurrentTut = null; 
        }
    }


    public void ActivateTutorial() 
    {
        if (CurrentTut != null) 
        {
            CurrentTut.GetComponent<TutorialScript>().ShowTutorial();
            //gameObject.GetComponent<PlayerInput>().SwitchCurrentActionMap("Tutorial");
        }
    }

    private void Update()
    {
        if (CurrentTut != null && CurrentTut.GetComponent<TutorialScript>().TutFinished == true) 
        {
            gameObject.GetComponent<PlayerInput>().SwitchCurrentActionMap("Player");
        }
    }
}
