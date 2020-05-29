using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject TooltipObject;

    private void Start()
    {
        TooltipObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipObject.SetActive(false);
    }
}
