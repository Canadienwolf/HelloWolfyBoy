using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class GenerateNameButtons : MonoBehaviour
{
    public GameObject buttonPrefab;
    public float yOffset;
    public float startY = 60f;

    protected abstract void OnClick(NpcInfo npcInfo);

    protected readonly List<Button> Buttons = new List<Button>();

    private int _quantity = 0;

    private void OnEnable()
    {
        _quantity = 0;
        if (Buttons.Count != 0)
        {
            Buttons.ForEach(t => { Destroy(t.gameObject); });
            Buttons.Clear();
        }

        foreach (var npc in GameManager.Instance.SpawnArray.NpcInScene)
        {
            var npcInfo = npc.GetComponent<NpcInfo>();
            var newButton = Instantiate(buttonPrefab, transform.GetChild(0), false);
            newButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(
                newButton.GetComponent<RectTransform>().anchoredPosition.x, startY - _quantity * yOffset);
            newButton.GetComponentInChildren<Text>().text = npcInfo.FullName;
            Buttons.Add(newButton.GetComponent<Button>());
            newButton.GetComponent<Button>().onClick
                .AddListener(delegate { OnClick(npcInfo); });

            _quantity++;
        }
    }
}