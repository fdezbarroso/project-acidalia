using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    private Image image;
    private TMP_Text text;

    private int index;

    private void Awake()
    {
        image = transform.Find("Image").GetComponent<Image>();
        text = transform.Find("Text (TMP)").GetComponent<TMP_Text>();
    }

    public void SetIndex(int i)
    {
        index = i;
    }

    public void SetSlot(ItemSlot slot)
    {
        image.color = new Color(255f / 255f, 255f / 255f, 255f / 255f);
        image.sprite = slot.item.sprite;

        if (slot.item.stackable)
        {
            text.text = slot.amount.ToString();
        }
    }

    public void CleanSlot()
    {
        image.color = new Color(34f / 255f, 35f / 255f, 35f / 255f);
        image.sprite = null;

        text.text = "";
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        InventoryPanel inventoryPanel = transform.parent.GetComponent<InventoryPanel>();
        inventoryPanel.OnClick(index);
    }
}
