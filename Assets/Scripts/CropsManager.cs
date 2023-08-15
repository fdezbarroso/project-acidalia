using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CropsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject itemDrop;

    [SerializeField]
    private int itemAmount;
    [SerializeField]
    private float spread;

    [SerializeField]
    private TileBase empty;
    [SerializeField]
    private TileBase plowed;
    [SerializeField]
    private TileBase seeded;
    [SerializeField]
    private TileBase seeded1;
    [SerializeField]
    private TileBase seeded2;
    [SerializeField]
    private TileBase seeded3;
    [SerializeField]
    private Tilemap target;

    private Dictionary<Vector2Int, Crops> crops;
    private int day;
    private SFX sfx;

    private void Awake()
    {
        sfx = GameObject.Find("SFXManager").GetComponent<SFX>();

        crops = new Dictionary<Vector2Int, Crops>();
        day = 0;

        itemAmount = 3;
        spread = 1f;
    }

    private void Update()
    {
        if (GameManager.Instance.dayNightController.day > day)
        {
            foreach (var item in crops)
            {
                if (CheckSeeded((Vector3Int)item.Key))
                {
                    item.Value.growthDays++;
                    if (item.Value.growthDays == 1)
                    {
                        target.SetTile((Vector3Int)item.Key, seeded1);
                    }
                    else if (item.Value.growthDays == 3)
                    {
                        target.SetTile((Vector3Int)item.Key, seeded2);
                    }
                    else if (item.Value.growthDays == 5)
                    {
                        item.Value.gatherable = true;
                        target.SetTile((Vector3Int)item.Key, seeded3);
                    }
                }
            }
            day++;
        }
    }

    public bool CheckSeeded(Vector3Int pos)
    {
        return crops[(Vector2Int)pos].seeded;
    }

    public bool CheckPlowed(Vector3Int pos)
    {
        return crops.ContainsKey((Vector2Int)pos);
    }

    public bool CheckGatherable(Vector3Int pos)
    {
        return crops[(Vector2Int)pos].gatherable;
    }

    public void Seed(Vector3Int pos)
    {
        if (!CheckSeeded(pos))
        {
            sfx.PlayPlantSeed();
            target.SetTile(pos, seeded);
            crops[(Vector2Int)pos].seeded = true;
        }
    }

    public void Plow(Vector3Int pos)
    {
        if (!CheckPlowed(pos))
        {
            sfx.PlayPlantPlow();
            Crops crop = new();
            crops.Add((Vector2Int)pos, crop);

            target.SetTile(pos, plowed);
        }
    }

    public void Gather(Vector3Int pos)
    {
        if (CheckGatherable(pos))
        {
            sfx.PlayPlantHarvest();
            while (itemAmount > 0)
            {
                Vector2 v = (Vector2Int)pos;
                v.x += 0.5f + spread * UnityEngine.Random.value - spread / 2;
                v.y += 0.5f + spread * UnityEngine.Random.value - spread / 2;

                GameObject drop = Instantiate(itemDrop, v, Quaternion.identity);

                itemAmount--;
            }
            target.SetTile(pos, empty);

            itemAmount = 3;
            crops.Remove((Vector2Int)pos);
        }
    }
}
