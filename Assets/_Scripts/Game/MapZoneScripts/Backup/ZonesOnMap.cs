using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

/*public class ZonesOnMap : MonoBehaviour
{
    public List<GameObject> location = new List<GameObject>();
    private List<GameObject> npcs = new List<GameObject>();

    //private List<string>[,] npcAndLocations;
    private string[,] npcAndLocations;
    private string[,] tempNAL;

    // Start is called before the first frame update
    void Start()
    {
        location.AddRange(GameObject.FindGameObjectsWithTag("Locations"));
        
        Invoke("LateStart", 0.2f);
    }

    void LateStart()
    {
        npcs = new List<GameObject>();
        npcs.AddRange(GameObject.FindGameObjectsWithTag("NPC")); 
        //npcAndLocations = new List<string>[npcs.Count, GameObject.Find("GUI").GetComponent<DayNightCycle>().number];
        npcAndLocations = new string[npcs.Count,GameObject.Find("GUI").GetComponent<DayNightCycle>().CurrentDay];
        for (int i = 0; i < npcs.Count; i++)
        {
            for (int j = 0; j < GameObject.Find("GUI").GetComponent<DayNightCycle>().CurrentDay; j++)
            {
                if (npcAndLocations[i,j] == null)
                {
//                    npcAndLocations[i, j] =  npcs[i].GetComponent<HasTalked>().currentLocation;
//                    print(npcs[i].name + ": " + npcAndLocations[i,j]);
                }
            }
        }
    }
    
    public void ClearAndAddNPC()
    {
        tempNAL = npcAndLocations;
        npcAndLocations = new string[npcs.Count,GameObject.Find("GUI").GetComponent<DayNightCycle>().CurrentDay];
        
        for (int i = 0; i < npcs.Count; i++)
        {
            for (int j = 0; j < GameObject.Find("GUI").GetComponent<DayNightCycle>().CurrentDay - 1; j++)
            {
                npcAndLocations[i, j] = tempNAL[i, j];
            }
        }
        
        npcs = new List<GameObject>();
        npcs.AddRange(GameObject.FindGameObjectsWithTag("NPC")); 
        for (int i = 0; i < npcs.Count; i++)
        {
            for (int j = 0; j < GameObject.Find("GUI").GetComponent<DayNightCycle>().CurrentDay; j++)
            {
                if (npcAndLocations[i,j] == null)
                {
//                    npcAndLocations[i, j] =  npcs[i].GetComponent<HasTalked>().currentLocation;
                    print(npcs[i].name + ": " + npcAndLocations[i,j]);
                }
            }
        }
    }

    public void ChangeNPCLocation(string npcName)
    {
        int x = 0;
        
        for (int i = 0; i < npcs.Count; i++)
        {
            if (npcs[i].name == npcName)
            {
                x = i;
            }
        }

        DialogueLua.SetVariable(npcName, npcAndLocations[x, GameObject.Find("GUI").GetComponent<DayNightCycle>().CurrentDay - 1]);
    }
}
*/