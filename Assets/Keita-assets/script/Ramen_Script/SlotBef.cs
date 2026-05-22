using UnityEngine;
using TMPro;

public class SlotBef : MonoBehaviour
{
    public int BeCount = 0;
    [SerializeField] TMP_Text countText;

    // ”‚ğ‘‚â‚·
    public void BefCount()
    {
        BeCount++;
        countText.text = BeCount.ToString();
    }

    // ”‚ğŒ¸‚ç‚µ‚ÄUIXV

    public void Minus()
    {
        if (BeCount <= 0)
        {
            Debug.Log("‚¨“÷");
            return;
        }

        BeCount--;
        countText.text = BeCount.ToString();
    }
}