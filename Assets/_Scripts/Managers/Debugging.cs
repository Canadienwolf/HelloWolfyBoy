using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[SuppressMessage("ReSharper", "CheckNamespace")]
public class Debugging : MonoBehaviour
{
    Canvas cheatPaper;
    public GameObject devText;

    public GameObject SceneCanvas;
    public Canvas DevModeCanvas;
    public GameObject StatsMonitorCanvas;

    public Canvas ESCPauseCanvas;
    public Text feedbackText;
    public GameObject MusicInfo;


    //public Text debugText;


    void Start()
    {
        cheatPaper = GameObject.Find("GUI/DevModeCanvas").GetComponent<Canvas>();
        cheatPaper.enabled = false;
        devText.SetActive(false);
        ESCPauseCanvas.enabled = false;
        feedbackText.text = "";

        //debugText = GameObject.Find("GUI/DebugScreen/Text").GetComponent<Text>();
        //debugText.enabled = false;
    }


    bool isCheatActive = false;
    bool isESCActive = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            if (Input.GetKeyDown(KeyCode.Backslash) || 
                Input.GetKeyDown(KeyCode.BackQuote) ||
                Input.GetKeyDown(KeyCode.Quote))
                {
                    {
                    isCheatActive = !isCheatActive;

                    if (isCheatActive)
                    {
                        cheatPaper.enabled = true;
                        //debugText.enabled = true;
                        //debugText.text = "Debugging active!";
                        //StartCoroutine("HideText");

                        SFXController.PlaySound("DevModeOpen");
                        devText.SetActive(true);

                        SceneCanvas.SetActive(true);
                        DevModeCanvas.enabled = true;
                        StatsMonitorCanvas.SetActive(false);

                        //GameManager.Instance.LockPlayer(true);
                        GameObject.Find("Player").GetComponent<CameraController>().EnableCursor();
                        GameObject.Find("Player").GetComponent<CameraController>().enabled = false;
                    }
                    else
                    {
                        SFXController.PlaySound("DevModeClose");

                        cheatPaper.enabled = false;
                        //debugText.enabled = false;

                        //GameManager.Instance.LockPlayer(false);
                        GameObject.Find("Player").GetComponent<CameraController>().DisableCursor();
                        GameObject.Find("Player").GetComponent<CameraController>().enabled = true;
                    }
                }
            }
        }


        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            {
                isESCActive = !isESCActive;

                if (isESCActive)
                {
                    SFXController.PlaySound("ESCPause");

                    SceneCanvas.SetActive(false);
                    DevModeCanvas.enabled = false;
                    ESCPauseCanvas.enabled = true;
                    StatsMonitorCanvas.SetActive(false);
                    Time.timeScale = 0;

                    //GameManager.Instance.LockPlayer(true);
                    GameObject.Find("Player").GetComponent<CameraController>().EnableCursor();
                    GameObject.Find("Player").GetComponent<CameraController>().enabled = false;
                }
                else
                {
                    SFXController.PlaySound("ESCResume");

                    SceneCanvas.SetActive(true);
                    DevModeCanvas.enabled = false;
                    ESCPauseCanvas.enabled = false;
                    StatsMonitorCanvas.SetActive(false);
                    Time.timeScale = 1;

                    //GameManager.Instance.LockPlayer(false);
                    GameObject.Find("Player").GetComponent<CameraController>().DisableCursor();
                    GameObject.Find("Player").GetComponent<CameraController>().enabled = true;
                }
            }
        }
    }



    //private void OnGUI()
    //{
    //    if (Event.current.isKey && Event.current.type == EventType.KeyDown)
    //    {
    //        Debug.Log(Event.current.keyCode);
    //    }
    //}

    //IEnumerator HideText()
    //{
    //    debugText.text = "Cheat paper enabled!";
    //    yield return new WaitForSeconds(1);
    //    debugText.text = "";
    //    debugText.enabled = false;
    //    StopCoroutine("HideText");
    //}

    // Called from the hierarchy if needed
    public void disableCheatPaper()
    {
        cheatPaper.enabled = false;
        isCheatActive = false;

        StatsMonitorCanvas.SetActive(false);
        SFXController.PlaySound("DevModeClose");
    }

    public void activateEndDay()
    {
        //debugText.text = "Cheat paper enabled!";
        //debugText.enabled = false;
        GameObject.Find("GUI").GetComponent<DayNightCycle>().EnableEndDay_Button();
        isCheatActive = false;
        cheatPaper.enabled = false;

        SFXController.PlaySound("UIClick");
        GameObject.FindWithTag("Player").GetComponent<CameraController>().enabled = true;
    }

    public void activateGuiltyScreen()
    {
        GameObject.Find("GUI").GetComponent<DayNightCycle>().OnGuiltyScreenShow();
        isCheatActive = false;
        cheatPaper.enabled = false;

        SFXController.PlaySound("UIClick");
    }

    public void activateLastGuiltyScreen()
    {
        GameObject.Find("GUI").GetComponent<DayNightCycle>().OnLastGuiltyScreenShow();
        isCheatActive = false;
        cheatPaper.enabled = false;

        SFXController.PlaySound("UIClick");
    }

    public void activateStatsMonitor()
    {
        //debugText.text = "Cheat paper enabled!";
        //debugText.enabled = false;
        SceneCanvas.SetActive(false);
        DevModeCanvas.enabled = false;
        StatsMonitorCanvas.SetActive(true);
        
        isCheatActive = false;
        cheatPaper.enabled = false;

        SFXController.PlaySound("UIClick");
    }

    public void disableESCMenu()
    {
        ESCPauseCanvas.enabled = false;
        isESCActive = false;

        SceneCanvas.SetActive(true);
        SFXController.PlaySound("UIClick");
        Time.timeScale = 1f;
    }
    public void restartESCMenu()
    {
        SceneManager.LoadScene(1);

        SFXController.PlaySound("UIClick");
        Time.timeScale = 1f;
    }
    public void mainMenuESCMenu()
    {
        SFXController.PlaySound("UIClick");
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void CallShuffleTrack()
    {
        SFXController.PlaySound("UIClick");
        GameObject.Find("GameAudioManager/Music").GetComponent<MusicPlayer>().ShuffleTrack();
        feedbackText.text = "Soundtrack shuffled";
        StartCoroutine("ResetFeedbackText");
    }
    public void StartTrack()
    {
        SFXController.PlaySound("UIClick");
        GameObject.Find("GameAudioManager/Music").GetComponent<AudioSource>().Play();
        GameObject.Find("GameAudioManager/Music").GetComponent<AudioSource>().volume = 0.3f;
        feedbackText.text = "Soundtrack started";
        StartCoroutine("ResetFeedbackText");
        MusicInfo.SetActive(false);
    }
    public void StopTrack()
    {
        SFXController.PlaySound("UIClick");
        GameObject.Find("GameAudioManager/Music").GetComponent<AudioSource>().volume = 0f;
        feedbackText.text = "Soundtrack stopped";
        StartCoroutine("ResetFeedbackText");
        MusicInfo.SetActive(true);
    }
    public void ResetCameraZoomAction()
    {
        SFXController.PlaySound("UIClick");
        SceneCanvas.SetActive(true);
        isESCActive = false;
        Time.timeScale = 1f;
        ESCPauseCanvas.enabled = false;
    }
    public void ResetCameraRotationAction()
    {
        SFXController.PlaySound("UIClick");
        SceneCanvas.SetActive(true);
        isESCActive = false;
        Time.timeScale = 1f;
        ESCPauseCanvas.enabled = false;
    }


    IEnumerator ResetFeedbackText()
    {
        yield return new WaitForSecondsRealtime(1f);
        feedbackText.text = "";
    }
}
