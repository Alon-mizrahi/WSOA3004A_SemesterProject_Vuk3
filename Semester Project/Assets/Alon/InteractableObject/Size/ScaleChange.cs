using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class ScaleChange : MonoBehaviour
{
    // Start is called before the first frame update
    public enum State {Small, Normal, Large };

    public Vector3 Small;
    public Vector3 Normal;
    public Vector3 Large;

    public State CurrentSize;

    //EditorSize ES;

    void Start()
    {
        //ES = gameObject.GetComponent<EditorSize>();
        //CurrentSize = State.Normal;
        //Normal = transform.localScale;
    }


    public void IncreaseSize() 
    {
            //Debug.Log("SCALE CHANGE");

        if (CurrentSize == State.Small)
        {
            transform.localScale = Normal;
            if (gameObject.GetComponent<Rigidbody2D>() != null) { gameObject.GetComponent<Rigidbody2D>().mass *= 2; }
            CurrentSize = State.Normal;
        }
        else if (CurrentSize == State.Normal)
        {

                //ES.StartLarge = true;

            //Debug.Log("SCALE NORMAL");
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

               // ES.StartSmall = true;

            transform.localScale = Small;
                if (gameObject.GetComponent<Rigidbody2D>() != null) { gameObject.GetComponent<Rigidbody2D>().mass /= 2; }
                CurrentSize = State.Small;
            }
    }

}
