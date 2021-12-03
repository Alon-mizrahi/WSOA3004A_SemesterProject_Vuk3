using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityMux : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Rigidbody2D>()) 
        {
            other.GetComponent<Rigidbody2D>().mass = 300f;
        }
    }

}
