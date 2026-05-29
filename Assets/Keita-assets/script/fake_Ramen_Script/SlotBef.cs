using UnityEngine;
using TMPro;

public class SlotBef : MonoBehaviour
{
    public int BeCount = 0;
    [SerializeField] TMP_Text countText;

    public void BefCount()
    {
        BeCount++;
        countText.text = BeCount.ToString();
    }
    // Á”ï‚ÉŠÖ‚·‚éˆ—
    public int Minus()
    {
        if (BeCount <= 0)
        {
            Debug.Log("‚¨“÷‚ª‚ ‚è‚Ü‚¹‚ñ");
            return 0;
        }

        int used = BeCount;  // ¡‰ñÁ”ï‚µ‚½—Ê
        BeCount = 0;         // ˆê‹C‚É 0 ‚É‚·‚é
        countText.text = BeCount.ToString();

        return used;         // Á”ï—Ê‚ğ•Ô‚·
    }

}
