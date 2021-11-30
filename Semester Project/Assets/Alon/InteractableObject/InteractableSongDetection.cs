using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableSongDetection : MonoBehaviour
{

    public string[] TargetSongName = new string[6];


    public Material Default_Mat, Outline_Mat;

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
        if (gameObject.GetComponent<TelportGetPos>() != null) 
        {
            TargetSongName[index] = "Song of Teleportation";
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
                    if (gameObject.GetComponent<MovablePlatform>().MoveHori == false) 
                    { 
                        gameObject.GetComponent<MovablePlatform>().MoveHori = true;
                        gameObject.GetComponent<MovablePlatform>().MoveVert = false;
                    }
                    else { gameObject.GetComponent<MovablePlatform>().MoveHori = false; }
                }
                else if (SongPlayed == "Song of Vertical")
                {
                    if(gameObject.GetComponent<MovablePlatform>().MoveVert == false){ 
                        gameObject.GetComponent<MovablePlatform>().MoveVert = true; 
                        gameObject.GetComponent<MovablePlatform>().MoveHori = false; 
                    }
                    else { gameObject.GetComponent<MovablePlatform>().MoveVert = false; }
                    
                }
                else if (SongPlayed == "Song of Large")
                {
                    gameObject.GetComponent<ScaleChange>().IncreaseSize();
                }
                else if (SongPlayed == "Song of Small")
                {
                    gameObject.GetComponent<ScaleChange>().DecreaseSize();
                }
                else if (SongPlayed == "Song of Teleportation")
                {
                    if (gameObject.transform.GetComponentInParent<Teleporter>().IsActive == false) 
                    { 
                        gameObject.transform.GetComponentInParent<Teleporter>().IsActive = true; 
                        gameObject.GetComponentInParent<Teleporter>().VisFeedback1.SetActive(true);
                        gameObject.GetComponentInParent<Teleporter>().VisFeedback2.SetActive(true);
                    }
                    else{ 
                        gameObject.transform.GetComponentInParent<Teleporter>().IsActive = false;
                        gameObject.GetComponentInParent<Teleporter>().VisFeedback1.SetActive(false);
                        gameObject.GetComponentInParent<Teleporter>().VisFeedback2.SetActive(false);
                    }

                }

            }
        }
        
    }


    public void Highlight() 
    {
        gameObject.GetComponent<SpriteRenderer>().material = Outline_Mat;
    }

    public void UnHighlight() 
    {
        gameObject.GetComponent<SpriteRenderer>().material = Default_Mat;
    }

}
