using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ItemContainer))]
public class InventoryClear : Editor
{
    public override void OnInspectorGUI()
    {
        ItemContainer inventory = target as ItemContainer;
        if(GUILayout.Button("Clear inventory"))
        {
            for(int i = 0; i < inventory.slots.Count; i++)
            {
                inventory.slots[i].CleanItemSlot();
            }
        }
        DrawDefaultInspector();
    }
}
