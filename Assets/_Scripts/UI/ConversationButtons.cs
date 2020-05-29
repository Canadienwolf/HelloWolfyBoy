using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;

public class ConversationButtons : MonoBehaviour
{

    public bool skip;

    private AbstractDialogueUI dialogueUI;

    private void Awake()
    {
        dialogueUI = GetComponentInChildren<AbstractDialogueUI>();
    }

    public void SkipToResponseMenu()
    {
        skip = true;
        dialogueUI.OnContinue();
    }

    void OnConversationLine(Subtitle subtitle)
    {
        if (skip) StartCoroutine(ContinueAtEndOfFrame());
    }

    IEnumerator ContinueAtEndOfFrame()
    {
        yield return new WaitForEndOfFrame();
        dialogueUI.OnContinue();
    }

    void OnConversationResponseMenu(Response[] responses)
    {
        skip = false;
    }

    public void Button_CancelConversation()
    {
        DialogueManager.instance.StopConversation();
    }

}
