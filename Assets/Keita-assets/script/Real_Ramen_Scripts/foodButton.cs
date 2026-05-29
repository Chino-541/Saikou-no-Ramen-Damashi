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

    [SerializeField] foodType food;
    [SerializeField] Cook cook;
    [SerializeField] Image centerSlot;
    [SerializeField] Image myImage;
    [SerializeField] TMP_Text countText;

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
        button.interactable = false;

        if (GetCount() <= 0) return;

        centerSlot.sprite = myImage.sprite;
        centerSlot.color = Color.white;

        DecreaseCount();
        UpdateCountText();

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

    // Reset 用
    public void ResetButton()
    {
        // ボタンを押せるように戻す
        button.interactable = true;

        // UI の数字を更新
        UpdateCountText();

        // スロット画像を消す
        centerSlot.sprite = null;
        centerSlot.color = new Color(1, 1, 1, 0); // 透明にする
    }
}
