using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject slotPrefab;
    public Transform content;

    [System.Serializable]
    public class ItemIcon
    {
        public string itemName;
        public Sprite icon;
    }

    public List<ItemIcon> itemIcons;

    Dictionary<string, Sprite> iconDict =
        new Dictionary<string, Sprite>();

    void Start()
    {
        foreach (var item in itemIcons)
        {
            iconDict[item.itemName] = item.icon;
        }

        Inventory.instance.onItemChanged += RefreshUI;

        RefreshUI();
    }

    void RefreshUI()
    {
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }

        Dictionary<string, int> items =
            Inventory.instance.GetItems();

        foreach (var item in items)
        {
            GameObject slot =
                Instantiate(slotPrefab, content);

            SlotUI ui = slot.GetComponent<SlotUI>();

            Sprite icon = null;

            if (iconDict.ContainsKey(item.Key))
            {
                icon = iconDict[item.Key];
            }

            ui.SetItem(item.Key,icon, item.Value);
        }
    }
}