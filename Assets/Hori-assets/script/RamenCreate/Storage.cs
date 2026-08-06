using System.Collections.Generic;
using UnityEngine;
using System;
public class Storage : MonoBehaviour
{
    public static Storage instance;

    public event Action onItemChanged;

    Dictionary<ItemData, int> items =
        new Dictionary<ItemData, int>();

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

    public void AddItem(ItemData item, int amount)
    {
        if (!items.ContainsKey(item))
            items[item] = 0;

        items[item] += amount;

        onItemChanged?.Invoke();
    }

    public Dictionary<ItemData, int> GetItems()
    {
        return items;
    }

    public int GetItemCount(ItemData item)
    {
        if (items.ContainsKey(item))
            return items[item];

        return 0;
    }

    public void RemoveItem(ItemData item, int amount)
    {
        if (!items.ContainsKey(item))
            return;

        items[item] -= amount;

        if (items[item] <= 0)
            items.Remove(item);

        onItemChanged?.Invoke();
    }
    // ゲーム終了時のリセットのための関数
    public void Clearitems()
    {
        items.Clear();
        onItemChanged?.Invoke();
        Debug.Log("アイテム削除");
    }
}