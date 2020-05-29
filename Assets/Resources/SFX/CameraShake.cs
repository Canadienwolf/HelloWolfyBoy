using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float power = 0.8f;
    public float duration = 1.0f;
    public Transform cameraTransform;
    public float slowDownAmount = 1.0f;
    public bool shouldShake = false;

    Vector3 startPosition;
    float initialDuration;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
        startPosition = cameraTransform.localPosition;
        initialDuration = duration;
    }

    public void StartShake()
    {
        shouldShake = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldShake)
        {
            if(duration > 0)
            {
                cameraTransform.localPosition = startPosition + Random.insideUnitSphere * power;
                duration -= Time.deltaTime * slowDownAmount;
            }
            else
            {
                shouldShake = false;
                duration = initialDuration;
                cameraTransform.localPosition = startPosition;
            }
        }
    }
}
