using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;
using TMPro;
using _Scripts.StoryValuesScripts;


public class NpcInfo : MonoBehaviour
{
    private HasTalkedIndicator hasTalkedIndicator;
    private GameObject guiltyScreenButton;
    private string npcInfo;
    private bool isWolf;
    private bool _hasTalked = false;
    public string location;

    public string FirstName => name.Split(' ')[0];
    public string FullName => name;

    public string VictimLocationClue { get; set; }
    public string MurderLocationClue { get; set; }
    public string MurderClue { get; set; }

    public bool HasTalked
    {
        get => _hasTalked;
        private set
        {
            hasTalkedIndicator.Striked(value);
            _hasTalked = value;
        }
    }

    private void Awake()
    {
        name = name.Replace("(Clone)", "");
        hasTalkedIndicator = FindObjectOfType<HasTalkedIndicators>().AddIndicator(FirstName);
        GetComponentInChildren<TextMeshPro>().text = FullName;
        GetComponentInChildren<Usable>().overrideName = FullName;
    }

    public void NextDay()
    {
        HasTalked = false;
        VictimLocationClue = "";
        MurderClue = "";
        MurderLocationClue = "";
    }

    public static void KillNpc(NpcInfo npc)
    {
        GameManager.Instance.SpawnArray.NpcInScene.Remove(npc);
        FindObjectOfType<HasTalkedIndicators>().RemoveIndicator(npc.hasTalkedIndicator);
        Destroy(npc.gameObject);
    }

    public void TalkedTo(string talkedTag)
    {
        if (!_hasTalked && talkedTag == "Player")
        {
            HasTalked = true;
            GameManager.Instance.HasTalked();

            SFXController.PlaySound("HasTalked");
        }
    }
}