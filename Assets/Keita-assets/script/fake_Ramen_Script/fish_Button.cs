using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class fish_Button : MonoBehaviour
{
    [SerializeField] Cook cook;
    [SerializeField] Image centerSlot;
    [SerializeField] Image myImage;
    [SerializeField] TMP_Text countText;
    [SerializeField] SlotFis slotCounter;

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
        // 押した瞬間にボタン無効化（1回だけ押せる）
        button.interactable = false;

        if (cook.fish <= 0) return;

        centerSlot.sprite = myImage.sprite;
        centerSlot.color = Color.white;

        cook.fish--;
        UpdateCountText();

        slotCounter.FisCount();
    }

    void UpdateCountText()
    {
        countText.text = cook.fish.ToString();
    }
}
