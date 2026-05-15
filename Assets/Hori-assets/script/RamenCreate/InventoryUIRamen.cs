using System.Collections.Generic;
using UnityEngine;

public class InventoryUIRamen : MonoBehaviour
{
    public GameObject slotPrefab;

    public Transform content;

    void Start()
    {
        Inventory.instance.onItemChanged += RefreshUI;

        RefreshUI();
    }

    void RefreshUI()
    {
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }

        Dictionary<ItemData, int> items =
            Inventory.instance.GetItems();

        foreach (var item in items)
        {
            GameObject slot =
                Instantiate(slotPrefab, content);

            SlotUI ui =
                slot.GetComponent<SlotUI>();

            ui.SetItem(
                item.Key,
                item.Value);
        }
    }
}