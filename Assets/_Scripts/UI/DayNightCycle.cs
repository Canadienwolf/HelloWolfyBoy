using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using PixelCrushers.DialogueSystem;
using UnityEditor;
using UnityEngine.UI;
using _Scripts.StoryValuesScripts;
using Random = UnityEngine.Random;

public class DayNightCycle : MonoBehaviour
{
    [Tooltip("Set the object of which to change string")]
    public Text DayCounter;

    [Tooltip("Set the string start value")] [SerializeField]
    private int currentDay;


    public GameObject BlackScreen;
    public Button EndDayButton;
    public GameObject EndDayIndicator;

    public int CurrentDay => currentDay;
    public DayPhase CurrentDayPhase { get; private set; }

    private string conversationString => $"/Day {CurrentDay}";

    private SpawnArray SpawnArray => GameManager.Instance.SpawnArray;
    private List<NpcInfo> NpcInScene => SpawnArray.NpcInScene;
    private Clues clues => GameManager.Instance.Clues;

    private bool IsLost => NpcInScene.Count <= SpawnArray.Population / 2;

    void Start()
    {
        EndDayButton.interactable = false;
        EndDayIndicator.SetActive(false);

        CurrentDayPhase = DayPhase.FirstDay;
        GameManager.Instance.abilitiesController.SetClickableStateAll(false);

        GameManager.Instance.SpawnArray.NpcInScene.ForEach(t =>
        {
            t.GetComponentInChildren<DialogueSystemTrigger>().conversation = $"{t.FullName}{conversationString}";
        });

        currentDay = 1;

        GameRoles.StartNewGame();
        GameRoles.Wolf = NpcInScene[Random.Range(0, NpcInScene.Count)];
        Debug.Log(GameRoles.Wolf.FullName);
    }

    // Function used on the End day button in the Inspector
    public void OnCycleClick()
    {
        switch (CurrentDayPhase)
        {
            case DayPhase.FirstDay:
                CurrentDayPhase = DayPhase.PlanningDayStart;
                break;
            case DayPhase.PlanningDayStart:
                CurrentDayPhase = DayPhase.PlanningDayEnd;
                break;
            case DayPhase.MurderDayStart:
                CurrentDayPhase = DayPhase.MurderDayEnd;
                break;
        }

        SFXController.PlaySound("UIClick");
        StateMachine();
    }

    // Function used in the dev mode
    public void OnGuiltyScreenShow()
    {
        StartCoroutine(GameManager.Instance.GuiltyScreen());
        StateMachine();
    }

    // Function used in the dev mode
    public void OnLastGuiltyScreenShow()
    {
        CurrentDayPhase = DayPhase.MurderDayEnd;
        StateMachine();
    }

    private string EvaluateClue(object source, NpcInfo npc)
    {
        string tempString = "";

        if (source is LocationClue locationClue)
        {
            tempString = locationClue.lines.RandomElement().line;
            tempString = tempString.Replace("[var=NPC]", npc.FirstName);
            tempString = tempString.Replace("[var=PersonalObject]",
                clues.personalItemClues.ToList().Find(t => t.owner == npc.FullName)?.clueName ??
                "[Whose item should be here?]");
        }
        else if (source is PersonalItem personalItem)
        {
            tempString = personalItem.lines.RandomElement().line;
            tempString = tempString.Replace("[var=PersonalObject]", personalItem.clueName);
            tempString = tempString.Replace("[var=NPC]", personalItem.owner);
        }
        else if (source is PhysicalClue physicalClue)
        {
            tempString = physicalClue.lines.RandomElement().line;
            tempString = tempString.Replace("[var=NPC]", npc.FirstName);
            tempString = tempString.Replace("[var=Observation]",
                clues.observationClues.RandomElement().lines.RandomElement().line);
        }

        tempString = tempString.Replace("[var=Location]", npc.location);


        return tempString;
    }

