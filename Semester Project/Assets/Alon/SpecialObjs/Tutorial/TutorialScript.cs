using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.InputSystem;

public class TutorialScript : MonoBehaviour
{
    public Text TutorialUItxt;
    public string[] TutorialText;
    public string[] TextGpad = { "" };
    public string[] TextMK = { "" };
    GameObject Player;
    public bool isTyping = false;

    string Defualttxt = "Press 'A' to Interact";

    public bool Collided;

    public bool inTutorial = false;
public int index = 0;

    private IEnumerator coroutine;

    AudioSource AS;

    private void Start()
    {
        //Player.GetComponent<PlayerTutorial>().FirstRound;

        AS = gameObject.GetComponent<AudioSource>();

        Player = GameObject.FindGameObjectWithTag("Player");
        if (TextGpad.Length >= TextMK.Length) { TutorialText = new string[TextGpad.Length]; }
        else { TutorialText = new string[TextMK.Length]; }
        ChangeSchemeGpad();
    }

    public void ShowTutorial() //start of tut
    {
        //TutorialUItxt.text = TutorialText[0];
        TutorialUItxt.enabled = true;
        inTutorial = true;

        index = 0;

        coroutine = SpellText(TutorialText[index]);
        StartCoroutine(coroutine);

        index++;
        Player.GetComponent<PlayerTutorial>().FirstRound = false;
    }

    public void NextText() //called when player pushes button
    {
        if (inTutorial == true)
        {
            //index from 1 -> length

            if (index < TutorialText.Length)
            {
                if (isTyping == false)
                {
                    coroutine = SpellText(TutorialText[index]);
                    StartCoroutine(coroutine);
                    index++; //on length-1 ->
                }
                else if (isTyping == true)
                {
                    StopCoroutine(coroutine);
                    AS.Stop();
                    TutorialUItxt.text = TutorialText[index - 1];

                    isTyping = false;
                }
            }
            else 
            {
                if (isTyping == true)
                {
                    StopCoroutine(coroutine);
                    AS.Stop();
                    TutorialUItxt.text = TutorialText[index - 1];

                    isTyping = false;
                }
                else//end of tut
                { 

                    inTutorial = false;
                    index = 0;
                    TutorialUItxt.text = Defualttxt;
                    TutorialUItxt.enabled = false;

                    Player.GetComponent<PlayerTutorial>().EndTut();
                }
            }
        }
    }


    IEnumerator SpellText(string TutText)
    {
        isTyping = true;

        string temp = "";
        AS.Play();

        for (int i = 0; i < TutText.Length; i++) 
        {
            temp += TutText[i];

            TutorialUItxt.text = temp;
            yield return new WaitForSeconds(0.1f);
        }

        AS.Stop();
        isTyping = false;
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
        if (other.gameObject.tag == "Player" && other.GetType() == typeof(BoxCollider2D)) 
        { 
            Collided = true; other.gameObject.GetComponent<PlayerTutorial>().AtTutorial(gameObject);
            TutorialUItxt.text = Defualttxt;
            TutorialUItxt.enabled = true;
            Player.GetComponent<PlayerTutorial>().FirstRound = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && other.GetType() == typeof(BoxCollider2D)) 
        { 
            Collided = false; other.gameObject.GetComponent<PlayerTutorial>().LeftTutorial();
            TutorialUItxt.enabled = false;
        }
    }
}
