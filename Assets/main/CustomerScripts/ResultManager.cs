using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{

    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private TextMeshProUGUI winScoreText;
    [SerializeField] private TextMeshProUGUI loseScoreText;

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
