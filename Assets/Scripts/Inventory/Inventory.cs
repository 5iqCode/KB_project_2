using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<item> _StartItems = new List<item>();

    public List<item> _InventoryItems = new List<item>();

    private void Awake()
    {
        for (int i = 0; i < _StartItems.Count; i++)
        {
            _InventoryItems.Add(_StartItems[i]);
        }
    }

    public void AddItem(item _item)
    {
        _InventoryItems.Add(_item);
    }
}
