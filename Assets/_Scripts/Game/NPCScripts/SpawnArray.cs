using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class SpawnArray : MonoBehaviour
{
    // Array used for spawn points
    public Transform[] spawnPoints;

    // Array for NPCs
    [SerializeField] private GameObject[] npcs;

    // Create a new list which contains all possible spawn points
    public List<Transform> possibleSpawns = new List<Transform>();
    public List<NpcInfo> NpcInScene { get; private set; }
    public int Population { get; private set; }


    private int _dayNum;
    private DayNightCycle _dayNightCycle;

    private void Awake()
    {
        spawnPoints = transform.Collect<Transform>().ToArray();
        //Randomizes the array of NPCs
        npcs = npcs.Shuffle();


        //Fetch the information about day it is.

        _dayNightCycle = FindObjectOfType<DayNightCycle>();
        _dayNum = _dayNightCycle.CurrentDay;
        NpcInScene = new List<NpcInfo>();

        // For loop to add all spawn points on start.
        spawnPoints.ToList().ForEach(t => possibleSpawns.Add(t));
        SpawnNpcs();
        Population = NpcInScene.Count;
    }

//    private void Update()
//    {
//        //This is run as soon as the day number is changed
//        if (_dayNum != _dayNightCycle.CurrentDay)
//        {
//            SpawnNpcs();
//        }
//    }

    public void SpawnNpcs()
    {
        possibleSpawns = possibleSpawns.Shuffle();
        if (NpcInScene.Count == 0)
        {
            for (int i = 0; i < npcs.Length; i++)
            {
                NpcInfo npc = Instantiate(npcs[i], possibleSpawns[i].position, Quaternion.identity)
                    .GetComponent<NpcInfo>();
                NpcInScene.Add(npc);
            }
        }
        else
        {
            for (int i = 0; i < npcs.Length; i++)
            {
                npcs[i].transform.position = possibleSpawns[i].position;
            }
        }
    }
}