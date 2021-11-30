using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetInteractables : MonoBehaviour
{
    public GameObject[] Interactables = new GameObject[30];
    public SongBook SB;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Interactable") 
        {

            for (int j = 0; j < 6; j++) 
            {
                for (int k = 0; k < 6; k++) 
                {
                    if (other.gameObject.GetComponent<InteractableSongDetection>().TargetSongName[j] != null && SB.Songlist[k] != null) 
                    {
                        if (other.gameObject.GetComponent<InteractableSongDetection>().TargetSongName[j] == SB.Songlist[k].SongTitle)
                        {
                            other.gameObject.GetComponent<InteractableSongDetection>().Highlight();
                            break;
                        }
                    }
                    
                }
            }

            

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
            
            for (int i = 0; i < Interactables.Length; i++)
            {
                if (Interactables[i] == other.gameObject)
                {
                    other.gameObject.GetComponent<InteractableSongDetection>().UnHighlight();
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
