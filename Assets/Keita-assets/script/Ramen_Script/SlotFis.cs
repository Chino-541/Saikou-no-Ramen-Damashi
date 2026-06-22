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

    public int Minus()
    {
        if (FiCount <= 0)
        {
            Debug.Log("‹›‚ª‚ ‚è‚Ü‚¹‚ñ");
            return 0;
        }

        FiCount--;
        countText.text = FiCount.ToString();
        return 1;
    }
}
