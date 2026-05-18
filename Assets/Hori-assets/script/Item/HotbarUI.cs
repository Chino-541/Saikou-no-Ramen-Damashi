using System.Collections.Generic;
using UnityEngine;

public class HotbarUI : MonoBehaviour
{
    public HotbarSlot[] slots;

    void Start()
    {
        Inventory.instance.onItemChanged += RefreshUI;

        RefreshUI();
    }

    void RefreshUI()
    {
        Dictionary<ItemData, int> items =
            Inventory.instance.GetItems();

        int index = 0;

        foreach (var item in items)
        {
            if (index >= slots.Length)
                break;

            slots[index].SetItem(
                item.Key,
                item.Value);

            index++;
        }

        // ‹óƒXƒƒbƒg‚ğÁ‚·
        for (int i = index;
             i < slots.Length;
             i++)
        {
            slots[i].SetItem(null, 0);
        }
    }
}