using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanelPlayer : InventoryPanel
{
    private void Update()
    {
        UpdateInventory();
    }

    public override void OnClick(int id)
    {
        GameManager.Instance.dragDropController.OnClick(inventory.slots[id]);
    }
}
