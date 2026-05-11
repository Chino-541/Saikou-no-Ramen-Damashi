using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    public Image icon;

    public TMP_Text countText;

    string itemName;

    Sprite itemIcon;

    Button button;

    void Awake()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(OnClick);
    }

    public void SetItem(
        string newItemName,
        Sprite sprite,
        int count)
    {
        itemName = newItemName;

        itemIcon = sprite;

        if (sprite == null)
        {
            icon.enabled = false;

            countText.text = "";

            return;
        }

        icon.enabled = true;

        icon.sprite = sprite;

        countText.text = count.ToString();
    }

    void OnClick()
    {
        CookingManager.instance.AddMaterial(
            itemName,
            itemIcon);
    }
}