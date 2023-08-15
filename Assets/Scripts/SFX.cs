using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    [SerializeField]
    private AudioSource bed;
    [SerializeField]
    private AudioSource ChopWood;
    [SerializeField]
    private AudioSource inventoryClose;
    [SerializeField]
    private AudioSource inventoryOpen;
    [SerializeField]
    private AudioSource pickUp;
    [SerializeField]
    private AudioSource plantSeed;
    [SerializeField]
    private AudioSource plantPlow;
    [SerializeField]
    private AudioSource plantHarvest;
    [SerializeField]
    private AudioSource transactionSell;
    [SerializeField]
    private AudioSource transactionBuy;

    public void PlayBed()
    {
        bed.Play();
    }
    public void PlayChopWood()
    {
        ChopWood.Play();
    }
    public void PlayInventoryClose()
    {
        inventoryClose.Play();
    }
    public void PlayInventoryOpen()
    {
        inventoryOpen.Play();
    }
    public void PlayPickUp()
    {
        pickUp.Play();
    }
    public void PlayPlantSeed()
    {
        plantSeed.Play();
    }
    public void PlayPlantPlow()
    {
        plantPlow.Play();
    }
    public void PlayPlantHarvest()
    {
        plantHarvest.Play();
    }
    public void PlayTransactionSell()
    {
        transactionSell.Play();
    }
    public void PlayTransactionBuy()
    {
        transactionBuy.Play();
    }
}
