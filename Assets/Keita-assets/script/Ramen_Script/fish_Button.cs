using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class fish_Button : MonoBehaviour
{
    [SerializeField] Cook cook;　// 数を格納しているコード
    [SerializeField] Image centerSlot;　// 移動先のスロット
    [SerializeField] Image myImage;　// ボタンの画像
    [SerializeField] TMP_Text countText;   // 数を表示するUI
    [SerializeField] SlotFis slotCounter; // スロットの数字

    Button button;

    void Start()
    {
        cook = FindAnyObjectByType<Cook>();
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickFis);
        UpdateCountText();
    }

    void OnClickFis()
    {
        // 数が0以下だと押せない
        if (cook.fish <= 0) return;

        // 画像をスロットに移動
        centerSlot.sprite = myImage.sprite;
        centerSlot.color = Color.white;

        // 数を減らす
        cook.fish--;
        UpdateCountText();

        // 移動先のスロットに数を移す
        slotCounter.FisCount();

        if (cook.fish <= 0)
        {
            button.interactable = false;
        }
    }

    void UpdateCountText()
    {
        //　魚の数をUIに表示する
        countText.text = cook.fish.ToString();
    }
}
