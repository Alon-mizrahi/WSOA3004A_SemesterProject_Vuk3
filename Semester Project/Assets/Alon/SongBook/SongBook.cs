using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongBook : MonoBehaviour
{

    int index = 0;
    public GameObject PageUI;
    public GameObject SongbookUI;


    public GameObject Page1;
    public GameObject Page2;
    public GameObject Page3;
    public GameObject Page4;
    public GameObject Page5;
    public GameObject Page6;

    int ActivePage = 1;


    public Song[] Songlist;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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



        //GameObject thePage = Instantiate(PageUI, transform.position, transform.rotation);

        Text Title = thePage.transform.Find("Song Title").gameObject.GetComponent<Text>();
        Title.text = Songlist[index - 1].SongTitle;

        Image Note1 = thePage.transform.Find("Note1").gameObject.GetComponent<Image>();
        Image Note2 = thePage.transform.Find("Note2").gameObject.GetComponent<Image>();
        Image Note3 = thePage.transform.Find("Note3").gameObject.GetComponent<Image>();
        Image Note4 = thePage.transform.Find("Note4").gameObject.GetComponent<Image>();
        Image Note5 = thePage.transform.Find("Note5").gameObject.GetComponent<Image>();
        Image Note6 = thePage.transform.Find("Note6").gameObject.GetComponent<Image>();

        Image Note = Note1;
        for (int i = 0; i < Songlist[index - 1].Notes.Length; i++) 
        {

            //get not UI object
            if (i == 0) { Note = Note1; }
            else if (i == 1) { Note = Note2; }
            else if (i == 2) { Note = Note3; }
            else if (i == 3) { Note = Note4; }
            else if (i == 4) { Note = Note5; }
            else if (i == 5) { Note = Note6; }

            //set colors
            if (Songlist[index - 1].Notes[i].ToString() == "1") { Note.color = Color.red; }
            else if(Songlist[index - 1].Notes[i].ToString() == "2") { Note.color = Color.blue; }
            else if (Songlist[index - 1].Notes[i].ToString() == "3") { Note.color = Color.green; }
            else if (Songlist[index - 1].Notes[i].ToString() == "4") { Note.color = Color.yellow; }

        }

        //put page in book, order pages
        //thePage.transform.SetParent(SongbookUI.transform);

        //how to book???

        //if ((index - 1) % 2 == 0)//even
        //{
        //    thePage.transform.localPosition = new Vector2(440, 0);
        //}
       // else //odd
       // {
       //     thePage.transform.localPosition = new Vector2(-440, 0);
       // }
        

    }






    public void NextPage() 
    {
        if (ActivePage < 3) { ActivePage++; }
        ChangePage();
    }


    public void PreviousPage()
    {
        if(ActivePage > 1) { ActivePage--; }
        ChangePage();
    }

    void ChangePage() 
    {
        //determine active page
        if (Page1.activeSelf == true && Page2.activeSelf == true) { ActivePage = 1; }
        else if (Page3.activeSelf == true && Page4.activeSelf == true) { ActivePage = 2; }
        else if (Page5.activeSelf == true && Page6.activeSelf == true) { ActivePage = 3; }

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
            Page1.SetActive(true);
            Page2.SetActive(true);
            Page3.SetActive(false);
            Page4.SetActive(false);
            Page5.SetActive(false);
            Page6.SetActive(false);
        }else{//book is open
            SongbookUI.SetActive(false);
        }
        
    }


}