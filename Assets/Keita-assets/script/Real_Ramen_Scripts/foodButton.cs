using NUnit.Framework.Interfaces;
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
    // アイテムデータ
    [SerializeField] private ItemData itemData;
    // 食材の種類選ぶ
    [SerializeField] foodType food;
    // scriptがついてるオブジェクトをアタッチ
    [SerializeField] Cook cook;
    // スロットの画像
    [SerializeField] Image centerSlot;
    // ボタンの画像
    [SerializeField] Image myImage;
    // ボタンの食材UI
    [SerializeField] TMP_Text countText;
    // スロットアタッチ
    [SerializeField] SlotBef slotBef;
    [SerializeField] SlotFis slotFis;
    [SerializeField] SlotVeg slotVeg;

    [SerializeField] FoodData foodData;
    // スライダーをアタッチ
    [SerializeField] private Slider[] sliders = new Slider[5];
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
        if (GetCount() <= 0) return;

        button.interactable = false;

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

        // 味ステータスを Slider に反映
        sliders[0].value += itemData.saltiness;
        sliders[1].value += itemData.umami;
        sliders[2].value += itemData.spiciness;
        sliders[3].value += itemData.fatness;
        sliders[4].value += itemData.mystery;

        //  FoodData に保存
        foodData.SetData(cook.beaf, cook.fish, cook.Vegetable);
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

    public void ResetButton()
    {
        button.interactable = true;
        

        UpdateCountText();
        centerSlot.sprite = null;
        centerSlot.color = new Color(1, 1, 1, 0);
        for (int i = 0; i < sliders.Length; i++)
        {
            sliders[i].value = 0;
        }
    }
}
