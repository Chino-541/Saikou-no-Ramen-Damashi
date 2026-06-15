using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeLeft = 60f;
    public TextMeshProUGUI timerText;

    public Fadein fadein;   // フェードイン
    public Fadeout fadeout; // フェードアウト

    void Update()
    {
        // フェードインが終わるまでタイマーを止める
        if (!fadein.IsFinished)
            return;

        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0)
        {
            timeLeft = 0;

            // タイマー終了 → Fadeout 開始
            if (!fadeout.Started)
            {
                fadeout.Started = true;
            }
        }

        int minutes = Mathf.FloorToInt(timeLeft / 60);
        int seconds = Mathf.FloorToInt(timeLeft % 60);

        timerText.text = $"{minutes:00}:{seconds:00}";
    }
}
