using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Scriptable Objects/ItemContainer")]
public class ItemContainer : ScriptableObject
{
    public List<ItemSlot> slots;

    public void AddItem(Item item, int amount = 1)
    {
        if (item.stackable)
        {
            ItemSlot itemSlot = slots.Find(x => x.item == item);
            if (itemSlot != null)
            {
                itemSlot.amount += amount;
            }
            else
            {
                itemSlot = slots.Find(x => x.item == null);
                if (itemSlot != null)
                {
                    itemSlot.item = item;
                    itemSlot.amount = amount;
                }
            }
        }
        else
        {
            ItemSlot itemSlot = slots.Find(x => x.item == null);
            if (itemSlot != null)
            {
                itemSlot.item = item;
            }
        }
    }

    public void RemoveItem(Item item, int amount = 1)
    {
        ItemSlot itemSlot = slots.Find(x => x.item == item);
        if (itemSlot != null)
        {
            if (item.stackable)
            {
                itemSlot.amount -= amount;
                if (itemSlot.amount <= 0)
                {
                    itemSlot = null;
                }
            }
            else
            {
                itemSlot = null;
                for (int i = 0; i < amount; i++)
                {
                    itemSlot = slots.Find(x => x.item == item);
                    itemSlot = null;
                }
            }
        }
    }
}
