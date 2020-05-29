using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiltyScreenController : GenerateNameButtons
{
    protected override void OnClick(NpcInfo npcInfo)
    {
            if (npcInfo==GameRoles.Wolf)
            {
                GameManager.Instance.Win();
                return;
            }

            NpcInfo.KillNpc(npcInfo);
            Buttons.ForEach(t => t.interactable = false);
            GameManager.Instance.ResumeFromGuiltyScreen();
    }
}