using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{

    [Header("Cursor control")]
    public bool isCursorEnabled;
    public GameObject cursorMode;

    [Header("Scrollwheel zooming")]
    public float zoomSensitivity = 15.0f;
    public float zoomSpeed = 5.0f;
    public float zoomMin = 5.0f;
    public float zoomMax = 80.0f;

    private float zoom;

    [Header("Camera rotation")]
    public Transform rotationTarget;
    public float rotationSensitivity = 0.2f;
    int rotationDegree = 10;
    //public float rotationSmoothness = 5.0f;


    void Start()
    {
        zoom = Camera.main.fieldOfView;
    }

    void Update()
    {

        // Camera rotation
        if (!isCursorEnabled)
        {
            transform.RotateAround(rotationTarget.position, Vector3.up, Input.GetAxis("Mouse X") * rotationDegree * rotationSensitivity);
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(1))
        {
            isCursorEnabled = !isCursorEnabled;

            if (isCursorEnabled)
            {
                EnableCursor();
            }
            else
            {
                DisableCursor();
            }
        }


        // Camera zooming
        zoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSensitivity;
        zoom = Mathf.Clamp(zoom, zoomMin, zoomMax);
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, zoom, Time.deltaTime * zoomSpeed);

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            SFXController.PlaySound("CameraZoomIn");
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            SFXController.PlaySound("CameraZoomOut");
        }
    }


    public void EnableCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        isCursorEnabled = true;
        SFXController.PlaySound("CameraRotate");
        cursorMode.SetActive(true);
    }

    public void DisableCursor()
    {

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        isCursorEnabled = false;
        SFXController.PlaySound("CameraStopRotate");
        cursorMode.SetActive(false);
    }



public void ResetCameraZoom()
    {
        zoom = 50f;
    }
    public void ResetCameraRotation()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
