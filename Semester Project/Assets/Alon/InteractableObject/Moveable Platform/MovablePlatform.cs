using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MovablePlatform : MonoBehaviour
{

    public bool MoveHori = false;
    public bool MoveVert = false;


    public float speed = 0.7f;

    string DirecX = "";
    string DirecY = "";

    //New Method
    Vector2 StartPos;

    BoxCollider2D Boundary;

    float UpperBound;
    float LowerBound;
    float LeftBound;
    float RightBound;


    public bool StartMoveLeft = false;
    public bool StartMoveDown = false;

    private void Start()
    {
        StartPos = transform.parent.position;


        Boundary = gameObject.transform.parent.GetComponent<BoxCollider2D>();


        LeftBound = StartPos.x + Boundary.offset.x - Boundary.size.x / 2;
        RightBound = StartPos.x + Boundary.offset.x + Boundary.size.x / 2;

        UpperBound = StartPos.y + Boundary.offset.y + Boundary.size.y / 2;
        LowerBound = StartPos.y + Boundary.offset.y - Boundary.size.y / 2;

        //LeftBound = -Boundary.bounds.max.x;
        


        if (StartMoveLeft == true) { DirecX = "Left"; }
        else { DirecX = "Right"; }

        if (StartMoveDown == true) { DirecY = "Down"; }
        else { DirecY = "Up"; }


        //Debug.Log("UpperBound "+ UpperBound);
        //Debug.Log("LowerBound " + LowerBound);
        //Debug.Log("LeftBound " + LeftBound);
        //Debug.Log("RightBound " + RightBound);

        //Debug.Log("DirecX " + DirecX);
        //Debug.Log("DirecY " + DirecY);


    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (MoveHori == true)
        {
            MoveVert = false;
            Movement("Horizontal");
        }
        else if (MoveVert == true)
        {
            MoveHori = false;
            Movement("Vertical");
        }
    }


    void Movement(string Axis)
    {
        if (Axis == "Horizontal")//horizontal movement
        {
            if (gameObject.transform.position.x <= LeftBound)//if at left bound move right
            {
                DirecX = "Right";
                Debug.Log(gameObject.transform.position.x);
            }
            else if (gameObject.transform.position.x >= RightBound)//if at right bound move left
            {
                DirecX = "Left";
                Debug.Log(gameObject.transform.position.x);
            }

            if (DirecX == "Left")
            { transform.Translate(Vector2.left * speed * Time.deltaTime); }
            else if (DirecX == "Right") { transform.Translate(Vector2.right * speed * Time.deltaTime); }
        }

        else if (Axis == "Vertical")
        {
            if (gameObject.transform.position.y <= LowerBound)//if at left bound move right
            {
                DirecY = "Up";
            }
            else if (gameObject.transform.position.y >= UpperBound)//if at right bound move left
            {
                DirecY = "Down";
            }

            if (DirecY == "Up")
            { transform.Translate(Vector2.up * speed * Time.deltaTime); }
            else if (DirecY == "Down") { transform.Translate(Vector2.down * speed * Time.deltaTime); }
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other);

        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.SetParent(transform);
        }
        if (other.gameObject.name.Contains("Door") == true || other.gameObject.GetComponent<CompositeCollider2D>() == true || other.gameObject.name.Contains("Interactable_MovablePlatform") == true)
        {
            if (MoveHori == true) 
            {
                if (DirecX == "Left") { DirecX = "Right"; }
                else if (DirecX == "Right") { DirecX = "Left"; }
            }
            else if (MoveVert == true) 
            {
                if (DirecY == "Up") { DirecY = "Down"; }
                else if (DirecY == "Down") { DirecY = "Up"; }
            }
        }
    }

    //private void OnCollisionStay2D(Collision2D other)
    //{
        //if (other.gameObject.tag == "Player" && other.transform.parent == gameObject.transform)
        //{
        //    other.gameObject.transform.lossyScale = new Vector3(1f, 1f, 1f);
        //}
    //}

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.parent = null;
        }
    }


}




/*
    void Movement(string Axis) 
    {
        if (Axis == "Horizontal")//horizontal movement
        {
            if (gameObject.transform.position.x <= LeftBound.transform.position.x)//if at left bound move right
            {
                Direc = "Right";
            }
            else if (gameObject.transform.position.x >= RightBound.transform.position.x)//if at right bound move left
            {
                Direc = "Left";
            }

            if (Direc == "Left") 
            { transform.Translate(Vector2.left*speed*Time.deltaTime); }
            else if (Direc == "Right") { transform.Translate(Vector2.right * speed * Time.deltaTime); }
        }


        else if (Axis == "Vertical") 
        {
            if (gameObject.transform.position.y <= BottomBound.transform.position.y)//if at left bound move right
            {
                Direc = "Up";
            }
            else if (gameObject.transform.position.y >= TopBound.transform.position.y)//if at right bound move left
            {
                Direc = "Down";
            }

            if (Direc == "Up")
            { transform.Translate(Vector2.up * speed * Time.deltaTime); }
            else if (Direc == "Down") { transform.Translate(Vector2.down * speed * Time.deltaTime); }

        }

    }



    private void OnCollisionEnter2D(Collision2D other)
    {

        Debug.Log(other);

        if (other.gameObject.tag == "Player") 
        {
            other.gameObject.transform.SetParent(transform);
        }
        if (other.gameObject.name.Contains("Door") == true || other.gameObject.GetComponent<TilemapCollider2D>() == true || other.gameObject.name.Contains("Interactable_MovablePlatform") == true) 
        {
            if (Direc == "Left") { Direc = "Right"; }
            else if (Direc == "Right") { Direc = "Left"; }
            else if (Direc == "Up") { Direc = "Down"; }
            else if (Direc == "Down") { Direc = "Up"; }
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.parent = null;
        }
    }




}
*/