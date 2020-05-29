using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public enum Ability
{
    Fairy,
    Protect
}

[Serializable]
public class AbilityClass
{
    public GameObject AbilityButton;
    public GameObject AbilityCanvas;

    public void SetCanvasState(bool state)
    {
        AbilityCanvas.SetActive(state);
    }

    public void SetClickableState(bool state)
    {
        AbilityButton.SetActive(state);
    }

    public void AddButtonEvent()
    {
        AbilityButton.GetComponent<Button>().onClick.AddListener(delegate
        {
            AbilityCanvas.SetActive(!AbilityCanvas.activeInHierarchy);
        });
    }
}

public class AbilitiesController : MonoBehaviour
{
    [SerializeField] private AbilityClass fairy;
    [SerializeField] private AbilityClass protect;

    private readonly Dictionary<Ability, AbilityClass> _abilitiesDictionary =
        new Dictionary<Ability, AbilityClass>();

    private void Awake()
    {
//        _abilitiesDictionary.Add(Ability.Fairy, fairy);
        _abilitiesDictionary.Add(Ability.Protect, protect);

        _abilitiesDictionary.ForEach(t => t.Value.AddButtonEvent());
    }

    public void SetClickableStateAll(bool state)
    {
        _abilitiesDictionary.ForEach(t => t.Value.SetClickableState(state));
    }

    public void SetCanvasState(Ability ability, bool state)
    {
        _abilitiesDictionary[ability].SetCanvasState(state);
    }


    public void KeepOnly(Ability ability)
    {
        _abilitiesDictionary.Where(t => t.Key != ability).ForEach(t =>
        {
            t.Value.AbilityButton.GetComponent<Button>().interactable = false;
            t.Value.SetClickableState(false);
        });
    }
}