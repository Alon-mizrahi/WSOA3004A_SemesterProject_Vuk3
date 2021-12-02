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

    //New jump things
    public float FallMux = 2.5f;
    public float LowJumpMux = 2f;
    bool isJump = false;
    


    //Walk and Jump Sounds
    public AudioSource PlayerAudio;
    public AudioClip Footsteps, JumpSound;

    public bool isWalking = false;
    public bool SetWalk = false;
    public bool WalkButton = false;

    //No Music Block
    public SpriteRenderer RangeUI;
    SongDetection CurSong;

    private void Start()
    {
        CurSong = gameObject.GetComponent<SongDetection>();
        PLYRB = gameObject.GetComponent<Rigidbody2D>();
        JumpVect = new Vector2(0, JumpForce);
    }

    private void Update()
    {
        PLYRB.velocity = new Vector2(XInput * MoveSpeed, PLYRB.velocity.y);
        Ground = Physics2D.OverlapCircle(GroundCheck.position, JumpCheckDist, GroundLayer);
        Land();

        //JumpVect = new Vector2(0, JumpForce); for testing
        if (Ground && WalkButton) { isWalking = true; }
        else { isWalking = false; SetWalk = false; }

        if (isWalking && SetWalk == false) { SetWalk = true; StartFootSteps(); }

        //if(Ground == false) { StopFootSteps(); }


        //new Jump Things
        if (PLYRB.velocity.y < 0)
        {
            PLYRB.velocity += Vector2.up * Physics2D.gravity.y * (FallMux - 1) * Time.deltaTime;
        }
        else if (PLYRB.velocity.y > 0 && isJump ==false) 
        {
            PLYRB.velocity += Vector2.up * Physics2D.gravity.y * (LowJumpMux - 1) * Time.deltaTime;
        }


        //MusicBlock Things
        if (MusicBlock) 
        {
            if (RangeUI.enabled) 
            {
                RangeUI.enabled = false;
            }
            if (CurSong.CurrentSong != null) 
            {
                CurSong.ClearSong();
            }
        }


    }

    public void Move(InputAction.CallbackContext XContext)
    {
        XInput = XContext.ReadValue<Vector2>().x;

        if (XContext.started && Ground) 
        {
            WalkButton = true;
            //StartFootSteps();
        }

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
            PlayerAudio.Stop();
            WalkButton = false;
        }

    }



    public void Jump(InputAction.CallbackContext JumpContext)
    {
        if (JumpContext.performed && Ground && gameObject.GetComponent<PlayerTutorial>().CurrentTut == null)
        {
            PlayerAnimator.SetBool("Midair", true);
            isJump = true;
            
            PLYRB.velocity = new Vector2(PLYRB.velocity.x, JumpForce);

            //PLYRB.AddForce(JumpVect, ForceMode2D.Impulse);
            //Debug.Log("Jumped");
            
            
            //if (isWalking) { StopFootSteps(); }
            PlayerAudio.clip = JumpSound;
            PlayerAudio.loop = false;
            PlayerAudio.Play();

            //SetWalk = false;
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

        if (JumpContext.canceled) { isJump = false; }


        
    }

    void StartFootSteps() 
    {
        PlayerAudio.clip = Footsteps;
        PlayerAudio.loop = true;
        PlayerAudio.Play();
    }
    void StopFootSteps()
    {
        PlayerAudio.Stop();
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
