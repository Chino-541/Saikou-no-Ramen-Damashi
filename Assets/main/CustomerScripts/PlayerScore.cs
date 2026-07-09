using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI poinText;
    [SerializeField] private TextMeshProUGUI totalScoreText;

    private int point = 0;   // 販売した数
    private int score = 0;   // スコア（+50 など）

    [SerializeField] private MiniGameManager miniGameManager;

    void Start()
    {
        // パネルが閉じたら販売数+1 & スコア+50
        miniGameManager.OnMiniGameEnd += () =>
        {
            AddPoint();     // ★販売数 +1
            AddScore50();   // ★スコア +50
            UpdateUI();     // UI更新
        };
    }

   
    public void AddPoint()
    {
        point++;
    }

    //  // ラーメンを1杯売ったとき(ミニゲーム終了時)
    public void AddScore50()
    {
        score += 50;
    }

    // UI 更新（販売数と合計スコア）
    private void UpdateUI()
    {
        poinText.text = "販売数：" + point;
        totalScoreText.text = "Score：" + CalculateTotalScore();
    }

    // 合計スコア計算
    
    public int CalculateTotalScore()
    {
        int ramenScore = 0;
        int total = ramenScore * point + score + FoodScoreData.score;
        return total;
    }
}
