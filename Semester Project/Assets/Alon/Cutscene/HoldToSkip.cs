using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HoldToSkip : MonoBehaviour
{
    public float Timer;
    public bool Holding = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Holding)
        {
            Timer = Time.time;
        }

    }

    public void HoldSikp(InputAction.CallbackContext HoldContext) 
    {


        if (HoldContext.started) 
        {
            Holding = true;
        }

        if (HoldContext.canceled)
        {
            Holding = false;
        }


    }


}
