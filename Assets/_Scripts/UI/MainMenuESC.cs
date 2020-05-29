using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuESC : MonoBehaviour
{
    public Canvas InfoUI;
    public Canvas MainMenu_Canvas;
    public Canvas InstructionsPaper_Canvas;
    public Canvas GamePaper_Canvas;
    public Canvas LoadingScreen_Canvas;
    public Canvas ExitPaper_Canvas;
    public Canvas ExitScreen_Canvas;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            InfoUI.enabled = true;
            MainMenu_Canvas.enabled = true;
            InstructionsPaper_Canvas.enabled = false;
            GamePaper_Canvas.enabled = false;
            LoadingScreen_Canvas.enabled = false;
            ExitPaper_Canvas.enabled = false;
            ExitScreen_Canvas.enabled = false;

            SFXController.PlaySound("UIBack");
        }
    }
}
