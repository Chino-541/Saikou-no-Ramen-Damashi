using UnityEngine;
using TMPro;

public class SlotVeg : MonoBehaviour
{
    public int usedCount = 0;
    [SerializeField] TMP_Text countText;

    public void VegCount()
    {
        usedCount++;
        countText.text = usedCount.ToString();
    }
}
