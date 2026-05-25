using UnityEngine;
using TMPro;

public class SlotFis : MonoBehaviour
{
    public int FiCount = 0;
    [SerializeField] TMP_Text countText;

    public void FisCount()
    {
        FiCount++;
        countText.text = FiCount.ToString();
    }

    // Á”ï‚ÉŠÖ‚·‚éˆ—
    public int Minus()
    {
        if (FiCount <= 0)
        {
            Debug.Log("‹›‚ª‚ ‚è‚Ü‚¹‚ñ");
            return 0;   
        }

        int used = FiCount;  // ¡‰ñ‚ÌÁ”ï—Ê
        FiCount = 0;         // 0‚Ü‚ÅŒ¸‚ç‚·
        countText.text = FiCount.ToString();

        return used;         // Á”ï—Ê‚ğ•Ô‚·
    }
}
