using UnityEngine;
using TMPro;

public class SlotFis : MonoBehaviour
{
    public int usedCount = 0;
    [SerializeField] TMP_Text countText;

    public void FisCount()
    {
        usedCount++;
        countText.text = usedCount.ToString();
    }
}
