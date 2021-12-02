using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class ScaleChange : MonoBehaviour
{
    // Start is called before the first frame update
    private enum State {Small, Normal, Large };

    public Vector3 Small;
    Vector3 Normal;
    public Vector3 Large;

    State CurrentSize;


    public bool StartLarge;
    public bool StartSmall;

    
    //change sized in editor
    private void OnDrawGizmos()
    {
        //ChangeSizeInEditor();
    }


    void Start()
    {
        CurrentSize = State.Normal;
        Normal = transform.localScale;
    }

    private void Update()
    {
        ChangeSizeInEditor();
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




    void ChangeSizeInEditor() 
    {
        if (!StartSmall && !StartLarge) 
        {
            StartSmall = false;
            StartLarge = false;

            if (CurrentSize == State.Large)
            {
                DecreaseSize();
            }
            else if (CurrentSize == State.Small)
            {
                IncreaseSize();
            }
        }
        else if (StartLarge && CurrentSize != State.Large)
        {
            StartSmall = false;
            IncreaseSize();
        }
        else if (StartSmall && CurrentSize != State.Small)
        {
            StartLarge = false;
            DecreaseSize();
        }
    }

}
