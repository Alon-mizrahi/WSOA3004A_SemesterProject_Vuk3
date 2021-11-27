using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform Teleport1;
    public Transform Teleport2;
    public GameObject VisFeedback1;
    public GameObject VisFeedback2;

    public bool inT1 = false;
    public bool inT2 = false;

    public bool IsActive = false;
    //GameObject Player;

    // Start is called before the first frame update
    void Awake()
    {
        Teleport1 = transform.GetChild(0);
        Teleport2 = transform.GetChild(1);
        //Player = GameObject.FindGameObjectWithTag("Player");
        VisFeedback1.SetActive(false);
        VisFeedback2.SetActive(false);

    }
    

    /*
    public IEnumerator Teleport(GameObject Object)
    {
        if (IsActive) 
        {
            inT1 = Teleport1.GetComponent<TelportGetPos>().inT1;
            inT2 = Teleport2.GetComponent<TelportGetPos>().inT2;
            VisFeedback1.SetActive(true);
            VisFeedback2.SetActive(true);

            if (inT1)
            {
                Teleport2.GetComponent<BoxCollider2D>().enabled = false;
                Object.transform.position = Teleport2.transform.GetChild(0).position;
                yield return new WaitForSeconds(1f);
                Teleport2.GetComponent<BoxCollider2D>().enabled = true;
            }
            else if (inT2)
            {
                Teleport1.GetComponent<BoxCollider2D>().enabled = false;
                Object.transform.position = Teleport1.transform.GetChild(0).position;
                yield return new WaitForSeconds(1f);
                Teleport1.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }

    */

}
