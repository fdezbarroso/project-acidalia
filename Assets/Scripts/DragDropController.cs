using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDropController : MonoBehaviour
{
    [SerializeField]
    private ItemSlot slot;

    private GameObject dragIcon;
    private RectTransform dragIconTransform;
    private Image dragIconImage;

    private void Awake()
    {
        dragIcon = GameObject.Find("DragDropIcon");
        dragIconTransform = dragIcon.GetComponent<RectTransform>();
        dragIconImage = dragIcon.GetComponent<Image>();
        slot = new ItemSlot();

        dragIcon.SetActive(false);
    }

    private void Update()
    {
        if (dragIcon.activeInHierarchy)
        {
            dragIconTransform.position = Input.mousePosition;

            if (Input.GetMouseButtonDown(0))
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    Vector2 wPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    ItemSpawnManager.Instance.Spawn(slot.item, slot.amount, wPos);

                    slot.CleanItemSlot();
                    dragIcon.SetActive(false);
                }
            }
        }
    }

    public void OnClick(ItemSlot slot)
    {
        if (this.slot.item == null)
        {
            this.slot.CopyItemSlot(slot);
            slot.CleanItemSlot();
        }
        else
        {
            Item item = slot.item;
            int amount = slot.amount;

            slot.CopyItemSlot(this.slot);
            this.slot.Set(item, amount);
        }
        UpdateDragIcon();
    }

    private void UpdateDragIcon()
    {
        if (slot.item != null)
        {
            dragIcon.SetActive(true);
            dragIconImage.sprite = slot.item.sprite;
        }
        else
        {
            dragIcon.SetActive(false);
        }
    }
}
