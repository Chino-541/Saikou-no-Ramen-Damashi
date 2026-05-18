using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public TMP_Text itemText;
    void Start()
    {
        Inventory.instance.onItemChanged += RefreshUI;
        RefreshUI();
    }

    void RefreshUI()
    {
        itemText.text = "";

        Dictionary<ItemData, int> items =
            Inventory.instance.GetItems();

        foreach(var item in items)
        {
            itemText.text +=
                item.Key.itemName + "x " + item.Value + "\n";
        }
    }
}
