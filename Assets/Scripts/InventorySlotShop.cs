using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InventorySlotShop : MonoBehaviour, IPointerClickHandler
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

    public void OnPointerClick(PointerEventData eventData)
    {
        InventoryPanelShopBuy inventoryPanel = transform.parent.GetComponent<InventoryPanelShopBuy>();
        inventoryPanel.OnClick(index);
    }
}
