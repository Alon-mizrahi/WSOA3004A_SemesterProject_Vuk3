using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePlatform : MonoBehaviour
{
    public bool isActive = false;
    public Transform LeftBound;
    public Transform RightBound;
    //public bool MoveLeftFirst = false;
    public float speed = 0.7f;

    Transform Target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isActive == true) 
        {
            Movement();
        }
    }

    void Movement() 
    {
        //transform.position = Vector2.MoveTowards(transform.position, RightBound.position, Time.deltaTime * speed);

        if (transform.localPosition == RightBound.localPosition) 
        {
            //transform.localPosition = Vector2.MoveTowards(transform.localPosition, LeftBound.localPosition, Time.deltaTime * speed);
            Target = LeftBound;
        }
        if (transform.localPosition == LeftBound.localPosition)
        {
            Target = RightBound;
        }

        transform.localPosition = Vector2.MoveTowards(transform.localPosition, Target.localPosition, Time.deltaTime * speed);

    }

}
