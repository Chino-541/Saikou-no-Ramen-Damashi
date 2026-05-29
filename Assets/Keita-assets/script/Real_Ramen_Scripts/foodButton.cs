using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class foodButton : MonoBehaviour
{
    [SerializeField] ItemData itemData;

    [SerializeField] Image centerSlot;
    [SerializeField] Image myImage;
    [SerializeField] TMP_Text countText;

    Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickfoodButton);

        UpdateCountText();
    }

    void OnClickfoodButton()
    {
        // 所持数0なら何もしない
        if (GetCount() <= 0) return;

        // 中央スロットへ表示
        centerSlot.sprite = myImage.sprite;
        centerSlot.color = Color.white;
    }

    void UpdateCountText()
    {
        countText.text = GetCount().ToString();
    }

    int GetCount()
    {
        return Inventory.instance.GetItemCount(itemData);
    }
}