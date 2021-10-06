using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableSongDetection : MonoBehaviour
{

    public string TargetSongName;

    public void SongCheck(string SongPlayed) 
    {
        if (SongPlayed == TargetSongName) 
        {
            //activate object ability
            Debug.Log("Song Title passed correctly");

            //call object specific ability script
            //add scripots here if make new interactable object
            if (gameObject.name == "Interactable_Door")
            {
                gameObject.GetComponent<DoorScript>().isOpen = true;
            }
            else if (gameObject.name == "Interactable_MovablePlatform") 
            {
                gameObject.GetComponent<MovablePlatform>().isActive = true;
            }


        }
    }


}
