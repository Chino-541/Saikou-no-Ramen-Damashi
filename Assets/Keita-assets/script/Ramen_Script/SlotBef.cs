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

    public int Minus()
    {
        if (BeCount <= 0)
        {
            Debug.Log("‚¨“÷‚ª‚ ‚è‚Ü‚¹‚ñ");
            return 0;
        }

        BeCount--;
        countText.text = BeCount.ToString();
        return 1;
    }
}
