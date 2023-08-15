using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New Item", menuName = "Scriptable Objects/TileData")]
public class TileData : ScriptableObject
{
    public List<TileBase> tiles;

    public bool plowable;
}
