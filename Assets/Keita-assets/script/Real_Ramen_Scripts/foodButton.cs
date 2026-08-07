using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class foodButton : MonoBehaviour
{
    [SerializeField] ItemData itemData;
    [SerializeField] foodSlot[] slots;
    [SerializeField] TMP_Text countText;
    [SerializeField] Image iconImage;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clickSE;

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

        // 同じ素材が既に入っているか確認
        foreach (foodSlot slot in slots)
        {
            if (slot.GetItem() == itemData)
            {
                Debug.Log("この素材は既に使用しています");
                return;
            }
        }

        // 空いている枠を探す
        foreach (foodSlot slot in slots)
        {
            if (slot.IsEmpty())
            {
                slot.SetItem(itemData);

                // ★ 所持数を取得
                int count = GetCount();

                // ★ 所持数分スコアを加算
                FoodScoreData.score += count;

                // ★ Debug 表示（圭汰の希望）
                Debug.Log($"選んだ食材: {itemData.name}");
                Debug.Log($"所持数: {count}");
                Debug.Log($"加算後のスコア: {FoodScoreData.score}");

                // SEを鳴らす
                audioSource.PlayOneShot(clickSE);

                // ステータス更新
                RamenStatusManager.Instance.CalculateStatus();

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
