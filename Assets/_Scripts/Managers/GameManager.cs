using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using _Scripts.StoryValuesScripts;

public class GameManager : MonoBehaviour
{
    public GameObject UI;
    public int firstLynchDay;
    public int maxDays;
    public string wolfName;
    public int reputation = 0;
    public GameObject guiltyScreenCanvas;
    public GameObject guiltyScreenCloseButton;
    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject protectScreen;
    public AbilitiesController abilitiesController;
    
    [SerializeField] private Clues clues;
    public Clues Clues => clues;

    [SerializeField] private Transform victimLocationCluesLocationsParent;

    public Transform[] VictimLocationCluesLocations { get; private set; }

    public static GameManager Instance { get; private set; }
    public DayNightCycle DayNightCycle { get; private set; }
    public SpawnArray SpawnArray { get; private set; }
    public WASDMovement WasdMovement { get; private set; }
    public CameraSwitch CameraSwitch { get; private set; }
    public CameraController CameraController { get; private set; }
    public void Awake()
    {
        Instance = this;


        DayNightCycle = FindObjectOfType<DayNightCycle>();
        SpawnArray = FindObjectOfType<SpawnArray>();
        WasdMovement = FindObjectOfType<WASDMovement>();
        CameraSwitch = FindObjectOfType<CameraSwitch>();
        CameraController = FindObjectOfType<CameraController>();
        UI.SetActive(true);

        VictimLocationCluesLocations = victimLocationCluesLocationsParent.Collect<Transform>().ToArray();
    }

    public void LockPlayer(bool isLocked)
    {
        WasdMovement.enabled = !isLocked;
        CameraSwitch.enabled = !isLocked;
        CameraController.enabled = !isLocked;

        if(isLocked)
        {
            CameraController.EnableCursor();
        }
        else
        {
            CameraController.DisableCursor();
        }
    }

    public void ResumeFromGuiltyScreen()
    {
        LockPlayer(false);
        guiltyScreenCanvas.SetActive(false);
        guiltyScreenCloseButton.SetActive(true);
        DayNightCycle.StateMachine();
    }

    public void Win()
    {
        LockPlayer(true);
        guiltyScreenCanvas.SetActive(false);
        winScreen.SetActive(true);
    }

    public void Lose()
    {
        LockPlayer(true);
        guiltyScreenCanvas.SetActive(false);
        loseScreen.SetActive(true);
    }

    public IEnumerator GuiltyScreen()
    {
//        yield return new WaitForSeconds(2);
        yield return null;
        LockPlayer(true);
        guiltyScreenCanvas.SetActive(true);
        guiltyScreenCloseButton.SetActive(true);
    }

    public void ProtectScreen()
    {
        protectScreen.SetActive(true);
        LockPlayer(true);
    }
    public void ResumeFromProtectScreen()
    {
        LockPlayer(false);
        protectScreen.SetActive(false);
        DayNightCycle.StateMachine();
    }

    public IEnumerator GuiltyScreenLast()
    {
//        yield return new WaitForSeconds(2);
        yield return null;
        LockPlayer(true);
        guiltyScreenCanvas.SetActive(true);
        guiltyScreenCloseButton.SetActive(false);
    }

    public void Restart()
    {
        GameObject.Find("GUI").GetComponent<DayNightCycle>().BlackScreen.SetActive(true);
        GameObject.Find("GUI").GetComponent<DayNightCycle>().StartCoroutine("RestartAllDays");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void HasTalked()
    {
        if (SpawnArray.NpcInScene.All(t => t.HasTalked))
        {
            DayNightCycle.EnableEndDay_Button();
        }
    }
}
