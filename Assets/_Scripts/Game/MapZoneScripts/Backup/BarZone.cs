using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*public class BarZone : MonoBehaviour
{
    public Text mapZoneText;

    public GameObject faceCamera;
    public GameObject cameraRing1;
    public GameObject topdownCamera;
    public GameObject cameraRing2;

    public string placeName;

    void OnEnable()
    {
        placeName = gameObject.name;
        //GameObject.Find("MapZones").GetComponent<ZonesOnMap>().location.Add(placeName);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            mapZoneText.text = "Bar";
            GameObject.Find("Player").GetComponent<CameraSwitch>().ResetCameras();
            GameObject.Find("Player").GetComponent<CameraSwitch>().enabled = false;
            topdownCamera.SetActive(false);
            cameraRing1.SetActive(true);
            cameraRing2.SetActive(false);
        }


        if (other.gameObject.CompareTag("NPC"))
        {
//            other.gameObject.GetComponent<HasTalked>().currentLocation = placeName;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            mapZoneText.text = "Forest";
            GameObject.Find("Player").GetComponent<CameraSwitch>().enabled = true;
            GameObject.Find("Player").GetComponent<CameraSwitch>().EnableCameras();
            topdownCamera.SetActive(true);
            cameraRing1.SetActive(true);
            cameraRing2.SetActive(false);
        }

    }
}
*/