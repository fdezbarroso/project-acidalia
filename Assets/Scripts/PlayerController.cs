using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D bc;

    [Header("Player Attributes")]
    [SerializeField]
    private float speed;

    private Vector2 movement;

    [HideInInspector]
    public Vector2 lastMovement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();

        speed = 3f;
        movement = new Vector2(0, 0);
        lastMovement = new Vector2(0, 0);
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movement.x = horizontal;
        movement.y = vertical;

        /* For tool use in PlayerToolController.cs */
        if (horizontal != 0 || vertical != 0)
        {
            lastMovement.x = horizontal;
            lastMovement.y = vertical;

            lastMovement = lastMovement.normalized;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    }
}