    public void StateMachine()
    {
        switch (CurrentDayPhase)
        {
            case DayPhase.FirstDay:
                CurrentDayPhase = DayPhase.PlanningDayStart;
                break;
            case DayPhase.PlanningDayStart:
                NextDay();
                //Choose Victim
                GameRoles.Victim =
                    NpcInScene.Where(s => s != GameRoles.Wolf).ToList()[Random.Range(0, NpcInScene.Count - 1)];
                Debug.Log($"Day {CurrentDay} Victim: {GameRoles.Victim.FullName}");

                //Preventative clear of victim-related stuff
                GameRoles.VictimLocationClues.Clear();
                GameRoles.VictimLocationClueNpcs.Clear();

                //Set random victim location clues and NPCs
                GameRoles.VictimLocationClues.AddRange(clues.victimLocationClues.Shuffle()
                    .Take(Random.Range(2, 4)));
                GameRoles.VictimLocationClueNpcs.AddRange(NpcInScene.Shuffle()
                    .Take(GameRoles.VictimLocationClues.Count));

                //Set dialogue lines for each clue NPC
                for (int i = 0; i < GameRoles.VictimLocationClueNpcs.Count; i++)
                {
                    var clueNpc = Random.value < 0.45f && GameRoles.VictimLocationClueNpcs[i] != GameRoles.Wolf
                        ? GameRoles.Wolf
                        : GameManager.Instance.SpawnArray.NpcInScene.Shuffle().Where(t => t != GameRoles.Wolf)
                            .ToList()[0];

                    GameRoles.VictimLocationClueNpcs[i].VictimLocationClue =
                        EvaluateClue(GameRoles.VictimLocationClues[i], clueNpc);
                }

                NpcInScene.ForEach(t => t.GetComponentInChildren<DialogueSystemTrigger>().conversation = "Planning");
                GameRoles.Protectant = null;
                GameManager.Instance.abilitiesController.SetClickableStateAll(true);
                break;
            case DayPhase.PlanningDayEnd:
//                GameManager.Instance.ProtectScreen();
                CurrentDayPhase = DayPhase.PlanningNight;
                goto case DayPhase.PlanningNight;

            case DayPhase.PlanningNight:

                if (GameRoles.Protectant != GameRoles.Victim && GameRoles.Protectant != GameRoles.Wolf)
                {
                    NextDay();
                    NpcInfo.KillNpc(GameRoles.Victim);
                    if (IsLost)
                    {
                        GameManager.Instance.Lose();
                        return;
                    }

                    GameRoles.MurderClues.Clear();
                    GameRoles.MurderClueNpcs.Clear();
                    GameRoles.MurderLocationClues.Clear();
                    GameRoles.MurderLocationClueNpcs.Clear();

                    var murderClues = new List<PhysicalClue>(
                        (clues.observationClues
                            .Union(clues.personalItemClues)));

                    GameRoles.MurderClues.AddRange(murderClues.Shuffle().Take(Random.Range(2, 4)));
                    GameRoles.MurderClues?.ForEach(t =>
                    {
                        if (t.cluePrefab != null)
                        {
                            var clue = Instantiate(((PersonalItem) t).cluePrefab,
                                GameManager.Instance.VictimLocationCluesLocations.RandomElement());
                        }
                        else
                        {
                            Debug.Log(t.clueName);
                        }
                    });
                    GameRoles.MurderClueNpcs.AddRange(NpcInScene.Shuffle().Take(GameRoles.MurderClues.Count));

                    GameRoles.MurderLocationClues.AddRange(clues.murderLocationClues.Shuffle()
                        .Take(Random.Range(2, 4)));
                    GameRoles.MurderLocationClueNpcs.AddRange(NpcInScene.Shuffle()
                        .Take(GameRoles.MurderLocationClues.Count));

                    //Set dialogue lines for each clue NPC
                    for (int i = 0; i < GameRoles.MurderClues.Count; i++)
                    {
                        var clueNpc = Random.value < 0.45f && GameRoles.MurderClueNpcs[i] != GameRoles.Wolf
                            ? GameRoles.Wolf
                            : GameManager.Instance.SpawnArray.NpcInScene.Shuffle().Where(t => t != GameRoles.Wolf)
                                .ToList()[0];

                        GameRoles.MurderClueNpcs[i].MurderClue =
                            EvaluateClue(GameRoles.MurderClues[i], clueNpc);
                    }

                    //Set dialogue lines for each clue NPC
                    for (int i = 0; i < GameRoles.MurderLocationClueNpcs.Count; i++)
                    {
                        var clueNpc = Random.value < 0.45f && GameRoles.MurderLocationClueNpcs[i] != GameRoles.Wolf
                            ? GameRoles.Wolf
                            : GameManager.Instance.SpawnArray.NpcInScene.Shuffle().Where(t => t != GameRoles.Wolf)
                                .ToList()[0];

                        GameRoles.MurderLocationClueNpcs[i].MurderLocationClue =
                            EvaluateClue(GameRoles.MurderLocationClues[i], clueNpc);
                    }

                    NpcInScene.ForEach(t => t.GetComponentInChildren<DialogueSystemTrigger>().conversation = "Murder");
                    GameManager.Instance.abilitiesController.KeepOnly(Ability.Fairy);
                    CurrentDayPhase = DayPhase.MurderDayStart;
                }
                else
                {
                    CurrentDayPhase = DayPhase.PlanningDayStart;
                    goto case DayPhase.PlanningDayStart;
                }

                break;

            case DayPhase.MurderDayEnd:
                StartCoroutine(GameManager.Instance.GuiltyScreen());
                CurrentDayPhase = DayPhase.MurderNight;
                //GameManager.Instance.LockPlayer(true);
                break;
            case DayPhase.MurderNight:
                if (IsLost)
                {
                    GameManager.Instance.Lose();
                    return;
                }

                NextDay();
                CurrentDayPhase = DayPhase.PlanningDayStart;
                goto case DayPhase.PlanningDayStart;
        }
    }

