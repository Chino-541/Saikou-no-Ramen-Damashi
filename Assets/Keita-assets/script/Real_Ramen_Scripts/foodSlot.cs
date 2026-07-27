using UnityEngine;
using UnityEngine.UI;

public class foodSlot : MonoBehaviour
{
    [SerializeField] Image iconImage;

    ItemData currentItem;

    public bool IsEmpty()
    {
        return currentItem == null;
    }

    public void SetItem(ItemData item)
    {
        currentItem = item;

        iconImage.sprite = item.icon;
        iconImage.color = Color.white;
    }

    public ItemData GetItem()
    {
        return currentItem;
    }

    public void Clear()
    {
        currentItem = null;

        iconImage.sprite = null;
        iconImage.color = new Color(1, 1, 1, 0);
    }

}