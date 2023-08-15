using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteract : Interactable
{
    private GameObject chestOpened;
    private GameObject chestClosed;

    private GameObject inventoryPanel;
    private GameObject inventoryName;

    [SerializeField]
    private bool isOpen;

    private void Awake()
    {
        chestOpened = transform.Find("ChestOpened").gameObject;
        chestClosed = transform.Find("ChestClosed").gameObject;

        inventoryPanel = GameObject.Find("InventoryChest");
        inventoryName = GameObject.Find("InventoryChestText");

        isOpen = false;
    }

    private void Start()
    {
        inventoryPanel.SetActive(false);
        inventoryName.SetActive(false);
    }

    public override void Interact(Player player)
    {
        inventoryPanel.SetActive(!inventoryPanel.activeInHierarchy);
        inventoryName.SetActive(!inventoryName.activeInHierarchy);

        if (!isOpen)
        {
            chestOpened.SetActive(true);
            chestClosed.SetActive(false);

            player.gameObject.GetComponent<InventoryController>().externalInventoryIsOpen = true;
            player.gameObject.GetComponent<PlayerController>().enabled = false;

            isOpen = true;
        }
        else
        {
            chestOpened.SetActive(false);
            chestClosed.SetActive(true);

            player.gameObject.GetComponent<InventoryController>().externalInventoryIsOpen = false;
            if (!player.gameObject.GetComponent<InventoryController>().playerInventoryIsOpen)
            {
                player.gameObject.GetComponent<PlayerController>().enabled = true;
            }

            isOpen = false;
        }
    }
}
