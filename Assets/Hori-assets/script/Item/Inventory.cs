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


    void Start()
    {
        Debug.Log("Inventory Start");
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
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
            Storage.instance.AddItem(item.Key, item.Value);
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
    public int GetItemCount(ItemData item)
    {
        if (items.ContainsKey(item))
        {
            return items[item];
        }

        return 0;
    }
    public bool RemoveItem(ItemData item, int amount)
    {
        Debug.Log("削除要求: " + item.itemName);

        if (!items.ContainsKey(item))
        {
            Debug.Log("そのItemDataはInventoryに存在しません");
            return false;
        }

        items[item] -= amount;

        Debug.Log("残り: " + items[item]);

        if (items[item] <= 0)
        {
            items.Remove(item);
        }

        onItemChanged?.Invoke();

        return true;
    }
}