using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Controls PlayerContSys;

    [SerializeField]Rigidbody2D PLYRB;
    [SerializeField] float JumpForce, MoveSpeed;
    float XInput;
    public LayerMask GroundLayer;
    public Transform GroundCheck;
    float JumpCheckDist = 0.45f;
    public bool Ground;


    private void Update()
    {
        PLYRB.velocity = new Vector2(XInput * MoveSpeed, PLYRB.velocity.y);
        Ground = Physics2D.OverlapCircle(GroundCheck.position, JumpCheckDist, GroundLayer);
    }

    public void Move(InputAction.CallbackContext XContext)
    {
        XInput = XContext.ReadValue<Vector2>().x;
        
    }

    public void Jump(InputAction.CallbackContext JumpContext)
    {
        if (JumpContext.performed && Ground)
        {
            PLYRB.velocity = new Vector2(PLYRB.velocity.x, JumpForce);
            Debug.Log("Jumped");
        }
        
    }
    public void RedUpNote(InputAction.CallbackContext RedContext)
    {
        if (RedContext.started == true)
        {
            Debug.Log("Red!");
            if (gameObject.GetComponent<SongDetection>() != null)
            {
                gameObject.GetComponent<SongDetection>().GetNote("Up");
            }
        }
    }

    public void OrangeDownNote(InputAction.CallbackContext OrangeContext)
    {
        if (OrangeContext.started == true)
        {
            Debug.Log("Orange!");
            if (gameObject.GetComponent<SongDetection>() != null)
            {
                gameObject.GetComponent<SongDetection>().GetNote("Down");
            }
        }
    }

    public void BlueRightNote(InputAction.CallbackContext BlueContext)
    {
        if (BlueContext.started == true) 
        {
            Debug.Log("Blue!");
            if (gameObject.GetComponent<SongDetection>() != null)
            {
                gameObject.GetComponent<SongDetection>().GetNote("Right");
            }
        }
    }

    public void GreenLeftNote(InputAction.CallbackContext GreenContext)
    {
        if (GreenContext.started == true)
        {
            Debug.Log("Green!");
            if (gameObject.GetComponent<SongDetection>() != null)
            {
                gameObject.GetComponent<SongDetection>().GetNote("Left");
            }
        }
    }


}
