using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    public GameObject button;

    // Main Menu
    public Canvas InfoUI;
    public Canvas MainMenu_Canvas;
    public Canvas InstructionsPaper_Canvas;
    public Canvas ControlsPaper_Canvas;
    public Canvas GamePaper_Canvas;
    public Canvas LoadingScreen_Canvas;
    public Canvas ExitPaper_Canvas;
    public Canvas ExitScreen_Canvas;

    // Loading screen
    public Slider LoadingSlider;

    #region Main Menu UI Functionality

    // Force the MainMenu_Canvas to be enabled and all other canvases to be disabled when the MainMenu scene starts
    private void Awake()
    {
        InfoUI.enabled = true;
        MainMenu_Canvas.enabled = true;
        InstructionsPaper_Canvas.enabled = false;
        ControlsPaper_Canvas.enabled = false;
        GamePaper_Canvas.enabled = false;
        LoadingScreen_Canvas.enabled = false;
        ExitPaper_Canvas.enabled = false;
        ExitScreen_Canvas.enabled = false;
    }

    // Enable the InstructionsPaper_Canvas in the hierarchy when the Player clicks the "Start" button from the MainMenu_Canvas in the scene
    public void MainMenu_StartClick()
    {
        InfoUI.enabled = true;
        MainMenu_Canvas.enabled = false;
        InstructionsPaper_Canvas.enabled = true;
        ControlsPaper_Canvas.enabled = false;
        GamePaper_Canvas.enabled = false;
        LoadingScreen_Canvas.enabled = false;
        ExitPaper_Canvas.enabled = false;
        ExitScreen_Canvas.enabled = false;

        SFXController.PlaySound("PaperOpen");
    }

    // When the Player clicks the Instructions button in the scene
    public void MainMenu_InstructionsClick()
    {
        GameObject.Find("Main Camera").GetComponent<CameraShake>().StartShake();
        SFXController.PlaySound("UIError");
    }

    // Enable the GamePaper_ShowCanvas in the hierarchy when the Player clicks the "Close" button from the InstructionsPaper_Canvas in the scene
    public void InstructionsPaper_CancelClick()
    {
        InfoUI.enabled = true;
        MainMenu_Canvas.enabled = true;
        InstructionsPaper_Canvas.enabled = false;
        ControlsPaper_Canvas.enabled = false;
        GamePaper_Canvas.enabled = false;
        LoadingScreen_Canvas.enabled = false;
        ExitPaper_Canvas.enabled = false;
        ExitScreen_Canvas.enabled = false;

        SFXController.PlaySound("PaperClose");
    }

    // Enable the ControlsPaper_Canvas in the hierarchy when the Player clicks the "Controls" button from the MainMenu_Canvas in the scene
    public void ControlsPaper_ShowCanvas()
    {
        InfoUI.enabled = true;
        MainMenu_Canvas.enabled = false;
        InstructionsPaper_Canvas.enabled = false;
        ControlsPaper_Canvas.enabled = true;
        GamePaper_Canvas.enabled = false;
        LoadingScreen_Canvas.enabled = false;
        ExitPaper_Canvas.enabled = false;
        ExitScreen_Canvas.enabled = false;

        SFXController.PlaySound("PaperOpen");
    }

    // Enable the GamePaper_ShowCanvas in the hierarchy when the Player clicks the "Close" button from the InstructionsPaper_Canvas in the scene
    public void InstructionsPaper_ClosePaper()
    {
        InfoUI.enabled = true;
        MainMenu_Canvas.enabled = false;
        InstructionsPaper_Canvas.enabled = false;
        ControlsPaper_Canvas.enabled = false;
        GamePaper_Canvas.enabled = false;
        LoadingScreen_Canvas.enabled = false;
        ExitPaper_Canvas.enabled = false;
        ExitScreen_Canvas.enabled = false;
        Invoke("GamePaper_ShowCanvas", 1.0f);

        SFXController.PlaySound("PaperClose");
    }

    // Enable the GamePaper_Canvas in the hierarchy when the Player clicks the "Close" button from the GamePaper_ShowCanvas in the scene
    private void GamePaper_ShowCanvas()
    {
        InfoUI.enabled = true;
        MainMenu_Canvas.enabled = false;
        InstructionsPaper_Canvas.enabled = false;
        ControlsPaper_Canvas.enabled = false;
        GamePaper_Canvas.enabled = true;
        LoadingScreen_Canvas.enabled = false;
        ExitPaper_Canvas.enabled = false;
        ExitScreen_Canvas.enabled = false;

        SFXController.PlaySound("PaperOpen");
    }

    // Enable the LoadingScreen_Canvas in the hierarchy when the Player clicks the "Close" button from the GamePaper_ShowCanvas in the scene
    public void GamePaper_ClosePaper()
    {
        InfoUI.enabled = false;
        MainMenu_Canvas.enabled = false;
        InstructionsPaper_Canvas.enabled = false;
        ControlsPaper_Canvas.enabled = false;
        GamePaper_Canvas.enabled = false;
        LoadingScreen_Canvas.enabled = true;
        ExitPaper_Canvas.enabled = false;
        ExitScreen_Canvas.enabled = false;
        StartCoroutine("LoadGameAsync", 1f);

        SFXController.PlaySound("PaperClose");
    }

    AsyncOperation async;
    // Application loads the game scene in the background as the current main menu scene runs.
    // This is being used as a loading screen without switching the active scene immediately.
    IEnumerator LoadGameAsync()
    {
        async = SceneManager.LoadSceneAsync(1);
        async.allowSceneActivation = false;

        while (async.isDone == false)
        {
            LoadingSlider.value = async.progress;
            if (async.progress == 0.9f)
            {
                LoadingSlider.value = 1f;
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }

    // Enable the ExitPaper_ShowCanvas in the hierarchy when the Player clicks the "Exit" button from the MainMenu_Canvas in the scene
    public void ExitPaper_ShowCanvas()
    {
        InfoUI.enabled = true;
        MainMenu_Canvas.enabled = false;
        InstructionsPaper_Canvas.enabled = false;
        ControlsPaper_Canvas.enabled = false;
        GamePaper_Canvas.enabled = false;
        LoadingScreen_Canvas.enabled = false;
        ExitPaper_Canvas.enabled = true;
        ExitScreen_Canvas.enabled = false;

        SFXController.PlaySound("UIClick");
    }

    // Disable the ExitPaper_ShowCanvas in the hierarchy when the Player clicks the "Cancel" button from the ExitPaper_ShowCanvas in the scene
    public void ExitPaper_HideCanvas()
    {
        InfoUI.enabled = true;
        MainMenu_Canvas.enabled = true;
        InstructionsPaper_Canvas.enabled = false;
        ControlsPaper_Canvas.enabled = false;
        GamePaper_Canvas.enabled = false;
        LoadingScreen_Canvas.enabled = false;
        ExitPaper_Canvas.enabled = false;
        ExitScreen_Canvas.enabled = false;

        SFXController.PlaySound("UIBack");
    }

    // Enable the ExitScreen_ShowCanvas in the hierarchy when the Player clicks the "Confirm exit" button from the ExitPaper_ShowCanvas in the scene
    public void ExitScreen_ShowCanvas()
    {
        InfoUI.enabled = false;
        MainMenu_Canvas.enabled = false;
        InstructionsPaper_Canvas.enabled = false;
        ControlsPaper_Canvas.enabled = false;
        GamePaper_Canvas.enabled = false;
        LoadingScreen_Canvas.enabled = false;
        ExitPaper_Canvas.enabled = false;
        ExitScreen_Canvas.enabled = true;
        Invoke("ExitApplication", 2.0f);

        SFXController.PlaySound("WolfHowl");
    }

    public void ExitApplication()
    {
        Application.Quit();
        Debug.Log("Application quit by the user");
        SceneManager.LoadScene(0);
    }
    
    #endregion


    
    #region ???
    // Start is called before the first frame update
    public IEnumerator LoadIntroScene_Canvas()
    {
        yield return new WaitForSeconds(1);
    }


    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    #endregion
}