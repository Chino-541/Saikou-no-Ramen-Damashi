using UnityEngine;
using TMPro;

public class SlotVeg : MonoBehaviour
{
    public int VeCount = 0;
    [SerializeField] TMP_Text countText;

    // スロットの値を増やす
    public void VegCount()
    {
        VeCount++;
        countText.text = VeCount.ToString();
    }

    // 消費に関する処理
    public int Minus()
    {
        if (VeCount <= 0)
        {
            Debug.Log("野菜がありません");
            return 0;   
        }

        int used = VeCount;  // 消費量
        VeCount = 0;         // 0まで減らす
        countText.text = VeCount.ToString();

        return used;         // 消費量を返す
    }
}
