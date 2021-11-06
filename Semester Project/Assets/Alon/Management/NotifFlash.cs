using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NotifFlash : MonoBehaviour
{
    public float delay = 0.7f;

    public GameObject NotifGpad;
    public GameObject NotifMandK;

    public PlayerInput PI;

    bool called = false;

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf == true && called == false) 
        {
            StartCoroutine("Flash");
        }
    }

    public IEnumerator Flash() 
    {
        called = true;
        Debug.Log("Called");

        if (PI.currentControlScheme == "Gamepad") 
        {
            NotifGpad.SetActive(true);
            yield return new WaitForSeconds(delay);//delay
            NotifGpad.SetActive(false);
            yield return new WaitForSeconds(delay);//delay
        }
        else if (PI.currentControlScheme == "Keyboard&Mouse") 
        {
            NotifMandK.SetActive(true);
            yield return new WaitForSeconds(delay);//delay
            NotifMandK.SetActive(false);
            yield return new WaitForSeconds(delay);//delay
        }

        called = false;
    }
}
