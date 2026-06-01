using UnityEngine;
using TMPro;

public class foodSlot : MonoBehaviour
{
    public enum foodType
    {
        Beaf,
        Fish,
        Vegetable
    }

    [SerializeField] foodType food;
    [SerializeField] TMP_Text countText;

    int count = 0;

    public void AddCount()
    {
        count++;
        countText.text = count.ToString();
    }

    public int Minus()
    {
        if (count <= 0)
        {
            Debug.Log(GetNoItemMessage());
            return 0;
        }

        int used = count;
        count = 0;
        countText.text = "0";

        return used;
    }

    string GetNoItemMessage()
    {
        return food switch
        {
            foodType.Beaf => "お肉がありません",
            foodType.Fish => "魚がありません",
            foodType.Vegetable => "野菜がありません",
            _ => "アイテムがありません"
        };
    }

    // ★ Getter を追加（foodButton が参照する）
    public int GetCount()
    {
        return count;
    }

    // Reset 用
    public void ResetCount()
    {
        count = 0;
        countText.text = "0";
    }
}
