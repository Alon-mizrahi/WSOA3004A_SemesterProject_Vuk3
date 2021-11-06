using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public bool isOpen = false;
    public bool isClose = false;
    public bool Opened = false;

    public bool StartOpen = false;

    public float OpenSpeed = 1f;
    Vector2 StartPos;
    // Start is called before the first frame update
    void Start()
    {
        StartPos = gameObject.transform.position;
        if (StartOpen == true) 
        {
            StartPos = gameObject.transform.position;
            StartPos.y += 6.5f;
            Opened = true;
            gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (isOpen == true && transform.position.y > StartPos.y-6.5f) 
        //{
         //   transform.position += Vector3.down * Time.deltaTime * OpenSpeed;
        //}

        if (isOpen || isClose) { OpenandClose();  }

    }

    void OpenandClose() 
    {
        if (isOpen == true)
        {
            if (transform.position.y >= StartPos.y - 6.5f)
            {
                gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                transform.position += Vector3.down * Time.deltaTime * OpenSpeed;
            }
            else
            {
                isOpen = false;
                isClose = false;
                Opened = true;
            }
        }
        else if (isClose == true) 
        {
            if (transform.position.y <= StartPos.y)
            {
                gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                transform.position += Vector3.up * Time.deltaTime * OpenSpeed;
            }
            else
            {
                gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                isOpen = false;
                isClose = false;
                Opened = false;
            }
        }
        
        
    }
}
