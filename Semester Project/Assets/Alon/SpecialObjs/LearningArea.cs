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
            other.GetComponent<SongDetection>().CurrentLerningArea = gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && other.GetType() == typeof(BoxCollider2D)) 
        {
            inArea = false;
            other.GetComponent<SongDetection>().CurrentLerningArea = null;
        }
    }
}
