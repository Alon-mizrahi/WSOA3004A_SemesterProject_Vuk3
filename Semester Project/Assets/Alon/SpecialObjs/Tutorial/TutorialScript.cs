using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.InputSystem;

public class TutorialScript : MonoBehaviour
{
    public Text TutorialUItxt;
    public string TutorialText;
    GameObject Player;
    public bool TutFinished = false;

    public bool Collided;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void ShowTutorial() 
    {
        TutorialUItxt.text = TutorialText;
        TutorialUItxt.enabled = true;
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
