using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeIncreaseBlock : MonoBehaviour
{
    float NormalRange;
    public float IncreasedRadius;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player") 
        {
            NormalRange = other.gameObject.GetComponent<CircleCollider2D>().radius;
            other.gameObject.GetComponent<CircleCollider2D>().radius = IncreasedRadius;
            
            //increase range sprite as well

        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<CircleCollider2D>().radius = NormalRange;
        }
    }
}
