using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableSongDetection : MonoBehaviour
{

    public string[] TargetSongName = new string[10];//{ "", "", "", "", "", "", "", "", "", "" };

    private void Start()
    {
        int index = 0;
        //get scripts to get target names and how many songs can effect object
        if (gameObject.GetComponent<DoorScript>() != null) 
        {
            TargetSongName[index] = "Song of Opening";
            index++;
        }
        if (gameObject.GetComponent<MovablePlatform>() != null)
        {
            TargetSongName[index] = "Song of Horizontal";
            index++;
            TargetSongName[index] = "Song of Vertical";
            index++;
        }
        if (gameObject.GetComponent<ScaleChange>() != null)
        {
            TargetSongName[index] = "Song of Large";
            index++;
            TargetSongName[index] = "Song of Small";
            index++;
        }
        //add more as needed
    }

    public void SongCheck(string SongPlayed) 
    {
        for (int i = 0; i < TargetSongName.Length; i++) 
        {
            if (SongPlayed == TargetSongName[i] && TargetSongName[i] != null)
            {
                //call object specific ability script
                //add scripots here if make new interactable object

                if (SongPlayed == "Song of Opening")
                {
                    if (gameObject.GetComponent<DoorScript>().Opened == false) { gameObject.GetComponent<DoorScript>().isOpen = true; }
                    else { gameObject.GetComponent<DoorScript>().isClose = true; }
                }
                else if (SongPlayed == "Song of Horizontal") 
                {
                    gameObject.GetComponent<MovablePlatform>().MoveHori = true;
                }
                else if (SongPlayed == "Song of Vertical")
                {
                    gameObject.GetComponent<MovablePlatform>().MoveVert = true;
                }
                else if (SongPlayed == "Song of Large")
                {
                    gameObject.GetComponent<ScaleChange>().IncreaseSize();
                }
                else if (SongPlayed == "Song of Small")
                {
                    gameObject.GetComponent<ScaleChange>().DecreaseSize();
                }

            }
        }
        
    }


}