    private void NextDay()
    {
        // Unfreeze time scale when switching day and respawn the player back to it's start position
        Time.timeScale = 1;
        GameManager.Instance.WasdMovement.RespawnPlayer();

        GameObject.FindWithTag("Player").GetComponent<CameraController>().DisableCursor();
        GameObject.Find("Player").GetComponent<CameraController>().enabled = true;

        //        Debug.Log("Black Screen enabled");
        BlackScreen.SetActive(true);

        StartCoroutine("CyclingDay");
        currentDay++;
        SpawnArray.SpawnNpcs();

        // Disable UI stuff on the next day
        EndDayButton.interactable = false;

        FindObjectOfType<HasTalkedIndicators>().ResetIndicators();
        GameManager.Instance.SpawnArray.NpcInScene.ForEach(t =>
        {
            t.NextDay();
//            t.GetComponent<DialogueSystemTrigger>().conversation = $"{t.FullName}{conversationString}";
        });
    }

    private IEnumerator CyclingDay()
    {
        yield return new WaitForSeconds(1.5f);
//        Debug.Log("Black Screen disabled");
        BlackScreen.SetActive(false);
    }

    private IEnumerator RestartAllDays()
    {
        yield return new WaitForSeconds(1.5f);
        Debug.Log("Black Screen disabled");

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        StopCoroutine("RestartAllDays");
    }

    private void Update()
    {
        DayCounter.text = ("Day: " + CurrentDay);
    }

    public void EnableEndDay_Button()
    {
        EndDayButton.interactable = true;
        SFXController.PlaySound("EndDayButton");

        EndDayIndicator.SetActive(true);
        StartCoroutine("ResetEndDayText");
    }


    private IEnumerator ResetEndDayText()
    {
        yield return new WaitForSecondsRealtime(2f);
        EndDayIndicator.SetActive(false);
    }
}

public enum DayPhase
{
    Generic,
    FirstDay,
    PlanningDayStart,
    PlanningDayEnd,
    PlanningNight,
    MurderDayStart,
    MurderDayEnd,
    MurderNight
}