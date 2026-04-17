using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    Dictionary<string, int> items = new Dictionary<string, int>();

    void Awake()
    {
        instance = this;
    }

    public void AddItem(string name, int amount)
    {
        if (items.ContainsKey(name))
            items[name] += amount;
        else
            items.Add(name, amount);

        Debug.Log(name + " ÇèEÇ¡ÇΩ");
    }

    public void MoveAllToBox()
    {
        foreach (var item in items)
        {
            Debug.Log(item.Key + " x" + item.Value + " Çëqå…Ç…ì¸ÇÍÇΩ");
        }

        items.Clear();
    }
}