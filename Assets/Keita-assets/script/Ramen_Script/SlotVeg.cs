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

    // ”‚ğŒ¸‚ç‚µ‚Äu¡‰ñ‚ÌÁ”ï—Êv‚ğ•Ô‚·
    public int Minus()
    {
        if (VeCount <= 0)
        {
            Debug.Log("–ìØ‚ª‚ ‚è‚Ü‚¹‚ñ");
            return 0;   // Á”ï‚Å‚«‚È‚©‚Á‚½
        }

        VeCount--;
        countText.text = VeCount.ToString();
        return 1;       // 1ŒÂÁ”ï‚µ‚½
    }
}
