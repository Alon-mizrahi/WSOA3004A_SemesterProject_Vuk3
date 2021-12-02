using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class ColourTeaching : MonoBehaviour
{
    public Light2D Light;
    
    string Song;

    GameObject LearningArea;

    public float Delay1, Delay2;

    private void Start()
    {
        Song = gameObject.transform.GetChild(0).gameObject.GetComponent<Song>().Notes;
        LearningArea = gameObject.transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && other.GetType() == typeof(BoxCollider2D)) 
        {

            StartCoroutine("FlashSequence");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && other.GetType() == typeof(BoxCollider2D))
        {
            StopCoroutine("FlashSequence");
            Light.color = Color.white;
        }
    }


    private void Update()
    {
            if (!LearningArea.activeSelf) 
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                StopCoroutine("FlashSequence");
                Light.color = Color.white;
            }
    }


    IEnumerator FlashSequence() 
    {
        for (int i = 0; i < Song.Length; i++) 
        {
            ColuorChange(Song[i]);
            yield return new WaitForSeconds(Delay1);
            
           // Light.color = Color.white;
           // yield return new WaitForSeconds(Delay1);
        }

        yield return new WaitForSeconds(Delay2);

        StartCoroutine("FlashSequence");
    }

    void ColuorChange(char Note) 
    {
        if (Note == '1') { Light.color = Color.red; }
        else if (Note == '2') { Light.color = Color.yellow; }
        else if (Note == '3') { Light.color = Color.blue; }
        else if (Note == '4') { Light.color = Color.green; }
    }

}
