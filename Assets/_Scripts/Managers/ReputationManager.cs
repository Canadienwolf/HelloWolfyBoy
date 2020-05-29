using System;
using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using UnityEngine;

public class ReputationManager : MonoBehaviour
{
    public int Reputation = 0;

    void OnEnable()
    {
        Lua.RegisterFunction("GetReputation", this, SymbolExtensions.GetMethodInfo(() => GetReputation()));
        Lua.RegisterFunction("SetReputation", this, SymbolExtensions.GetMethodInfo(() => SetReputation((double)0)));
    }

    double GetReputation()
    {
        return Reputation;
    }

    void SetReputation(double value)
    {
        Reputation = (int)value;
    }
}
