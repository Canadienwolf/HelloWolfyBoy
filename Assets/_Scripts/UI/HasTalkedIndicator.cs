using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HasTalkedIndicator : MonoBehaviour
{
    private Text nameObject;
    private GameObject strikeObject;
    private RectTransform _rectTransform;

    private void Awake()
    {
        nameObject = gameObject.GetComponent<Text>();
        strikeObject = transform.GetChild(0).gameObject;
        _rectTransform = GetComponent<RectTransform>();
    }

    public void SetPosition(float yPos)
    {
        _rectTransform.anchoredPosition = new Vector2(_rectTransform.anchoredPosition.x, yPos);
    }

    public void Striked(bool isStriked)
    {
        strikeObject.SetActive(isStriked);
    }

    public String Name
    {
        get { return nameObject.text; }
        set { nameObject.text = value; }
    }
}