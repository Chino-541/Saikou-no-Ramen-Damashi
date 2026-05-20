using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class vegetable_Button : MonoBehaviour
{
    [SerializeField] Cook cook;
    [SerializeField] Image centerSlot;
    [SerializeField] Image myImage;
    [SerializeField] TMP_Text countText;   // 所持数表示
    [SerializeField] SlotVeg slotCounter; // ← 追加

    Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickVeg);
        UpdateCountText();
    }

    void OnClickVeg()
    {
        if (cook.Vegetable <= 0) return;

        // 画像移動
        centerSlot.sprite = myImage.sprite;
        centerSlot.color = Color.white;

        // 所持数を減らす
        cook.Vegetable--;
        UpdateCountText();

        // 中央スロットの使用数を増やす
        slotCounter.VegCount();

        if (cook.Vegetable <= 0)
        {
            button.interactable = false;
        }
    }

    void UpdateCountText()
    {
        countText.text = cook.Vegetable.ToString();
    }
}
