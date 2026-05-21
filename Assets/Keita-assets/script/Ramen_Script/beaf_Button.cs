using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class beaf_Button : MonoBehaviour
{
    [SerializeField] Cook cook;
    [SerializeField] Image centerSlot;
    [SerializeField] Image myImage;
    [SerializeField] TMP_Text countText;   // 所持数表示
    [SerializeField] SlotBef slotCounter; // スロット内部の数

    Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickBef);
        UpdateCountText();
    }

    void OnClickBef()
    {
        if (cook.beaf <= 0) return;

        // 画像移動
        centerSlot.sprite = myImage.sprite;
        centerSlot.color = Color.white;

        // 所持数を減らす
        cook.beaf--;
        UpdateCountText();

        // 中央スロットの使用数を増やす
        slotCounter.BefCount();

        if (cook.beaf <= 0)
        {
            button.interactable = false;
        }
    }

    void UpdateCountText()
    {
        countText.text = cook.beaf.ToString();
    }
}
