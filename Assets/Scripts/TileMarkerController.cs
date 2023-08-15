using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMarkerController : MonoBehaviour
{
    [SerializeField]
    private TileBase tile;

    private Tilemap target;

    public Vector3Int cellPos;
    private Vector3Int oldCellPos;

    private bool mark;

    private void Awake()
    {
        target = gameObject.GetComponent<Tilemap>();

        mark = false;
    }

    private void Update()
    {
        if (mark)
        {
            target.SetTile(oldCellPos, null);
            target.SetTile(cellPos, tile);
            oldCellPos = cellPos;
        }
    }

    public void Mark(bool selectable)
    {
        mark = selectable;
        target.gameObject.SetActive(mark);
    }
}
