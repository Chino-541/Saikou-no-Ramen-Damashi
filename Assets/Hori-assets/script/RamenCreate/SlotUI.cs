using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    public Image icon;
    public TMP_Text countText;
    public void SetItem(Sprite sprite, int count)
    {
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
}
