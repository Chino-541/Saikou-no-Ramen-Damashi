using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class foodButton : MonoBehaviour
{
    public enum foodType
    {
        Beaf,
        Fish,
        Vegetable
    }

    [SerializeField] foodType food; // ← ここで種類を選ぶ
    [SerializeField] Cook cook;
    [SerializeField] Image centerSlot;
    [SerializeField] Image myImage;
    [SerializeField] TMP_Text countText;

    // スロットのカウンター（種類ごとに違うので共通化できない）
    [SerializeField] SlotBef slotBef;
    [SerializeField] SlotFis slotFis;
    [SerializeField] SlotVeg slotVeg;

    Button button;

    void Start()
    {
        cook = FindAnyObjectByType<Cook>();
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickfoodButton);
        UpdateCountText();
    }

    void OnClickfoodButton()
    {
        // 1回押したら無効化
        button.interactable = false;

        // 数が0なら処理しない
        if (GetCount() <= 0) return;

        // スロットに画像をセット
        centerSlot.sprite = myImage.sprite;
        centerSlot.color = Color.white;

        // 数を減らす
        DecreaseCount();
        UpdateCountText();

        // スロットのカウント処理
        switch (food)
        {
            case foodType.Beaf:
                slotBef.BefCount();
                break;
            case foodType.Fish:
                slotFis.FisCount();
                break;
            case foodType.Vegetable:
                slotVeg.VegCount();
                break;
        }
    }

    void UpdateCountText()
    {
        countText.text = GetCount().ToString();
    }

    // 現在の数を取得
    int GetCount()
    {
        return food switch
        {
            foodType.Beaf => cook.beaf,
            foodType.Fish => cook.fish,
            foodType.Vegetable => cook.Vegetable,
            _ => 0
        };
    }

    // 数を減らす
    void DecreaseCount()
    {
        switch (food)
        {
            case foodType.Beaf:
                cook.beaf--;
                break;
            case foodType.Fish:
                cook.fish--;
                break;
            case foodType.Vegetable:
                cook.Vegetable--;
                break;
        }
    }
}
