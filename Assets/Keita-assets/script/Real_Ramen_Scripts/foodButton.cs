using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class foodButton : MonoBehaviour
{
    [SerializeField] ItemData itemData;

    // [SerializeField] Image centerSlot;
    [SerializeField] foodSlot[] slots;
    [SerializeField] TMP_Text countText;

    Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickfoodButton);

        UpdateCountText();
    }

    void OnClickfoodButton()
    {
        if (GetCount() <= 0) return;

        foreach (foodSlot slot in slots)
        {
            if (slot.IsEmpty())
            {
                slot.SetItem(itemData);

                // 後でスライダー再計算
                // RamenStatusManager.Instance.CalculateAndApplyStatus();

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
        // return Inventory.instance.GetItemCount(itemData);
        // 仮でアイテムを持っている状態にしている
            return 1;
        
    }
}