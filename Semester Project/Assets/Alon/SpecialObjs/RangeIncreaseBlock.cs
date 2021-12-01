using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeIncreaseBlock : MonoBehaviour
{
    float NormalRange;
    public float IncreasedRadius;
    public SpriteRenderer RangeUI;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player") 
        {
            NormalRange = other.gameObject.GetComponent<CircleCollider2D>().radius;
            other.gameObject.GetComponent<CircleCollider2D>().radius = IncreasedRadius;
            RangeUI.transform.localScale = new Vector3(6.2f, 6.2f, 1f);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<CircleCollider2D>().radius = IncreasedRadius;
            RangeUI.transform.localScale = new Vector3(6.2f, 6.2f, 1f);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<CircleCollider2D>().radius = NormalRange;
            RangeUI.transform.localScale = new Vector3(3.2f, 3.2f, 1f);
        }
    }
}
