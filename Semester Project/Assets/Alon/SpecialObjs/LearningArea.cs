using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningArea : MonoBehaviour
{
    public bool inArea = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && other.GetType() == typeof(BoxCollider2D))
        {
            inArea = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && other.GetType() == typeof(BoxCollider2D)) 
        {
            inArea = false;
        }
    }
}
