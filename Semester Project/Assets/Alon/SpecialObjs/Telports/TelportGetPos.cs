using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelportGetPos : MonoBehaviour
{
    public bool inT1 = false;
    public bool inT2 = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && other.GetType() == typeof(BoxCollider2D) || other.tag !="Player") 
        {
            if (gameObject.name == "Teleport1")
            {
                inT1 = true;
                StartCoroutine(transform.parent.GetComponent<Teleporter>().Teleport(other.gameObject));
            }
            else if (gameObject.name == "Teleport2")
            {
                inT2 = true;
                StartCoroutine(transform.parent.GetComponent<Teleporter>().Teleport(other.gameObject));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player" && other.GetType() == typeof(BoxCollider2D))
        {
            if (gameObject.name == "Teleport1")
            {
                inT1 = false;
            }
            else if (gameObject.name == "Teleport2")
            {
                inT2 = false;
            }
        }
    }


}
