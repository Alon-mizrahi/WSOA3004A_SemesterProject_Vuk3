using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.InputSystem;

public class TutorialScript : MonoBehaviour
{
    public Text TutorialUItxt;
    public string[] TutorialText;
    GameObject Player;
    //public bool TutFinished = false;

    public const string Defualttxt = "Press 'X' to Interact";

    public bool Collided;

    public bool inTutorial = false;
    int index = 0;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void ShowTutorial() 
    {
        TutorialUItxt.text = TutorialText[0];
        TutorialUItxt.enabled = true;
        inTutorial = true;
    }

    public void NextText() 
    {
        if (inTutorial == true) 
        {
            if (index >= TutorialText.Length-1)
            {
                inTutorial = false;
                index = 0;
                TutorialUItxt.text = Defualttxt;

                Player.GetComponent<PlayerTutorial>().EndTut();
            }
            else { 
                index++;
                TutorialUItxt.text = TutorialText[index];
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && other.GetType() == typeof(BoxCollider2D)) { Collided = true; }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && other.GetType() == typeof(BoxCollider2D)) { Collided = false; }
    }
}
