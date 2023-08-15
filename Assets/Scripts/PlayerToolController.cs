using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerToolController : MonoBehaviour
{
    private PlayerController player;
    private Rigidbody2D rb;

    [Header("Tool Attributes")]
    [SerializeField]
    private float offset;
    [SerializeField]
    private float useArea;
    [SerializeField]
    private TileMarkerController tileMarkerController;
    [SerializeField]
    private TileMapController tileMapController;
    [SerializeField]
    private float selectDistance;
    [SerializeField]
    private CropsManager cropsManager;
    [SerializeField]
    private TileData plowableTiles;

    private Vector3Int tilePos;
    private bool selectable;

    private void Awake()
    {
        player = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();

        offset = 0.3f;
        useArea = 0.4f;
        selectDistance = 2f;
    }

    private void Update()
    {
        TileSelect();
        IsSelectable();
        TileMark();

        if (Input.GetMouseButtonDown(0))
        {
            if (!ToolItemInteract())
            {
                ToolGridInteract();
            }
        }
    }

    private bool ToolItemInteract()
    {
        Vector2 pos = player.lastMovement * offset + rb.position;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(pos, useArea);

        for (int i = 0; i < colliders.Length; i++)
        {
            ToolGather gather = colliders[i].GetComponent<ToolGather>();
            if (gather != null)
            {
                gather.Gather();
                return true;
            }
        }
        return false;
    }

    private void ToolGridInteract()
    {
        if (selectable)
        {
            TileBase tileBase = tileMapController.GetTileBase(tilePos);
            TileData tileData = tileMapController.GetTileData(tileBase);
            if (tileData == plowableTiles)
            {
                if (cropsManager.CheckPlowed(tilePos) && !cropsManager.CheckSeeded(tilePos))
                {
                    cropsManager.Seed(tilePos);
                }
                else if (cropsManager.CheckPlowed(tilePos) && cropsManager.CheckSeeded(tilePos))
                {
                    cropsManager.Gather(tilePos);
                }
                else if (!cropsManager.CheckPlowed(tilePos))
                {
                    cropsManager.Plow(tilePos);
                }
            }
        }
    }

    private void TileSelect()
    {
        tilePos = tileMapController.GetGridPosition(Input.mousePosition, true);
    }

    private void IsSelectable()
    {
        Vector2 playerPos = transform.position;
        Vector2 cameraPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Vector2.Distance(playerPos, cameraPos) < selectDistance)
        {
            selectable = true;
        }
        else
        {
            selectable = false;
        }

        tileMarkerController.Mark(selectable);
    }

    private void TileMark()
    {
        tileMarkerController.cellPos = tilePos;
    }
}
