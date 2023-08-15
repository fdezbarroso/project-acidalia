using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapController : MonoBehaviour
{
    [SerializeField]
    private Tilemap tilemap;
    [SerializeField]
    private List<TileData> tiles;

    private Dictionary<TileBase, TileData> tilesDict;

    private void Awake()
    {
        tilesDict = new Dictionary<TileBase, TileData>();
    }

    private void Start()
    {
        for (int i = 0; i < tiles.Count; i++)
        {
            for (int j = 0; j < tiles[i].tiles.Count; j++)
            {
                tilesDict.Add(tiles[i].tiles[j], tiles[i]);
            }
        }
    }

    public TileBase GetTileBase(Vector3Int gPos)
    {
        TileBase tile = tilemap.GetTile(gPos);

        return tile;
    }

    public TileData GetTileData(TileBase tileBase)
    {
        if((tileBase == null) || (tilesDict.ContainsKey(tileBase) == false))
        {
            return null;
        }
        return tilesDict[tileBase];
    }

    public Vector3Int GetGridPosition(Vector2 pos, bool mPos = false)
    {
        Vector2 wPos = pos;
        if (mPos)
        {
            wPos = Camera.main.ScreenToWorldPoint(pos);
        }
        Vector3Int gPos = tilemap.WorldToCell(wPos);

        return gPos;
    }
}
