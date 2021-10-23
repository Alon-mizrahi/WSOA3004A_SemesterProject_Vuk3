using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelportGetPos : MonoBehaviour
{
    public bool inT1 = false;
    public bool inT2 = false;

    public Transform Target1, Target2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && other.GetType() == typeof(BoxCollider2D) || other.tag !="Player") 
        {
            if (gameObject.name == "Teleport1")
            {
                if (transform.parent.GetComponent<Teleporter>().IsActive == true) 
                {
                    inT1 = true;
                    //StartCoroutine(transform.parent.GetComponent<Teleporter>().Teleport(other.gameObject));
                    //transform.parent.GetComponent<Teleporter>().Teleport(other.gameObject);
                    other.gameObject.transform.position = Target2.position;
                }
            }
            else if (gameObject.name == "Teleport2")
            {
                if (transform.parent.GetComponent<Teleporter>().IsActive == true)
                {
                    inT2 = true;
                    //StartCoroutine(transform.parent.GetComponent<Teleporter>().Teleport(other.gameObject));
                    //transform.parent.GetComponent<Teleporter>().Teleport(other.gameObject);
                    other.gameObject.transform.position = Target1.position;
                }
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
