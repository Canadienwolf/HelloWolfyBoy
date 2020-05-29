using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayInfo : MonoBehaviour
{
    
    private int currentDay;


    public Text dayInfo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentDay = gameObject.GetComponent<DayNightCycle>().CurrentDay;

        if (currentDay == 1)
        {
            //Debug.Log("Day1?");
            dayInfo.text = ("Introduction Day");
        }
        else
        {
            dayInfo.text = ("");
        }
    }
}
