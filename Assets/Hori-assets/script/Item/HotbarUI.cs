using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
using HoriAssets;
=======
>>>>>>> main

public class HotbarUI : MonoBehaviour
{
    public HotbarSlot[] slots;

    void Start()
    {
<<<<<<< HEAD
        // 変更点1：頭に「HoriAssets.」をつける
        HoriAssets.Inventory.instance.onItemChanged += RefreshUI;
=======
        Inventory.instance.onItemChanged += RefreshUI;
>>>>>>> main

        RefreshUI();
    }

    void RefreshUI()
    {
<<<<<<< HEAD
        // 変更点2：頭に「HoriAssets.」をつける
        Dictionary<ItemData, int> items =
            HoriAssets.Inventory.instance.GetItems();
=======
        Dictionary<ItemData, int> items =
            Inventory.instance.GetItems();
>>>>>>> main

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

        // 空スロットを消す
        for (int i = index;
             i < slots.Length;
             i++)
        {
            slots[i].SetItem(null, 0);
        }
    }
}