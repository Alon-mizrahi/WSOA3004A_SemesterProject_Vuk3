using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalObstical : MonoBehaviour
{
    public bool CrystalComplete = false;
    public float OpenSpeed = 1f;
    Vector2 StartPos;
    // Start is called before the first frame update
    void Start()
    {
        StartPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if (isOpen == true && transform.position.y > StartPos.y-6.5f) 
        //{
        //   transform.position += Vector3.down * Time.deltaTime * OpenSpeed;
        //}

        if (CrystalComplete == true) { OpenandClose(); }

    }

    void OpenandClose()
    {
            if (transform.position.y >= StartPos.y - 10f)
            {
                //gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                transform.position += Vector3.down * Time.deltaTime * OpenSpeed;
            }
            else
            {
                CrystalComplete = false;
            }
    }
}
