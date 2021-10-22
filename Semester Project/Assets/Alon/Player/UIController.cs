using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIController : MonoBehaviour
{
    //Controls UIControls;

    //GameObject SongBook;
    public GameObject SongBookUI;

    // Start is called before the first frame update
    void Start()
    {
        //SongBook = GameObject.Find("SongBookBackground");
        //Debug.Log("songbook: "+SongBook);
    }

    public void ToggleSongBook(InputAction.CallbackContext SongBookContext)
    {
        
        if (SongBookContext.started == true) 
        {
            if (SongBookUI != null)
            {
                if (SongBookUI.activeSelf == false)//song book close
                {
                    //Debug.Log("FIF");
                    gameObject.GetComponent<PlayerInput>().SwitchCurrentActionMap("UI");
                    Debug.Log(gameObject.GetComponent<PlayerInput>().currentActionMap);
                }
                else 
                {
                    gameObject.GetComponent<PlayerInput>().SwitchCurrentActionMap("Player");
                    Debug.Log(gameObject.GetComponent<PlayerInput>().currentActionMap);
                }

                SongBookUI.GetComponent<SongBook>().ToggleBook();
                
                //Debug.Log(gameObject.GetComponent<PlayerInput>().currentActionMap);
            }
        }
    }


    public void NextPage(InputAction.CallbackContext NextPageContext) 
    {
        if (NextPageContext.started== true) 
        {
            Debug.Log("UIController Next Page");
            SongBookUI.GetComponent<SongBook>().NextPage();
        }
        
    }

    public void PreviousPage(InputAction.CallbackContext PreviousPageContext)
    {
        if (PreviousPageContext.started == true) 
        {
            Debug.Log("UIController Previous Page");
            SongBookUI.GetComponent<SongBook>().PreviousPage();
        }
        
    }

}
