using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    public Image icon;

    public TMP_Text countText;

    ItemData itemData;

    Button button;

    void Awake()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(OnClick);
    }

    public void SetItem(
        ItemData newItem,
        int count)
    {
        itemData = newItem;

        if (itemData == null)
        {
            icon.enabled = false;

            countText.text = "";

            return;
        }

        icon.enabled = true;

        icon.sprite = itemData.icon;

        countText.text = count.ToString();
    }

    void OnClick()
    {
        CookingManager.instance.AddMaterial(
            itemData);
    }
}