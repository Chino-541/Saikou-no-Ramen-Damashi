using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookingManager : MonoBehaviour
{
    public static CookingManager instance;

    [System.Serializable]
    public class CookingItem
    {
        public ItemData itemData;
    }

    public List<CookingItem> cookingItems =
        new List<CookingItem>();

    public Image[] cookingSlotIcons;

    public Sprite emptySprite;

    void Awake()
    {
        instance = this;
    }

    // ëfçﬁí«â¡
    public void AddMaterial(ItemData itemData)
    {
        if (cookingItems.Count >= 3)
            return;

        CookingItem item =
            new CookingItem();

        item.itemData = itemData;

        cookingItems.Add(item);

        RefreshSlots();
    }

    // ëfçﬁâèú
    public void RemoveMaterial(int index)
    {
        if (index < 0 ||
            index >= cookingItems.Count)
            return;

        cookingItems.RemoveAt(index);

        RefreshSlots();
    }

    // UIçXêV
    void RefreshSlots()
    {
        for (int i = 0;
             i < cookingSlotIcons.Length;
             i++)
        {
            if (i < cookingItems.Count)
            {
                cookingSlotIcons[i].sprite =
                    cookingItems[i]
                    .itemData.icon;
            }
            else
            {
                cookingSlotIcons[i].sprite =
                    emptySprite;
            }
        }
    }
}