using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    public ItemContainer inventory;
    public List<InventorySlot> slots;

    [HideInInspector]
    public PlayerResourceController resources;
    [HideInInspector]
    public SFX sfx;

    private bool awakeSFX = true;

    private void Awake()
    {
        sfx = GameObject.Find("SFXManager").GetComponent<SFX>();
        slots = new List<InventorySlot>();
    }

    private void Start()
    {
        resources = GameManager.Instance.player.GetComponent<PlayerResourceController>();

        for (int i = 0; i < transform.childCount; i++)
        {
            slots.Add(transform.GetChild(i).GetComponent<InventorySlot>());
        }

        SetIndex();
        UpdateInventory();
    }

    private void OnEnable()
    {
        if (!awakeSFX)
        {
            sfx.PlayInventoryOpen();
        }
        UpdateInventory();
    }
    private void OnDisable()
    {
        if (!awakeSFX)
        {
            sfx.PlayInventoryClose();
        }
        awakeSFX = false;
    }

    private void SetIndex()
    {
        for (int i = 0; i < inventory.slots.Count && i < slots.Count; i++)
        {
            slots[i].SetIndex(i);
        }
    }

    public void UpdateInventory()
    {
        for (int i = 0; i < inventory.slots.Count && i < slots.Count; i++)
        {
            if (inventory.slots[i].item != null)
            {
                slots[i].SetSlot(inventory.slots[i]);
            }
            else
            {
                slots[i].CleanSlot();
            }
        }
    }

    public virtual void OnClick(int id)
    {

    }
}
