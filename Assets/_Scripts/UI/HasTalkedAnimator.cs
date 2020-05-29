using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HasTalkedAnimator : MonoBehaviour
{
    public Transform strikethroughSlider;
    private float strikethroughAmount;
    public float strikeSpeed;

    // Update is called once per frame
    void Update()
    {
        strikethroughSlider.GetComponent<Image>().fillAmount = strikethroughAmount / 100;

        // Radial slider value
        if (strikethroughAmount >= 0)
        {
            strikethroughAmount += strikeSpeed * Time.deltaTime;
        }
    }

    public void ResetUpdate()
    {
        strikethroughSlider.GetComponent<Image>().fillAmount = strikethroughAmount / 100;
        strikethroughAmount = 100;

        // Radial slider value
        if (strikethroughAmount <= 100)
        {
            strikethroughAmount -= strikeSpeed * Time.deltaTime;
        }
    }
}
