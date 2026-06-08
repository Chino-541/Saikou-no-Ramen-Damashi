using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class beaf_Button : MonoBehaviour
{
    // fish_Buttonと中身はほぼ同じ
    [SerializeField] Cook cook; // 数を格納してるコード
    [SerializeField] Image centerSlot; // 移動先のスロット
    [SerializeField] Image myImage; // 食材の画像
    [SerializeField] TMP_Text countText;   // 所持数表示
    [SerializeField] SlotBef slotCounter; // スロット内部の数

    Button button;

    void Start()
    {
        cook = FindAnyObjectByType<Cook>();
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickBef);
        UpdateCountText();
    }

    void OnClickBef()
    {
        // 0以下だとボタン押せません
        if (cook.beaf <= 0) return;

        // 画像をスロットに移動
        centerSlot.sprite = myImage.sprite;
        centerSlot.color = Color.white;

        // 数を減らす
        cook.beaf--;
        UpdateCountText();

        // 数をスロットのUIに移す
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
