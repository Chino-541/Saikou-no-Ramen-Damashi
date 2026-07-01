using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
　　// 勝利画面
    [SerializeField] private GameObject winPanel;
    // 敗北画面
    [SerializeField] private GameObject losePanel;
    // 勝利時のスコア表示
    [SerializeField] private TextMeshProUGUI winScoreText;
    // 敗北時のスコア表示
    [SerializeField] private TextMeshProUGUI loseScoreText;
    // ライバルとスコア比較して表示パネル判別
    public void ShowResult(int playerScore, int rivalScore)
    {
        if (playerScore > rivalScore)
        {
            winScoreText.text = playerScore.ToString();
            winPanel.SetActive(true);
        }
        else
        {
            loseScoreText.text = playerScore.ToString();
            losePanel.SetActive(true);
        }
    }
}
