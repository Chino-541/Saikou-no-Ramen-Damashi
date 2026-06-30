using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI poinText;
    [SerializeField] private TextMeshProUGUI totalScoreText;

    private int poin = 0;

    public void AddPoin()
    {
        poin++;
        poinText.text = "îÃîÑÇµÇΩêîÅF" + poin;
    }

    public int CalculateTotalScore()
    {
        int ramenScore = 1;
        int total = ramenScore * poin + FoodScoreData.score;

        totalScoreText.text = "çáåvÅF" + total;
        return total;
    }
}
