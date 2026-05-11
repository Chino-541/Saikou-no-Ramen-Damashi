using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    Dictionary<string, int> items =
        new Dictionary<string, int>();

    public int maxItemTypes = 5;

    public event Action onItemChanged;

    void Awake()
    {
        instance = this;
    }

    public bool AddItem(string name, int amount)
    {
        // 新しい種類
        if (!items.ContainsKey(name))
        {
            // 上限チェック
            if (items.Count >= maxItemTypes)
            {
                Debug.Log("これ以上種類を持てない！");
                return false;
            }

            items.Add(name, amount);
        }
        else
        {
            items[name] += amount;
        }

        Debug.Log(name + " を拾った");

        onItemChanged?.Invoke();

        return true;
    }

    public void MoveAllToBox()
    {
        foreach (var item in items)
        {
            Debug.Log(item.Key + " x" + item.Value + " を倉庫に入れた");
        }
        items.Clear();

        onItemChanged?.Invoke();
    }

    public Dictionary<string, int> GetItems()
    {
        return items;
    }
}