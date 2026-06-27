using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class foodButton : MonoBehaviour
{
    [SerializeField] ItemData itemData;
    [SerializeField] foodSlot[] slots;
    [SerializeField] TMP_Text countText;
    [SerializeField] Image iconImage;

    Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickFoodButton);

        UpdateCountText();
    }
    public void Setup(ItemData item, foodSlot[] targetSlots)
    {
        itemData = item;
        slots = targetSlots;

        iconImage.sprite = item.icon;

        UpdateCountText();
    }

    void OnClickFoodButton()
    {
        if (GetCount() <= 0)
            return;

        foreach (foodSlot slot in slots)
        {
            if (slot.IsEmpty())
            {
                slot.SetItem(itemData);

                Storage.instance.RemoveItem(itemData, 1);

                UpdateCountText();

                break;
            }
        }
    }

    void UpdateCountText()
    {
        countText.text = GetCount().ToString();
    }

    int GetCount()
    {
        return Storage.instance.GetItemCount(itemData);
    }
}