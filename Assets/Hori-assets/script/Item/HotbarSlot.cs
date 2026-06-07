using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HotbarSlot : MonoBehaviour
{
    public Image icon;

    public TMP_Text countText;

    public void SetItem(
        ItemData item,
        int count)
    {
        if (item == null)
        {
            icon.enabled = false;

            countText.text = "";

            return;
        }

        icon.enabled = true;

        icon.sprite = item.icon;

        countText.text = count.ToString();
    }
}