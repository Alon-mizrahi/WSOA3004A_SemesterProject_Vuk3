using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleChange : MonoBehaviour
{
    // Start is called before the first frame update
    private enum State {Small, Normal, Large };

    public Vector3 Small;
    Vector3 Normal;
    public Vector3 Large;

    State CurrentSize;

    void Start()
    {
        CurrentSize = State.Normal;
        Normal = transform.localScale;
    }

    public void IncreaseSize() 
    {
        if (CurrentSize == State.Small)
        {
            transform.localScale = Normal;
            if (gameObject.GetComponent<Rigidbody2D>() != null) { gameObject.GetComponent<Rigidbody2D>().mass *= 2; }
            CurrentSize = State.Normal;
        }
        else if (CurrentSize == State.Normal)
        {
            transform.localScale = Large;
            if (gameObject.GetComponent<Rigidbody2D>() != null) { gameObject.GetComponent<Rigidbody2D>().mass *= 2; }
            CurrentSize = State.Large;
        }
    }

    public void DecreaseSize() 
    {
        if (CurrentSize == State.Large)
        {
            transform.localScale = Normal;
            if (gameObject.GetComponent<Rigidbody2D>() != null) { gameObject.GetComponent<Rigidbody2D>().mass /= 2; }
            CurrentSize = State.Normal;
        }
        else if (CurrentSize == State.Normal)
        {
            transform.localScale = Small;
            if (gameObject.GetComponent<Rigidbody2D>() != null) { gameObject.GetComponent<Rigidbody2D>().mass /= 2; }
            CurrentSize = State.Small;
        }
    }


}
