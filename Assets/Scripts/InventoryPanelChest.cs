using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanelChest : InventoryPanel
{
    public override void OnClick(int id)
    {
        GameManager.Instance.dragDropController.OnClick(inventory.slots[id]);
        UpdateInventory();
    }
}
