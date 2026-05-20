using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class fish_Button : MonoBehaviour
{
    [SerializeField] Cook cook;
    [SerializeField] Image centerSlot;
    [SerializeField] Image myImage;
    [SerializeField] TMP_Text countText;   // 所持数
    [SerializeField] SlotFis slotCounter; // スロットの数字

    Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickFis);
        UpdateCountText();
    }

    void OnClickFis()
    {
        if (cook.fish <= 0) return;

        // 画像移動
        centerSlot.sprite = myImage.sprite;
        centerSlot.color = Color.white;

        // 所持数を減らす
        cook.fish--;
        UpdateCountText();

        // 中央スロットの使用数を増やす
        slotCounter.FisCount();

        if (cook.fish <= 0)
        {
            button.interactable = false;
        }
    }

    void UpdateCountText()
    {
        countText.text = cook.fish.ToString();
    }
}
