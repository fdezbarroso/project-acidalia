using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractController : MonoBehaviour
{
    private Player player;
    private PlayerController playerController;
    private Rigidbody2D rb;

    private InteractMarkerController interactMarkerController;

    [Header("Interact Attributes")]
    [SerializeField]
    private float offset;
    [SerializeField]
    private float useArea;

    private Vector2 pos;
    private Collider2D[] colliders;

    private void Awake()
    {
        player = GetComponent<Player>();
        playerController = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();

        interactMarkerController = GameObject.Find("GameManager").GetComponent<InteractMarkerController>();

        offset = 0.3f;
        useArea = 0.4f;
    }

    private void Update()
    {
        MarkInteractable();

        if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    private void MarkInteractable()
    {
        pos = playerController.lastMovement * offset + rb.position;
        colliders = Physics2D.OverlapCircleAll(pos, useArea);

        for (int i = 0; i < colliders.Length; i++)
        {
            Interactable interact = colliders[i].GetComponent<Interactable>();
            if (interact != null)
            {
                interactMarkerController.Mark(interact.gameObject);
                return;
            }
        }

        /* No interactable object found */
        interactMarkerController.HideMarker();
    }

    private void Interact()
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            Interactable interact = colliders[i].GetComponent<Interactable>();
            if (interact != null)
            {
                interact.Interact(player);
                break;
            }
        }
    }
}
