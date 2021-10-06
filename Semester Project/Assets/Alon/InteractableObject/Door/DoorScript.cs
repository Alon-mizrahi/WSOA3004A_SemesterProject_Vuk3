using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public bool isOpen = false;
    public float OpenSpeed = 0.5f;
    Vector2 StartPos;
    // Start is called before the first frame update
    void Start()
    {
        StartPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen == true && transform.position.y > StartPos.y-3.5f) 
        {
            transform.position += Vector3.down * Time.deltaTime * OpenSpeed;
        }
    }
}
