using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInteract : Interactable
{
    private GameObject shopBuyPanel;
    private GameObject shopSellPanel;
    private GameObject shopBuyName;
    private GameObject shopSellName;

    private bool isOpened;

    private void Awake()
    {
        shopBuyPanel = GameObject.Find("/UI/InventoryShopBuy");
        shopBuyName = GameObject.Find("/UI/InventoryShopBuyText");
        shopSellPanel = GameObject.Find("/UI/InventoryShopSell");
        shopSellName = GameObject.Find("/UI/InventoryShopSellText");
    }

    private void Start()
    {
        shopBuyPanel.SetActive(false);
        shopBuyName.SetActive(false);
        shopSellPanel.SetActive(false);
        shopSellName.SetActive(false);
    }

    public override void Interact(Player player)
    {
        shopBuyPanel.SetActive(!shopBuyPanel.activeInHierarchy);
        shopBuyName.SetActive(!shopBuyName.activeInHierarchy);
        shopSellPanel.SetActive(!shopSellPanel.activeInHierarchy);
        shopSellName.SetActive(!shopSellName.activeInHierarchy);

        if (!isOpened)
        {
            player.gameObject.GetComponent<InventoryController>().externalInventoryIsOpen = true;
            player.gameObject.GetComponent<PlayerController>().enabled = false;

            isOpened = true;
        }
        else
        {
            player.gameObject.GetComponent<InventoryController>().externalInventoryIsOpen = false;
            if(!player.gameObject.GetComponent<InventoryController>().playerInventoryIsOpen)
            {
                player.gameObject.GetComponent<PlayerController>().enabled = true;
            }

            isOpened = false;
        }
    }
}
