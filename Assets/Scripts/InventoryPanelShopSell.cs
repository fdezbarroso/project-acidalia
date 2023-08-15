using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanelShopSell : InventoryPanel
{
    private bool shopAwakeSFX = true;
    private bool sold = false;

    private void OnEnable()
    {
        if (!shopAwakeSFX)
        {
            sfx.PlayInventoryOpen();
        }
        UpdateInventory();
    }

    private void OnDisable()
    {
        for (int i = 0; i < inventory.slots.Count && i < slots.Count; i++)
        {
            if (inventory.slots[i].item != null)
            {
                if (inventory.slots[i].item.name == "Wood")
                {
                    resources.UpdateMoney(1 * inventory.slots[i].amount);
                    sold = true;
                }
                else if (inventory.slots[i].item.name == "Carrot")
                {
                    resources.UpdateMoney(3 * inventory.slots[i].amount);
                    sold = true;
                }
                inventory.slots[i].item = null;
            }
        }
        if (!shopAwakeSFX)
        {
            if (!sold)
            {
                sfx.PlayInventoryClose();
            }
            else
            {
                sfx.PlayTransactionSell();
            }
        }
        shopAwakeSFX = false;
        sold = false;
        UpdateInventory();
    }

    public override void OnClick(int id)
    {
        GameManager.Instance.dragDropController.OnClick(inventory.slots[id]);
        UpdateInventory();
    }
}
