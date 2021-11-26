using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    //flute audio
    public AudioClip flute1;
    public AudioClip flute2;
    public AudioClip flute3;
    public AudioClip flute4;
    public AudioSource AS;


    Controls PlayerContSys;

    [SerializeField]Rigidbody2D PLYRB;
    [SerializeField] float JumpForce, MoveSpeed;
    float XInput;
    public LayerMask GroundLayer;
    public Transform GroundCheck;
    float JumpCheckDist = 0.45f;
    public bool Ground, MusicBlock;
    public Animator PlayerAnimator;

    Vector2 JumpVect;

    private void Start()
    {
        JumpVect = new Vector2(0, JumpForce);
    }

    private void Update()
    {
        PLYRB.velocity = new Vector2(XInput * MoveSpeed, PLYRB.velocity.y);
        Ground = Physics2D.OverlapCircle(GroundCheck.position, JumpCheckDist, GroundLayer);
        Land();

        //JumpVect = new Vector2(0, JumpForce); for testing
    }

    public void Move(InputAction.CallbackContext XContext)
    {
        XInput = XContext.ReadValue<Vector2>().x;

        if (XInput < 0) 
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
            PlayerAnimator.SetBool("Move", true);
        }
        else if(XInput > 0)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            PlayerAnimator.SetBool("Move", true);
        }
        if(XContext.canceled)
        {
            PlayerAnimator.SetBool("Move", false);
        }

    }

    public void Jump(InputAction.CallbackContext JumpContext)
    {
        if (JumpContext.performed && Ground && gameObject.GetComponent<PlayerTutorial>().CurrentTut == null)
        {
            PlayerAnimator.SetBool("Midair", true);
            //PLYRB.velocity = new Vector2(PLYRB.velocity.x, JumpForce);

            PLYRB.AddForce(JumpVect, ForceMode2D.Impulse);
            //Debug.Log("Jumped");
        }
        
        else if (JumpContext.started && gameObject.GetComponent<PlayerTutorial>().CurrentTut != null) 
        {
            if (gameObject.GetComponent<PlayerTutorial>().FirstRound) 
            {
                gameObject.GetComponent<PlayerInput>().SwitchCurrentActionMap("Tutorial");
                Debug.Log(gameObject.GetComponent<PlayerInput>().currentActionMap);
                gameObject.GetComponent<PlayerTutorial>().ActivateTutorial();
            }
            
        }
        
    }
    public void Land()
    {
        if (Ground)
        {
            PlayerAnimator.SetBool("Midair", false);
        }
        else
        {
            PlayerAnimator.SetBool("Midair", true);
        }
    }
    public void RedUpNote(InputAction.CallbackContext RedContext)
    {
        if (RedContext.started == true && MusicBlock == false)
        {
            //Debug.Log("Red!");
            if (gameObject.GetComponent<SongDetection>() != null)
            {
                gameObject.GetComponent<SongDetection>().GetNote("Up");
            }
            AS.clip = flute1;
            AS.Play();
        }
        if (RedContext.performed == true && MusicBlock == false) 
        {
            AS.loop = true;
        }
        if (RedContext.canceled == true) 
        {
            AS.loop = false;
            //AS.Stop();
        }
    }

    public void OrangeDownNote(InputAction.CallbackContext OrangeContext)
    {
        if (OrangeContext.started == true && MusicBlock == false)
        {
            //Debug.Log("Orange!");
            if (gameObject.GetComponent<SongDetection>() != null)
            {
                gameObject.GetComponent<SongDetection>().GetNote("Down");
            }
            AS.clip = flute3;
            AS.Play();
        }
        if (OrangeContext.performed == true && MusicBlock == false)
        {
            AS.loop = true;
        }
        if (OrangeContext.canceled == true)
        {
            AS.loop = false;
            //AS.Stop();
        }
    }

    public void BlueRightNote(InputAction.CallbackContext BlueContext)
    {
        if (BlueContext.started == true && MusicBlock == false) 
        {
            //Debug.Log("Blue!");
            if (gameObject.GetComponent<SongDetection>() != null)
            {
                gameObject.GetComponent<SongDetection>().GetNote("Right");
            }
            AS.clip = flute2;
            AS.Play();
        }
        if (BlueContext.performed == true && MusicBlock == false)
        {
            AS.loop = true;
        }
        if (BlueContext.canceled == true)
        {
            AS.loop = false;
            //AS.Stop();
        }
    }

    public void GreenLeftNote(InputAction.CallbackContext GreenContext)
    {
        if (GreenContext.started == true && MusicBlock == false)
        {
            //Debug.Log("Green!");
            if (gameObject.GetComponent<SongDetection>() != null)
            {
                gameObject.GetComponent<SongDetection>().GetNote("Left");
            }
            AS.clip = flute4;
            AS.Play();
        }
        if (GreenContext.performed == true && MusicBlock == false)
        {
            AS.loop = true;
        }
        if (GreenContext.canceled == true)
        {
            AS.loop = false;
            //AS.Stop();
        }
    }

    private void OnCollisionEnter2D(Collision2D MusicBlocker)
    {

        if (MusicBlocker.gameObject.CompareTag("Music Block"))
        {
            MusicBlock = true;
        }
    }

    private void OnCollisionExit2D(Collision2D MusicEnabler)
    {

        if (MusicEnabler.gameObject.CompareTag("Music Block"))
        {
            MusicBlock = false;
        }
    }

}
