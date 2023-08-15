using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    private Transform player;

    [Header("Pickup Attributes")]
    [SerializeField]
    private float speed;
    [SerializeField]
    private float triggerDistance;

    [SerializeField]
    private float despawnTime;

    public Item item;
    public int amount;

    private SFX sfx;

    private void Awake()
    {
        sfx = GameObject.Find("SFXManager").GetComponent<SFX>();

        speed = 10f;
        triggerDistance = 0.5f;

        despawnTime = 180f;

        amount = 1;
    }

    private void Start()
    {
        player = GameManager.Instance.player.transform;
    }

    private void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);
        despawnTime -= Time.deltaTime;

        if (distance <= triggerDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            if (distance < 0.05f)
            {
                sfx.PlayPickUp();
                GameManager.Instance.inventory.AddItem(item, amount);
                Destroy(gameObject);
            }
        }
        else if (despawnTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Set(Item item, int amount)
    {
        this.item = item;
        this.amount = amount;

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = item.sprite;
    }
}
