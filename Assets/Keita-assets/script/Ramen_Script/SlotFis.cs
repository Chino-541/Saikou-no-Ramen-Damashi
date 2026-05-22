using UnityEngine;
using TMPro;

public class SlotFis : MonoBehaviour
{
    public int FiCount = 0;
    [SerializeField] TMP_Text countText;

    // ”‚ğ‘‚â‚·
    public void FisCount()
    {
        FiCount++;
        countText.text = FiCount.ToString();
    }

    // ”‚ğŒ¸‚ç‚µ‚ÄUI‚ÌXV
    public void Minus()
    {
        if (FiCount <= 0)
        {
            Debug.Log("‹›");
            return;
        }

        FiCount--;
        countText.text = FiCount.ToString();
    }
}
