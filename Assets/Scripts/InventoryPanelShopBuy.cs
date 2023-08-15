using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanelShopBuy : MonoBehaviour
{
    public List<InventorySlotShop> slots;
    private PlayerResourceController resources;

    [HideInInspector]
    public SFX sfx;

    private void Awake()
    {
        sfx = GameObject.Find("SFXManager").GetComponent<SFX>();

        slots = new List<InventorySlotShop>();
    }

    private void Start()
    {
        resources = GameManager.Instance.player.GetComponent<PlayerResourceController>();

        for (int i = 0; i < transform.childCount; i++)
        {
            slots.Add(transform.GetChild(i).GetComponent<InventorySlotShop>());
            slots[i].SetIndex(i);
        }
    }

    public void OnClick(int id)
    {
        if ((id == 0) && (resources.money >= 10))
        {
            resources.UpdateFood();
            resources.UpdateMoney(-10);
            sfx.PlayTransactionBuy();
        }
        else if ((id == 1) && (resources.money >= 5))
        {
            resources.UpdateWater();
            resources.UpdateMoney(-5);
            sfx.PlayTransactionBuy();
        }
    }
}
