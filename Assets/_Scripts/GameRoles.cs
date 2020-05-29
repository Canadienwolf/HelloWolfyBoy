using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using _Scripts.StoryValuesScripts;

public static class GameRoles
{
    //test
    public static NpcInfo Wolf;
    public static NpcInfo Victim;
    public static NpcInfo Protectant;

    public static List<NpcInfo> VictimLocationClueNpcs = new List<NpcInfo>();
    public static List<NpcInfo> MurderLocationClueNpcs = new List<NpcInfo>();
    public static List<NpcInfo> MurderClueNpcs = new List<NpcInfo>();


    public static List<LocationClue> VictimLocationClues = new List<LocationClue>();
    public static List<LocationClue> MurderLocationClues = new List<LocationClue>();
    public static List<PhysicalClue> MurderClues = new List<PhysicalClue>();

    public static void StartNewGame()
    {
        Wolf = null;
        Victim = null;
        Protectant = null;
        VictimLocationClueNpcs = new List<NpcInfo>();
        MurderLocationClueNpcs = new List<NpcInfo>();
        MurderClueNpcs = new List<NpcInfo>();

        VictimLocationClues = new List<LocationClue>();
        MurderLocationClues = new List<LocationClue>();
        MurderClues = new List<PhysicalClue>();
    }

//    public static List<NpcInfo> VictimLocationClueNpcs = new List<NpcInfo>();
//    public static List<NpcInfo> VictimLocationClueNpcs = new List<NpcInfo>();
}