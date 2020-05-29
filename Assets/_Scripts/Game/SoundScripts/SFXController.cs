using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour {

	public static AudioClip 
        conversationOpen,
        conversationClose,
        conversationClick,
        hasTalked,

        uiClick,
        uiBack,
        uiError,
        wolfHowl,
        paperOpen,
        paperClose,
        devModeOpen,
        devModeClose,
        escPause,
        escResume,
        endDayButton,
        camera1,
        camera2,
        cameraZoomIn,
        cameraZoomOut,
        cameraRotate,
        cameraStopRotate;

	static AudioSource audioSrc;

	// Checks for audio files from the Resources folder and loads them
	void Start () {
        // Conversation sound effects
		conversationOpen = Resources.Load("SFX/Conversation_Open") as AudioClip;
        conversationClose = Resources.Load("SFX/Conversation_Close") as AudioClip;
        conversationClick = Resources.Load("SFX/Conversation_Click") as AudioClip;
        hasTalked = Resources.Load("SFX/HasTalked") as AudioClip;

        // UI
        uiClick = Resources.Load("SFX/UI_Click") as AudioClip;
        uiBack = Resources.Load("SFX/UI_Back") as AudioClip;
        uiError = Resources.Load("SFX/UI_Error") as AudioClip;
        wolfHowl = Resources.Load("SFX/Wolf_Howl") as AudioClip;
        paperOpen = Resources.Load("SFX/Paper_Open") as AudioClip;
        paperClose = Resources.Load("SFX/Paper_Close2") as AudioClip;
        devModeOpen = Resources.Load("SFX/DevMode_Open") as AudioClip;
        devModeClose = Resources.Load("SFX/DevMode_Close") as AudioClip;
        escPause = Resources.Load("SFX/ESC_Pause") as AudioClip;
        escResume = Resources.Load("SFX/ESC_Resume") as AudioClip;
        endDayButton = Resources.Load("SFX/EndDayButton") as AudioClip;
        camera1 = Resources.Load("SFX/Camera1") as AudioClip;
        camera2 = Resources.Load("SFX/Camera2") as AudioClip;
        cameraZoomIn = Resources.Load("SFX/CameraZoomIn") as AudioClip;
        cameraZoomOut = Resources.Load("SFX/CameraZoomOut") as AudioClip;
        cameraRotate = Resources.Load("SFX/CameraRotate") as AudioClip;
        cameraStopRotate = Resources.Load("SFX/CameraStopRotate") as AudioClip;

        audioSrc = GetComponent<AudioSource> ();
	}

    // Switch statement which can be used to activate sound effects from all scripts
	public static void PlaySound (string clip) {
		switch (clip) {

        // Conversations
		case "ConversationOpen":
			audioSrc.PlayOneShot (conversationOpen);
			break;
        case "ConversationClose":
            audioSrc.PlayOneShot(conversationClose);
            break;
        case "HasTalked":
            audioSrc.PlayOneShot(hasTalked);
            break;

        // UI
        case "Camera1":
            audioSrc.PlayOneShot(camera1);
            break;
        case "Camera2":
            audioSrc.PlayOneShot(camera2);
            break;
        case "CameraZoomIn":
            audioSrc.PlayOneShot(cameraZoomIn);
            break;
        case "CameraZoomOut":
            audioSrc.PlayOneShot(cameraZoomOut);
            break;
        case "CameraRotate":
            audioSrc.PlayOneShot(cameraRotate);
            break;
        case "CameraStopRotate":
            audioSrc.PlayOneShot(cameraStopRotate);
            break;
        case "UIClick":
            audioSrc.PlayOneShot(uiClick);
            break;
        case "UIBack":
            audioSrc.PlayOneShot(uiBack);
            break;
        case "UIError":
            audioSrc.PlayOneShot(uiError);
            break;
        case "WolfHowl":
            audioSrc.PlayOneShot(wolfHowl);
            break;
        case "PaperOpen":
            audioSrc.PlayOneShot(paperOpen);
            break;
        case "PaperClose":
            audioSrc.PlayOneShot(paperClose);
            break;
        case "DevModeOpen":
            audioSrc.PlayOneShot(devModeOpen);
            break;
        case "DevModeClose":
            audioSrc.PlayOneShot(devModeClose);
            break;
        case "ESCPause":
            audioSrc.PlayOneShot(escPause);
            break;
        case "ESCResume":
            audioSrc.PlayOneShot(escResume);
            break;
        case "EndDayButton":
            audioSrc.PlayOneShot(endDayButton);
            break;
        }
	}
}
