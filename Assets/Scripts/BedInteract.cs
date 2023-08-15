using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BedInteract : Interactable
{
    private GameObject bedFull;
    private GameObject bedEmpty;

    private GameObject darken;

    [SerializeField]
    private bool isFull;

    private SFX sfx;

    private void Awake()
    {
        bedFull = transform.Find("BedFull").gameObject;
        bedEmpty = transform.Find("BedEmpty").gameObject;

        darken = GameObject.Find("ScreenDarken");

        sfx = GameObject.Find("SFXManager").GetComponent<SFX>();

        isFull = false;
    }

    public override void Interact(Player player)
    {
        if (!isFull && !GameManager.Instance.dayNightController.isDay)
        {
            player.gameObject.GetComponent<PlayerController>().enabled = false;
            player.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            player.gameObject.GetComponent<StatusIndicators>().enabled = false;
            player.gameObject.GetComponent<InventoryController>().enabled = false;

            bedFull.SetActive(true);
            bedEmpty.SetActive(false);
            isFull = true;

            darken.GetComponent<Image>().enabled = true;

            GameManager.Instance.dayNightController.sleeping = true;

            sfx.PlayBed();

            StartCoroutine(PassDay(player, 3f));
        }
    }

    IEnumerator PassDay(Player player, float time)
    {
        yield return new WaitForSeconds(time);

        GameManager.Instance.dayNightController.day++;
        // 180
        GameManager.Instance.dayNightController.decimalTime = 20;

        GameManager.Instance.dayNightController.sleeping = false;

        darken.GetComponent<Image>().enabled = false;

        bedFull.SetActive(false);
        bedEmpty.SetActive(true);
        isFull = false;

        player.gameObject.GetComponent<PlayerController>().enabled = true;
        player.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        player.gameObject.GetComponent<StatusIndicators>().enabled = true;
        player.gameObject.GetComponent<InventoryController>().enabled = true;
    }
}
