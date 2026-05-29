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

    // スロットの値を増やす
    public void AddCount()
    {
        count++;
        countText.text = count.ToString();

        // 💡 カウントが増えたら自動でメーターを更新する
        if (RamenStatusManager.Instance != null)
        {
            RamenStatusManager.Instance.CalculateAndApplyStatus();
        }
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

        // 💡 カウントが減ったら自動でメーターを更新する
        if (RamenStatusManager.Instance != null)
        {
            RamenStatusManager.Instance.CalculateAndApplyStatus();
        }

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

    // 外部から食材のタイプを取得するための関数
    public foodType GetFoodType()
    {
        return food;
    }

    // 外部から現在の個数を取得するための関数
    public int GetCount()
    {
        return count;
    }
}