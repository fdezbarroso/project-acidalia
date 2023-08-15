using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemSlot
{
    public Item item;
    public int amount;

    public void Set(Item item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }

    public void CopyItemSlot(ItemSlot slot)
    {
        item = slot.item;
        amount = slot.amount;
    }

    public void CleanItemSlot()
    {
        item = null;
        amount = 0;
    }
}
