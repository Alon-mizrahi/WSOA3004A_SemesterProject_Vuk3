using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class EditorSize : MonoBehaviour
{
    // Start is called before the first frame update
    ScaleChange SizeScript;

    public bool StartSmall, StartLarge;
    
    void Start()
    {
        
    }

    
    // Update is called once per frame
    void Update()
    {
        if (!EditorApplication.isPlaying)
        {
            Debug.Log("3");
        }


        if (!EditorApplication.isPlaying) 
        {
        if (SizeScript == null) 
        {
            SizeScript = gameObject.GetComponent<ScaleChange>();
        }

        if (Application.isEditor)
        {
            ChangeSizeInEditor();
        }
        }

        
    }

    void ChangeSizeInEditor()
    {
        if (!EditorApplication.isPlaying)
        {
            if (!StartSmall && !StartLarge)
            {
                StartSmall = false;
                StartLarge = false;


                if (SizeScript.CurrentSize == ScaleChange.State.Large)
                {
                    SizeScript.DecreaseSize();
                }
                else if (SizeScript.CurrentSize == ScaleChange.State.Small)
                {
                    SizeScript.IncreaseSize();
                }
            }
            else if (StartLarge && SizeScript.CurrentSize != ScaleChange.State.Large)
            {
                StartSmall = false;
                SizeScript.IncreaseSize();
            }
            else if (StartSmall && SizeScript.CurrentSize != ScaleChange.State.Small)
            {
                StartLarge = false;
                SizeScript.DecreaseSize();
            }
        }
    }



}
