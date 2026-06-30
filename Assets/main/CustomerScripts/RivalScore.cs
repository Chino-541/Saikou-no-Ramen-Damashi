using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class RivalScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI rivalScoreText;
    [SerializeField] private Slider rivalSlider;

    private int rivalScore = 0;

    public int GetRivalScore() => rivalScore;

    public void StartRival()
    {
        StartCoroutine(RivalLoop());
    }

    IEnumerator RivalLoop()
    {
        while (true)
        {
            int delay = Random.Range(3, 6);

            rivalSlider.maxValue = delay * 100f;
            rivalSlider.value = rivalSlider.maxValue;

            float t = delay;
            while (t > 0)
            {
                t -= Time.deltaTime;
                rivalSlider.value = (t / delay) * rivalSlider.maxValue;
                yield return null;
            }

            rivalScore++;
            rivalScoreText.text = rivalScore.ToString();
        }
    }
}
