using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{

    public GameObject Camera;

    // Start is called before the first frame update
    void Start()
    {

        //transform.Rotate( 180,0,0 );
    }

    // Update is called once per frame
    void Update()
    {

         //Change so that there is just one camera.
        Camera = GameObject.FindGameObjectWithTag("MainCamera");

            Vector3 v = Camera.transform.position - transform.position;
            v.x = v.z = 0.0f;
            transform.LookAt(Camera.transform.position - v);
            transform.Rotate(0, 180, 0);

    }
}

