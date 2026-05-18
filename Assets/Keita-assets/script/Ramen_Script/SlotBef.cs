using UnityEngine;
using TMPro;

public class SlotBef : MonoBehaviour
{
    public int usedCount = 0;
    [SerializeField] TMP_Text countText;

    public void BefCount()
    {
        usedCount++;
        countText.text = usedCount.ToString();
    }
}
