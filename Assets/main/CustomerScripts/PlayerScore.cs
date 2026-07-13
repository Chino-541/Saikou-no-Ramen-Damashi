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
        // 正解・不正解を受け取る
        miniGameManager.OnMiniGameEnd += (isCorrect) =>
        {
            if (isCorrect)
            {
                AddPoint();     // 販売数 +1
                AddScore50();   // スコア +50
                UpdateUI();     // UI更新
            }
            else
            {
                Debug.Log("不正解");
                MinScore();
                UpdateUI();
            }
        };
    }

    public void AddPoint()
    {
        point++;
    }
    public void MinScore()
    {
        score -= 30;
    }
    public void AddScore50()
    {
        score += 50;
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
