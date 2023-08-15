using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnManager : MonoBehaviour
{
    public static ItemSpawnManager Instance { get; private set; }

    [SerializeField] 
    private GameObject pickUpItem;

    private void Awake()
    {
        Instance = this;
    }

    public void Spawn(Item item, int amount, Vector2 pos)
    {
        GameObject aux = Instantiate(pickUpItem, pos, Quaternion.identity);
        aux.GetComponent<PickUpItem>().Set(item, amount);
    }
}
