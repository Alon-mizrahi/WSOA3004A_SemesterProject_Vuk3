using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class SongDetection : MonoBehaviour
{
    //song is going to be a string of notes

    public string CurrentSong = "";

    public float MaxIdleTime = 5f;
    public float IdleTimer;
    public GameObject NotesUI;

    GetInteractables GetInteractablesScript;

    public SongBook SongBook;

    public SpriteRenderer RangeUI;
    bool isRangeUIOn = false;

    public GameObject CurrentLerningArea;
    public GameObject CurrentCrystal;

    PlayerInput PI;
    public Sprite Num1, Num2, Num3, Num4, NumAsterix;

    // Start is called before the first frame update
    void Start()
    {
        SongBook.gameObject.SetActive(false);
        IdleTimer = MaxIdleTime;
        GetInteractablesScript = gameObject.GetComponent<GetInteractables>();
        NotesUI.SetActive(false);

        PI = gameObject.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        //GetNote();
        IdleSong();
    }

    void IdleSong() 
    {
        if (IdleTimer > 0 && CurrentSong != "")
        {
            IdleTimer -= Time.deltaTime;

        }
        else if(IdleTimer <= 0)
        {
            ClearSong();
            //NotesUI.SetActive(false);
        }

        
    }

    public void ClearSong()
    {
        IdleTimer = MaxIdleTime;
        CurrentSong = "";
        Debug.Log("song cleared");

        StartCoroutine("PauseBeforeClear");
    }

    IEnumerator PauseBeforeClear() 
    {
        yield return new WaitForSeconds(0.8f);

        if(PI.currentControlScheme == "Gamepad")
        {  
            for (int i = 1; i <= 6; i++)
            {
                yield return new WaitForSeconds(0.3f);
                NotesUI.transform.Find("Note" + i).GetComponent<Image>().color = Color.white;
                NotesUI.transform.Find("Note" + i).transform.rotation = Quaternion.identity;
            }
        }
        else if (PI.currentControlScheme == "Keyboard&Mouse") 
        {
            for (int i = 1; i <= 6; i++)
            {
                yield return new WaitForSeconds(0.3f);
                NotesUI.transform.Find("Note" + i).GetComponent<Image>().color = Color.white;
                NotesUI.transform.Find("Note" + i).gameObject.GetComponent<Image>().sprite = NumAsterix;
            }
        }

        
        NotesUI.SetActive(false);
    }

    public void GetNote(string Key) 
    {
        StopCoroutine("PauseBeforeClear");

        Image Note = NotesUI.transform.Find("Note1").GetComponent<Image>();
        if (CurrentSong.Length == 1-1) { Note = NotesUI.transform.Find("Note1").GetComponent<Image>(); }
        else if (CurrentSong.Length == 2-1) { Note = NotesUI.transform.Find("Note2").GetComponent<Image>(); }
        else if (CurrentSong.Length == 3-1) { Note = NotesUI.transform.Find("Note3").GetComponent<Image>(); }
        else if (CurrentSong.Length == 4-1) { Note = NotesUI.transform.Find("Note4").GetComponent<Image>(); }
        else if (CurrentSong.Length == 5-1) { Note = NotesUI.transform.Find("Note5").GetComponent<Image>(); }
        else if (CurrentSong.Length == 6-1) { Note = NotesUI.transform.Find("Note6").GetComponent<Image>(); }



        if (PI.currentControlScheme == "Gamepad") { GetNoteGpad(Note, Key); }
        else if (PI.currentControlScheme == "Keyboard&Mouse") { GetNoteMandK(Note, Key); }

        if (isRangeUIOn == true) { StopCoroutine("RangeIndicator"); isRangeUIOn = false; }
        StartCoroutine("RangeIndicator");

        if (CurrentSong.Length == 3) { CheckForCrystal(); }

        else if (CurrentSong.Length == 2) { CheckForLearning(); }
        else if (CurrentSong.Length == 4) { CheckForLearning(); }

        if (CurrentSong.Length == 6)
        {
            CheckForLearning();
            CheckSong();
            
            CheckForCrystal();
            ClearSong();
        }
    }

    void GetNoteGpad(Image Note, string Key) 
    {
        if (CurrentSong.Length == 0)
        {
            for (int i = 1; i <= 6; i++)
            {
                NotesUI.transform.Find("Note" + i).GetComponent<Image>().color = Color.white;
                NotesUI.transform.Find("Note" + i).transform.rotation = Quaternion.identity;
            }
        }

        NotesUI.SetActive(true);
        if (Key == "Up")
        {
            CurrentSong += "1";//whatever note this will be
            IdleTimer = MaxIdleTime; //only if input detected
            Debug.Log("Song: " + CurrentSong);
            Note.color = Color.red;
            Note.transform.Rotate(Vector3.forward, 0f);
        }
        else if (Key == "Down")
        {
            CurrentSong += "3";//whatever note this will be
            IdleTimer = MaxIdleTime; //only if input detected
            Debug.Log("Song: " + CurrentSong);
            Note.color = Color.blue;
            Note.transform.Rotate(Vector3.forward, 180f);
        }
        else if (Key == "Left")
        {
            CurrentSong += "4";//whatever note this will be
            IdleTimer = MaxIdleTime; //only if input detected
            Debug.Log("Song: " + CurrentSong);
            Note.color = Color.green;
            Note.transform.Rotate(Vector3.forward, 90f);
        }
        else if (Key == "Right")
        {
            CurrentSong += "2";//whatever note this will be
            IdleTimer = MaxIdleTime; //only if input detected
            Debug.Log("Song: " + CurrentSong);
            Note.color = Color.yellow;
            Note.transform.Rotate(Vector3.forward, -90f);
        }
    }

    void GetNoteMandK(Image Note, string Key) 
    {
        if (CurrentSong.Length == 0)
        {
            for (int i = 1; i <= 6; i++)
            {
                NotesUI.transform.Find("Note" + i).GetComponent<Image>().color = Color.white;
                NotesUI.transform.Find("Note" + i).gameObject.GetComponent<Image>().sprite = NumAsterix;
            }
        }

        NotesUI.SetActive(true);
        if (Key == "Up")
        {
            CurrentSong += "1";//whatever note this will be
            IdleTimer = MaxIdleTime; //only if input detected
            Debug.Log("Song: " + CurrentSong);
            Note.color = Color.red;
            Note.sprite = Num1;
        }
        else if (Key == "Down")
        {
            CurrentSong += "3";//whatever note this will be
            IdleTimer = MaxIdleTime; //only if input detected
            Debug.Log("Song: " + CurrentSong);
            Note.color = Color.blue;
            Note.sprite = Num3;
        }
        else if (Key == "Left")
        {
            CurrentSong += "4";//whatever note this will be
            IdleTimer = MaxIdleTime; //only if input detected
            Debug.Log("Song: " + CurrentSong);
            Note.color = Color.green;
            Note.sprite = Num4;
        }
        else if (Key == "Right")
        {
            CurrentSong += "2";//whatever note this will be
            IdleTimer = MaxIdleTime; //only if input detected
            Debug.Log("Song: " + CurrentSong);
            Note.color = Color.yellow;
            Note.sprite = Num2;
        }
    }


    void CheckSong() 
    {
        for (int i = 0; i < SongBook.Songlist.Length; i++) 
        {
            if (SongBook.Songlist[i] != null) 
            {
                if (CurrentSong == SongBook.Songlist[i].Notes) 
                {
                    Debug.Log("Played " + SongBook.Songlist[i].SongTitle);
                    GetInteractablesScript.SongPlayed(SongBook.Songlist[i].SongTitle);
                    break;
                }
            }

        }
    }

    void CheckForLearning() 
    {
        if (CurrentLerningArea != null)
        {
            if (CurrentLerningArea.GetComponent<CallAndRespond>() != null)
            {
                CurrentLerningArea.GetComponent<CallAndRespond>().PlayerResponse();
            }
            else if (CurrentSong == CurrentLerningArea.GetComponent<Song>().Notes)
            {
                CurrentLerningArea.GetComponent<Song>().AddtoSongBook(); 
            }
        }
    }

    void CheckForCrystal() 
    {
        if (CurrentCrystal != null) 
        {
            CurrentCrystal.GetComponent<WorldCrystal>().PlayerResponse();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "LearningArea") { CurrentLerningArea = other.gameObject; }
        //if (other.tag == "Crystal") { CurrentCrystal = other.gameObject; }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "LearningArea") { CurrentLerningArea = null; }
        if (other.tag == "Crystal") { CurrentCrystal = null; }
    }

    IEnumerator RangeIndicator() //Called when playing a note
    {
        //turn indicator on
        RangeUI.enabled = true;
        isRangeUIOn = true;
        yield return new WaitForSeconds(4f);
        //turn indicator off
        RangeUI.enabled = false;
    }


}
