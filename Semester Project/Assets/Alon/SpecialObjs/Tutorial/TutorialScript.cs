using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.InputSystem;

public class TutorialScript : MonoBehaviour
{
    public Text TutorialUItxt;
    string[] TutorialText;
    public string[] TextGpad = { "" };
    public string[] TextMK = { "" };
    GameObject Player;
    //public bool TutFinished = false;

    public string Defualttxt = "Press 'A' to Interact";

    public bool Collided;

    public bool inTutorial = false;
    int index = 0;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        TutorialText = new string[TextGpad.Length];
        ChangeSchemeGpad();
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

    public void ChangeSchemeGpad() 
    {
        for (int i = 0; i < TextGpad.Length; i++) 
        {
            TutorialText[i] = TextGpad[i];
        }
        Defualttxt = "Press 'A' to Interact";
    }

    public void ChangeSchemeMandK()
    {
        for (int i = 0; i < TextMK.Length; i++)
        {
            TutorialText[i] = TextMK[i];
        }
        Defualttxt = "Press 'Space' to Interact";
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && other.GetType() == typeof(BoxCollider2D)) { Collided = true; other.gameObject.GetComponent<PlayerTutorial>().AtTutorial(gameObject); }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && other.GetType() == typeof(BoxCollider2D)) { Collided = false; other.gameObject.GetComponent<PlayerTutorial>().LeftTutorial(); }
    }
}
