using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI poinText;
    [SerializeField] private TextMeshProUGUI totalScoreText;

    private int point = 0;   // 販売した数
    private int score = 0;   // スコア

    [SerializeField] private MiniGameManager miniGameManager;

    void Start()
    {
        miniGameManager.OnMiniGameEnd += (isCorrect) =>
        {
            if (isCorrect)
            {
                AddPoint();
                AddScore50();
                UpdateUI();
            }
            else
            {
                MinScore();
                UpdateUI();
            }
        };
    }

    public void AddPoint()
    {
        point++;
        ScoreData.point = point;   // 保存
    }

    public void MinScore()
    {
        score -= 30;
        ScoreData.score = score;   // 保存
    }

    public void AddScore50()
    {
        score += 50;
        ScoreData.score = score;   // 保存
    }

    private void UpdateUI()
    {
        poinText.text = "販売数：" + point;
        totalScoreText.text = "Score：" + CalculateTotalScore();
    }

    public int CalculateTotalScore()
    {
        int ramenScore = 0;
        int total = ramenScore * point + score + FoodScoreData.score;
        return total;
    }
}
