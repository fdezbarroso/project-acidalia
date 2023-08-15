using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private GameObject inventoryPanel;
    private GameObject inventoryName;

    private PlayerController playerController;

    [HideInInspector]
    public bool playerInventoryIsOpen;
    [HideInInspector]
    public bool externalInventoryIsOpen;

    private void Awake()
    {
        inventoryPanel = GameObject.Find("Inventory");
        inventoryName = GameObject.Find("InventoryPlayerText");

        playerController = gameObject.GetComponent<PlayerController>();
    }
    private void Start()
    {
        inventoryPanel.SetActive(false);
        inventoryName.SetActive(false);

        playerInventoryIsOpen = false;
        externalInventoryIsOpen = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryPanel.SetActive(!inventoryPanel.activeInHierarchy);
            inventoryName.SetActive(!inventoryName.activeInHierarchy);

            if (!playerInventoryIsOpen)
            {
                playerInventoryIsOpen = true;
                playerController.enabled = false;
            }
            else
            {
                playerInventoryIsOpen = false;

                if (!externalInventoryIsOpen)
                {
                    playerController.enabled = true;
                }
            }
        }
    }
}
