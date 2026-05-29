using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class vegetable_Button : MonoBehaviour
{
    [SerializeField] Cook cook;
    [SerializeField] Image centerSlot;
    [SerializeField] Image myImage;
    [SerializeField] TMP_Text countText;
    [SerializeField] SlotVeg slotCounter;

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
        // 押した瞬間にボタン無効化（1回だけ押せる）
        button.interactable = false;

        if (cook.Vegetable <= 0) return;

        centerSlot.sprite = myImage.sprite;
        centerSlot.color = Color.white;

        cook.Vegetable--;
        UpdateCountText();

        slotCounter.VegCount();
    }

    void UpdateCountText()
    {
        countText.text = cook.Vegetable.ToString();
    }
}
