using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGatherable : ToolGather
{
    /* Assigned through inspector */
    [SerializeField]
    private GameObject itemDrop;

    [SerializeField]
    private int itemAmount;
    [SerializeField]
    private float spread;

    private SFX sfx;

    private void Awake()
    {
        sfx = GameObject.Find("SFXManager").GetComponent<SFX>();

        itemAmount = 5;
        spread = 1f;
    }

    public override void Gather()
    {
        sfx.PlayChopWood();

        while (itemAmount > 0)
        {
            Vector2 v = transform.position;
            v.x += spread * UnityEngine.Random.value - spread / 2;
            v.y += spread * UnityEngine.Random.value - spread / 2;

            GameObject drop = Instantiate(itemDrop, v, Quaternion.identity);

            itemAmount--;
        }

        Destroy(gameObject);
    }
}
