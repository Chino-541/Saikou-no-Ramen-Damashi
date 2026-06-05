using UnityEngine;
using UnityEngine.UI;

public class foodSlot : MonoBehaviour
{
    [SerializeField] Image slotImage;

    ItemData currentItem;

    public void SetItem(ItemData item)
    {
        currentItem = item;

        slotImage.sprite = item.icon;
        slotImage.color = Color.white;
    }

    public ItemData GetItem()
    {
        return currentItem;
    }

    public bool IsEmpty()
    {
        return currentItem == null;
    }
    public void ClearItem()
    {
        currentItem = null;

        slotImage.sprite = null;
        slotImage.color = new Color(1, 1, 1, 0);
    }
}