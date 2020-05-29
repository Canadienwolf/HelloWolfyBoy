using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasTalkedIndicators : MonoBehaviour
{
    public float yOffset = 40f;
    public GameObject indicatorPrefab;
    
    [SerializeField]
    private RectTransform anchor;
    private List<HasTalkedIndicator> indicators = new List<HasTalkedIndicator>();

    private void Awake()
    {
//        anchor = transform.GetChild(0).GetComponent<RectTransform>();
    }

    public HasTalkedIndicator AddIndicator(string npcName)
    {
        var newIndicator = Instantiate(indicatorPrefab, anchor, false).GetComponent<HasTalkedIndicator>();
        indicators.Add(newIndicator);
        newIndicator.Name = npcName;

        RebuildIndicators();

        return newIndicator;
    }

    private void RebuildIndicators()
    {
        for (int i = 0; i < indicators.Count; i++)
        {
            indicators[i].SetPosition(i * yOffset);
        }

        anchor.anchoredPosition = new Vector2(anchor.anchoredPosition.x, -indicators.Count * (yOffset / 2f));
    }

    public void ResetIndicators()
    {
        indicators.ForEach(t => t.Striked(false));
    }

    public void RemoveIndicator(HasTalkedIndicator indicator)
    {
        indicators.Remove(indicator);
        Destroy(indicator.gameObject);
        RebuildIndicators();
    }
}