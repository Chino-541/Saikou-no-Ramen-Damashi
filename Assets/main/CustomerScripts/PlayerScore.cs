using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    // ラーメン販売数のテキスト
    [SerializeField] private TextMeshProUGUI poinText;
    // 合計スコアのテキスト
    [SerializeField] private TextMeshProUGUI totalScoreText;
    // ラーメン販売数
    private int poin = 0;

    public void AddPoin()
    {
        poin++;
        // ラーメン販売数の更新
        poinText.text = "販売した数：" + poin;
    }

    public int CalculateTotalScore()
    {
        // ラーメンのスコア
        int ramenScore = 1;
        // 合計スコアの計算(スコア*販売数+追加スコア)
        int total = ramenScore * poin + FoodScoreData.score;
        // 合計スコアの更新
        totalScoreText.text = "合計：" + total;
        // 合計スコアを返す
        return total;
    }
}
