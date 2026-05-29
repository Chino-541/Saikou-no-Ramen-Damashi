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

    [SerializeField] foodType food; // ← 種類を選ぶ
    [SerializeField] TMP_Text countText;

    int count = 0;

    // スロットの値を増やす
    public void AddCount()
    {
        count++;
        countText.text = count.ToString();
    }

    // 消費処理（全部使う）
    public int Minus()
    {
        if (count <= 0)
        {
            Debug.Log(GetNoItemMessage());
            return 0;
        }

        int used = count;
        count = 0;
        countText.text = count.ToString();

        return used;
    }

    // 種類ごとのメッセージ
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
}
