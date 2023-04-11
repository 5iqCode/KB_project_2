using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWindow : MonoBehaviour
{
    [SerializeField] private Inventory targetInventory;

    [SerializeField] RectTransform itemPanel;

    private void Start()
    {
        Redraw();
    }

    private void Redraw()
    {
        
        for (int i = 0; i < targetInventory._InventoryItems.Count; i++)
        {
            Debug.Log("2132");
            var item = targetInventory._InventoryItems[i];
            var icon = new GameObject(item.Name);
            icon.AddComponent<Image>().sprite = item.Sprite;
            icon.transform.SetParent(itemPanel);

            icon.AddComponent<ItemInformation>();
            icon.AddComponent<Button>();
        }
    }
}
