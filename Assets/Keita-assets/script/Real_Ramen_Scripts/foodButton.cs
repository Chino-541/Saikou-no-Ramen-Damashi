using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class foodButton : MonoBehaviour
{
    [SerializeField] ItemData itemData;
    [SerializeField] foodSlot[] slots;
    [SerializeField] TMP_Text countText;

    Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickFoodButton);

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

                Inventory.instance.RemoveItem(itemData, 1);

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
        return Inventory.instance.GetItemCount(itemData);
    }
}