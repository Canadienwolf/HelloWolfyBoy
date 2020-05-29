using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformPlayer : MonoBehaviour {

    public GameObject target;
    public GameObject player;
    public Camera cam;
    public bool inside;
    public bool isSidways;

    bool hitPortal = false;
    float isInside = -1;
    Vector2 tg;

    private void Awake()
    {
        tg = target.transform.position;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            if (isSidways)
            {
                if (inside)
                {
                    isInside = -1;
                    hitPortal = true;
                    player.transform.position = tg + new Vector2(isInside * 0.7f, 0f);
                    cam.transform.position = tg;
                    Invoke("SetBoolBack", 0.5f);
                }
                else if (!inside)
                {
                    isInside = 1;
                    hitPortal = true;
                    player.transform.position = tg + new Vector2(isInside * 0.7f, 0f);
                    cam.transform.position = tg;
                    Invoke("SetBoolBack", 0.5f);
                }
            }
            else if(!isSidways)
            {
                if (inside)
                {
                    isInside = -1;
                    hitPortal = true;
                    player.transform.position = tg + new Vector2(0f, isInside * 0.7f);
                    cam.transform.position = tg;
                    Invoke("SetBoolBack", 0.5f);
                }
                else if (!inside)
                {
                    isInside = 1;
                    hitPortal = true;
                    player.transform.position = tg + new Vector2(0f, isInside * 0.7f);
                    cam.transform.position = tg;
                    Invoke("SetBoolBack", 0.5f);
                }
            }

            
        }
    }

    void SetBoolBack()
    {
        hitPortal = false;
    }
}