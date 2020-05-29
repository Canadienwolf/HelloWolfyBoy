using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NameRotate : MonoBehaviour
{
    public bool changeToggle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            changeToggle = !changeToggle;

            if (changeToggle == true)
            {
                
                transform.rotation = Quaternion.Euler(90, 0, 0);
                transform.localScale += new Vector3(0.25f, 0.25f, 0.25f);
                //var textMesh = GetComponent<TextMeshPro>();
                //textMesh.fontSize = textMesh.fontSize * 2f;
            }
            else
            {
                //transform.localPosition = new Vector3(-1.93f, 2.4f, 0);  
                transform.rotation = Quaternion.Euler(0, 0, 0);
                //var textMesh = GetComponent<TextMeshPro>();
                //textMesh.fontSize = textMesh.fontSize / 2f;
                //transform.localScale = new Vector3(0.22f, 0.12f, 0.28f);

                transform.localScale -= new Vector3(0.25f, 0.25f, 0.25f);
            }
        }
    }
}
