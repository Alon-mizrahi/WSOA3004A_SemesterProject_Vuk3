using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MovablePlatform : MonoBehaviour
{
    //public bool isActive = false;
    public bool MoveHori = false;
    public bool MoveVert = false;

    public Transform LeftBound;
    public Transform RightBound;
    public Transform TopBound;
    public Transform BottomBound;

    //public bool MoveLeftFirst = false;
    public float speed = 0.7f;

    Transform Target;
    string Direc = "";


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
