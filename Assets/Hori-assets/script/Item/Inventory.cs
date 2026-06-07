using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    Dictionary<ItemData, int> items =
        new Dictionary<ItemData, int>();

    public int maxItemTypes = 5;

    public event Action onItemChanged;

    // 仮アイテム
    public ItemData butaniku;
    public ItemData gyuniku;
    public ItemData toriniku;

    void Start()
    {
        AddItem(butaniku, 5);

        AddItem(gyuniku, 3);

        AddItem(toriniku, 2);
    }

    void Awake()
    {
        instance = this;
    }

    public bool AddItem(ItemData item, int amount)
    {
        // 新しい種類
        if (!items.ContainsKey(item))
        {
            if (items.Count >= maxItemTypes)
            {
                Debug.Log("これ以上種類を持てない！");
                return false;
            }

            items.Add(item, amount);
        }
        else
        {
            items[item] += amount;
        }

        Debug.Log(item.itemName + " を拾った");

        onItemChanged?.Invoke();

        return true;

    }

    public void MoveAllToBox()
    {
        foreach (var item in items)
        {
            Debug.Log(item.Key.itemName +
                " x" + item.Value +
                " を倉庫に入れた");
        }

        items.Clear();

        onItemChanged?.Invoke();
    }

    public Dictionary<ItemData, int> GetItems()
    {
        return items;
    }
}