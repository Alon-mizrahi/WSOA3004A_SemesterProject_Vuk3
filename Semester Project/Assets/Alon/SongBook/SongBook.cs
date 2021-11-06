using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class SongBook : MonoBehaviour
{
    bool firstOpen = false;
    public GameObject NewSongNotif;
    public bool NewSong = false;

    int index = 0;
    //public GameObject PageUI;
    public GameObject SongbookUI;

    public PlayerInput Scheme;

    public GameObject Page1;
    public GameObject Page2;
    public GameObject Page3;
    public GameObject Page4;
    public GameObject Page5;
    public GameObject Page6;

    public int ActivePage = 1;


    public Song[] Songlist;


    public Sprite Num1, Num2, Num3, Num4;
    GameObject Acontainer;
    GameObject Ncontainer;

    public void AddSong(Song song) //get children of gameobject component songs
    {
        Songlist[index] = song;
        index++;
        SetUI();
    }

    void SetUI() 
    {
        //Setting the page variables to the song variables
        GameObject thePage = Page1;
        if (index - 1 == 0) { thePage = Page1; }
        else if (index - 1 == 1) { thePage = Page2; }
        else if (index - 1 == 2) { thePage = Page3; }
        else if (index - 1 == 3) { thePage = Page4; }
        else if (index - 1 == 4) { thePage = Page5; }
        else if (index - 1 == 5) { thePage = Page6; }

        Text Title = thePage.transform.Find("Song Title").gameObject.GetComponent<Text>();
        Title.text = Songlist[index - 1].SongTitle;
        if (Scheme.currentControlScheme == "Gamepad") { SetUIGpad(thePage); }
        else if(Scheme.currentControlScheme == "Keyboard&Mouse") { SetUIMandK(thePage); }
    }


    void SetUIGpad(GameObject thePage) 
    {
        Acontainer = thePage.transform.Find("Note_Arrows").gameObject;
        Ncontainer = thePage.transform.Find("Note_Nums").gameObject;

        Acontainer.SetActive(true);
        Ncontainer.SetActive(false);

        Image Note1 = Acontainer.transform.Find("A1").gameObject.GetComponent<Image>();
        Image Note2 = Acontainer.transform.Find("A2").gameObject.GetComponent<Image>();
        Image Note3 = Acontainer.transform.Find("A3").gameObject.GetComponent<Image>();
        Image Note4 = Acontainer.transform.Find("A4").gameObject.GetComponent<Image>();
        Image Note5 = Acontainer.transform.Find("A5").gameObject.GetComponent<Image>();
        Image Note6 = Acontainer.transform.Find("A6").gameObject.GetComponent<Image>();

        Image Note = Note1;

        for (int i = 0; i < Songlist[index - 1].Notes.Length; i++)
        {

            //get note UI object
            if (i == 0) { Note = Note1; }
            else if (i == 1) { Note = Note2; }
            else if (i == 2) { Note = Note3; }
            else if (i == 3) { Note = Note4; }
            else if (i == 4) { Note = Note5; }
            else if (i == 5) { Note = Note6; }

            //set colors
            if (Songlist[index - 1].Notes[i].ToString() == "1") { Note.color = Color.red; Note.transform.Rotate(Vector3.forward, 0f); }
            else if (Songlist[index - 1].Notes[i].ToString() == "2") { Note.color = Color.yellow; Note.transform.Rotate(Vector3.forward, -90f); }
            else if (Songlist[index - 1].Notes[i].ToString() == "3") { Note.color = Color.blue; Note.transform.Rotate(Vector3.forward, 180f); }
            else if (Songlist[index - 1].Notes[i].ToString() == "4") { Note.color = Color.green; Note.transform.Rotate(Vector3.forward, 90f); }

        }
    }

    void SetUIMandK(GameObject thePage) 
    {
        Acontainer = thePage.transform.Find("Note_Arrows").gameObject;
        Ncontainer = thePage.transform.Find("Note_Nums").gameObject;

        Acontainer.SetActive(false);
        Ncontainer.SetActive(true);

        Image Note1 = Ncontainer.transform.Find("N1").gameObject.GetComponent<Image>();
        Image Note2 = Ncontainer.transform.Find("N2").gameObject.GetComponent<Image>();
        Image Note3 = Ncontainer.transform.Find("N3").gameObject.GetComponent<Image>();
        Image Note4 = Ncontainer.transform.Find("N4").gameObject.GetComponent<Image>();
        Image Note5 = Ncontainer.transform.Find("N5").gameObject.GetComponent<Image>();
        Image Note6 = Ncontainer.transform.Find("N6").gameObject.GetComponent<Image>();

        Image Note = Note1;

        for (int i = 0; i < Songlist[index - 1].Notes.Length; i++)
        {

            //get note UI object
            if (i == 0) { Note = Note1; }
            else if (i == 1) { Note = Note2; }
            else if (i == 2) { Note = Note3; }
            else if (i == 3) { Note = Note4; }
            else if (i == 4) { Note = Note5; }
            else if (i == 5) { Note = Note6; }

            //set colors and num
            if (Songlist[index - 1].Notes[i].ToString() == "1") { Note.color = Color.red; Note.sprite = Num1; }
            else if (Songlist[index - 1].Notes[i].ToString() == "2") { Note.color = Color.yellow; Note.sprite = Num2; }
            else if (Songlist[index - 1].Notes[i].ToString() == "3") { Note.color = Color.blue; Note.sprite = Num3; }
            else if (Songlist[index - 1].Notes[i].ToString() == "4") { Note.color = Color.green; Note.sprite = Num4; }
        }
    }



    public void NextPage() 
    {
        Debug.Log("SongBook Next Page");
        if (ActivePage < 3) { ActivePage++; }
        ChangePage();
    }


    public void PreviousPage()
    {
        Debug.Log("SongBook Previous Page");
        if (ActivePage > 1) { ActivePage--; }
        ChangePage();
    }

    public void ChangePage() 
    {
        //determine active page
        //if (Page1.activeSelf == true && Page2.activeSelf == true) { ActivePage = 1; }
        //else if (Page3.activeSelf == true && Page4.activeSelf == true) { ActivePage = 2; }
        //else if (Page5.activeSelf == true && Page6.activeSelf == true) { ActivePage = 3; }

        if (ActivePage == 1)
        {
            Page1.SetActive(true);
            Page2.SetActive(true);
            Page3.SetActive(false);
            Page4.SetActive(false);
            Page5.SetActive(false);
            Page6.SetActive(false);
        }
        else if (ActivePage == 2)
        {
            Page1.SetActive(false);
            Page2.SetActive(false);
            Page3.SetActive(true);
            Page4.SetActive(true);
            Page5.SetActive(false);
            Page6.SetActive(false);
        }
        else if (ActivePage == 3)
        {
            Page1.SetActive(false);
            Page2.SetActive(false);
            Page3.SetActive(false);
            Page4.SetActive(false);
            Page5.SetActive(true);
            Page6.SetActive(true);
        }

    }


    public void ToggleBook() 
    {
        Debug.Log("Toggling Song Book");

        if (SongbookUI.activeSelf == false) //book is closed
        {
            SongbookUI.SetActive(true);
            if (firstOpen == false) 
            {
                firstOpen = true;
                Page1.SetActive(true);
                Page2.SetActive(true);
                Page3.SetActive(false);
                Page4.SetActive(false);
                Page5.SetActive(false);
                Page6.SetActive(false);
            }
            if (NewSong == true) { GoToLastPage(); }

        }else{//book is open
            SongbookUI.SetActive(false);
        }
        
    }


    void GoToLastPage() 
    {
        NewSongNotif.SetActive(false);
        NewSong = false;

        int temp=0;
        for (int i = 0; i < Songlist.Length; i++) 
        {
            if (Songlist[i] != null) { temp++; }
        }

        if (temp == 0 || temp == 1) 
        {
            ActivePage = 1;
        }
        else if (temp == 3 || temp == 4)
        {
            ActivePage = 2;
        }
        if (temp == 5 || temp == 6)
        {
            ActivePage = 3;
        }
        ChangePage();
    }



    public void ChangeUIScheme() 
    {
        GameObject thePage = Page1;
        for (int j = 0; j < Songlist.Length; j++) 
        {
            if (j == 0) { thePage = Page1; }
            else if (j == 1) { thePage = Page2; }
            else if (j == 2) { thePage = Page3; }
            else if (j == 3) { thePage = Page4; }
            else if (j == 4) { thePage = Page5; }
            else if (j == 5) { thePage = Page6; }

            if (Songlist[j] != null)
            {
                if (Scheme.currentControlScheme == "Gamepad") { SetUIGpad(thePage); }
                else if (Scheme.currentControlScheme == "Keyboard&Mouse") { SetUIMandK(thePage); }
            }else {
                if (Scheme.currentControlScheme == "Gamepad") 
                {
                    Acontainer = thePage.transform.Find("Note_Arrows").gameObject;
                    Ncontainer = thePage.transform.Find("Note_Nums").gameObject;
                    Acontainer.SetActive(true);
                    Ncontainer.SetActive(false);
                }
                else if (Scheme.currentControlScheme == "Keyboard&Mouse") 
                {
                    Acontainer = thePage.transform.Find("Note_Arrows").gameObject;
                    Ncontainer = thePage.transform.Find("Note_Nums").gameObject;
                    Acontainer.SetActive(false);
                    Ncontainer.SetActive(true);
                }
            }
        
        }
        
    }


}