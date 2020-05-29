using System;
using System.Collections;
using UnityEngine.Events;

public class ProtectScreenController : GenerateNameButtons
{
    protected override void OnClick(NpcInfo npcInfo)
    {
        GameRoles.Protectant = npcInfo;
        
        if (GameRoles.Protectant != null)
        {
            GameManager.Instance.abilitiesController.KeepOnly(Ability.Protect);
            GameManager.Instance.abilitiesController.SetCanvasState(Ability.Protect,false);
        }
    }
}