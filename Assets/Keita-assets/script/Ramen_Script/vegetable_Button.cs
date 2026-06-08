using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class vegetable_Button : MonoBehaviour
{
    // 他2つの食材のボタンとほぼ一緒
    [SerializeField] Cook cook; // 食材の数を格納してるやつ
    [SerializeField] Image centerSlot; // 移動先のスロット
    [SerializeField] Image myImage; // 食材の画像
    [SerializeField] TMP_Text countText;   // 所持数
    [SerializeField] SlotVeg slotCounter; // スロットに表示されるUI

    Button button;

    void Start()
    {
        cook = FindAnyObjectByType<Cook>();
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickVeg);
        UpdateCountText();
    }

    void OnClickVeg()
    {
        // 0以下ならボタンを押せない
        if (cook.Vegetable <= 0) return;

        // 画像移動
        centerSlot.sprite = myImage.sprite;
        centerSlot.color = Color.white;

        // 食材の数を減らす
        cook.Vegetable--;
        UpdateCountText();

        // スロットの数値を増やす
        slotCounter.VegCount();

        // 0以下ならボタン押せない
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
