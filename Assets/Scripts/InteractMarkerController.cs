using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractMarkerController : MonoBehaviour
{
    private GameObject marker;

    private GameObject current;

    private void Awake()
    {
        marker = GameObject.Find("InteractMarker");
    }

    public void Mark(GameObject target)
    {
        if (current != marker)
        {
            Vector2 pos = target.transform.position;
            pos.y = pos.y + (target.GetComponent<BoxCollider2D>().size.y * 3);
            current = marker;

            Mark(pos);
        }
    }

    public void Mark(Vector2 pos)
    {
        ShowMarker();
        marker.transform.position = pos;
    }

    public void ShowMarker()
    {
        marker.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void HideMarker()
    {
        current = null;
        marker.GetComponent<SpriteRenderer>().enabled = false;
    }
}
