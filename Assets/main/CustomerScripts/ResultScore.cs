using UnityEngine;
using TMPro;

public class ResultUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointText;
    [SerializeField] private TextMeshProUGUI scoreText;

    void Start()
    {
        pointText.text = "”Ì”„”F" + ScoreData.point;
        scoreText.text = "ScoreF" + ScoreData.score;
    }
}
