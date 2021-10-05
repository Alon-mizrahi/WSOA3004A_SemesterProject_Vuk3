using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIController : MonoBehaviour
{
    //Controls UIControls;

    GameObject SongBook;

    // Start is called before the first frame update
    void Start()
    {
        SongBook = GameObject.Find("SongBook");
        //Debug.Log("songbook: "+SongBook);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleSongBook(InputAction.CallbackContext SongBookContext)
    {
        
        if (SongBookContext.started == true) 
        {
            if (SongBook != null)
            {
                if (gameObject.GetComponent<PlayerInput>().currentActionMap == new InputActionMap(gameObject.GetComponent<PlayerInput>().defaultActionMap))
                {
                    Debug.Log("FIF");
                    gameObject.GetComponent<PlayerInput>().SwitchCurrentActionMap("UI");
                    Debug.Log(gameObject.GetComponent<PlayerInput>().currentActionMap);
                }
                else 
                {
                    //gameObject.GetComponent<PlayerInput>().SwitchCurrentActionMap("Player");
                    Debug.Log(gameObject.GetComponent<PlayerInput>().currentActionMap);
                }

                SongBook.GetComponent<SongBook>().ToggleBook();
                
                //Debug.Log(gameObject.GetComponent<PlayerInput>().currentActionMap);
            }
        }
    }

}
