using UnityEngine;
using TMPro;

public class ResultUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointText;
    [SerializeField] private TextMeshProUGUI scoreText;

    void Start()
    {
        pointText.text = "îÃîÑêîÅF" + ScoreData.point;
        scoreText.text = "îÑè„ÅF" + ScoreData.score + "â~";
    }
}
