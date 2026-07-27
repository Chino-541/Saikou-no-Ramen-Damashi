using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class PlayerScore : MonoBehaviour
{
    // playerの参照
    [SerializeField] private Ken_PChar Ken;
    // スコアのテキスト
    [SerializeField] private TextMeshProUGUI poinText;
    [SerializeField] private TextMeshProUGUI totalScoreText;
    // ボーナスまで
    [SerializeField] private TextMeshProUGUI BonusText;
    private int point = 0;   // 販売した数
    private int score = 0;   // スコア

    public int Soldpoint = 5;
    [SerializeField] private MiniGameManager miniGameManager;
    private bool bonusStarted = false;

    void Start()
    {
        UpdateUI();
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

    private void Update()
    {
        if (Soldpoint <= 5 && !bonusStarted)
        {
            bonusStarted = true;
            StartCoroutine(Ken.BonusTime());  // ← Ken の BonusTime を呼ぶ
            bonusStarted = false;
        }
    }
    public void AddPoint()
    {
        point++;
        ScoreData.point = point;   // 保存
    }

    public void MinScore()
    {
        Soldpoint++;
        score -= 30;
        ScoreData.score = score;   // 保存
    }

    public void AddScore50()
    {
        Soldpoint--;
        score += 50;
        ScoreData.score = score;   // 保存
    }

    private void UpdateUI()
    {
        poinText.text = "販売数：" + point;
        totalScoreText.text = "Score：" + CalculateTotalScore();
        BonusText.text = "ボーナスまであと: " + Soldpoint;
    }

    public int CalculateTotalScore()
    {
        int ramenScore = 0;
        int total = ramenScore * point + score + FoodScoreData.score;
        return total;
    }


    
}
