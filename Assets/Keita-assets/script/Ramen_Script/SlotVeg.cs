using UnityEngine;
using TMPro;

public class SlotVeg : MonoBehaviour
{
    public int VeCount = 0;
    [SerializeField] TMP_Text countText;

    // ”‚ğ‘‚â‚·
    public void VegCount()
    {
        VeCount++;
        countText.text = VeCount.ToString();
    }

    // ”‚ğŒ¸‚ç‚µ‚ÄUI‚ÌXV
    public void Minus()
    {
        if (VeCount <= 0)
        {
            Debug.Log("–ìØ");
            return;
        }

        VeCount--;
        countText.text = VeCount.ToString();
    }
}
