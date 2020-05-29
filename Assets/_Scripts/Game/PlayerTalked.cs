using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using _Scripts.StoryValuesScripts;
using Random = UnityEngine.Random;

public class PlayerTalked : MonoBehaviour
{
    private void OnConversationEnd(Transform actor)
    {
        actor.GetComponent<NpcInfo>().TalkedTo(tag);

        //GameManager.Instance.LockPlayer(false);
        GameObject.FindWithTag("Player").GetComponent<CameraController>().DisableCursor();
        GameObject.Find("Player").GetComponent<CameraController>().enabled = true;
    }

    private void OnConversationStart(Transform actor)
    {
        Footsteps.StopFootsteps();
        SFXController.PlaySound("ConversationOpen");
        GameObject.FindWithTag("Player").GetComponent<CameraController>().EnableCursor();
        GameObject.Find("Player").GetComponent<CameraController>().enabled = false;
        //GameManager.Instance.LockPlayer(true);  

        var actorNpc = actor.GetComponent<NpcInfo>();

        DialogueLua.SetVariable("VictimLocationClueNPC", false);
        DialogueLua.SetVariable("MurderClueNPC", false);
        DialogueLua.SetVariable("MurderLocationClueNPC", false);


        switch (GameManager.Instance.DayNightCycle.CurrentDayPhase)
        {
            case DayPhase.PlanningDayStart:
            {
                if (GameRoles.VictimLocationClueNpcs.Exists(t => t == actorNpc))
                {
                    DialogueLua.SetVariable("VictimLocationClueNPC", true);

                    DialogueLua.SetVariable("VictimLocationClue", GameRoles.VictimLocationClueNpcs.Find(t=>t==actorNpc).VictimLocationClue);

                    DialogueManager.UpdateResponses();
                }

                break;
            }
            case DayPhase.MurderDayStart:
            {
                if (GameRoles.MurderLocationClueNpcs.Exists(t => t == actorNpc))
                {
                    DialogueLua.SetVariable("MurderLocationClueNPC", true);

                    DialogueLua.SetVariable("MurderLocationClue", actorNpc.MurderLocationClue);

                    DialogueManager.UpdateResponses();
                }

                if (GameRoles.MurderClueNpcs.Exists(t => t == actorNpc))
                {
                    DialogueLua.SetVariable("MurderClueNPC", true);

                    DialogueLua.SetVariable("MurderClue", actorNpc.MurderClue);

                    DialogueManager.UpdateResponses();
                }

                break;
            }
        }

        DialogueManager.UpdateResponses();
    }
}