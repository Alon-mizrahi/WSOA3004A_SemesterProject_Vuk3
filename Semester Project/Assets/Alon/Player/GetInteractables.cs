using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetInteractables : MonoBehaviour
{
    public GameObject[] Interactables = new GameObject[10];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Interactable") 
        {
            for (int i = 0; i < Interactables.Length; i++) 
            {
                if (Interactables[i] == null) 
                {
                    Interactables[i] = other.gameObject;
                    break;
                }
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Interactable")
        {
            for (int i = 0; i < Interactables.Length; i++)
            {
                if (Interactables[i] == other.gameObject)
                {
                    Interactables[i] = null;
                    break;
                }
            }
        }
    }




}
