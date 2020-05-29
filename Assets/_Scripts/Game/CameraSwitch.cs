using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraSwitch : MonoBehaviour
{
    public GameObject CamInfo;
    public GameObject cameraRing1;
    public GameObject cameraRing2;

    public bool changeToggle;

    private Transform cam;

    Vector3 position1 = new Vector3(0.0f, 4.2f, -6.77f);
    Vector3 rotation1 = new Vector3(16.579f, 0.0f, 0.0f);

    Vector3 position2 = new Vector3(0.0f, 27f, -7.5f);
    Vector3 rotation2 = new Vector3(66.5f, 0.0f, 0.0f);

    void Start()
    {
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            changeToggle = !changeToggle;

            if (changeToggle == true)
            {
                cam.transform.localPosition = position2;
                cam.transform.localRotation = Quaternion.Euler(rotation2);
                cameraRing1.SetActive(false);
                cameraRing2.SetActive(true);
                SFXController.PlaySound("Camera1");
            }
            else
            {
                cam.transform.localPosition = position1;
                cam.transform.localRotation = Quaternion.Euler(rotation1);
                cameraRing1.SetActive(true);
                cameraRing2.SetActive(false);
                SFXController.PlaySound("Camera2");
            }
        }
    }

    public void ResetCameras()
    {
        changeToggle = false;
        cam.transform.localPosition = position1;
        cam.transform.localRotation = Quaternion.Euler(rotation1);
    }

    public void EnableCameras()
    {
        CamInfo.SetActive(true);
    }
}