using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetInteractables : MonoBehaviour
{
    public GameObject[] Interactables = new GameObject[10];


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Interactable") 
        {
            other.gameObject.GetComponent<InteractableSongDetection>().Highlight();

            for (int i = 0; i < Interactables.Length; i++) 
            {
                if (Interactables[i] == null) 
                {
                    Interactables[i] = other.gameObject;
                    break;
                }
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Interactable")
        {
            other.gameObject.GetComponent<InteractableSongDetection>().UnHighlight();
            for (int i = 0; i < Interactables.Length; i++)
            {
                if (Interactables[i] == other.gameObject)
                {
                    Interactables[i] = null;
                    break;
                }
            }
        }
    }

    public void SongPlayed(string SongName) 
    {
        for (int i = 0; i < Interactables.Length; i++) 
        {
            if (Interactables[i] != null && Interactables[i].GetComponent<InteractableSongDetection>() !=null) 
            {
                Interactables[i].GetComponent<InteractableSongDetection>().SongCheck(SongName);
            }
        }
    }



}
