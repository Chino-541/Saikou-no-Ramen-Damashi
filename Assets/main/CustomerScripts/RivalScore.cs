using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class RivalScore : MonoBehaviour
{
    // ライバルのスコアを表示するテキスト
    [SerializeField] private TextMeshProUGUI rivalScoreText;
    // ライバルのスコアを表示するスライダー
    [SerializeField] private Slider rivalSlider;
    // 初期スコア
    private int rivalScore = 0;
    // 勝敗判定に使う関数？
    public int GetRivalScore() => rivalScore;

    public void StartRival()
    {
        // コルーチン開始
        StartCoroutine(RivalLoop());
    }

    IEnumerator RivalLoop()
    {
        while (true)
        {
            // ランダムで売る時間を決める？多分今のだと3から6秒の間
            int delay = Random.Range(3, 6);
            // スライダーの最大
            rivalSlider.maxValue = delay * 100f;
            rivalSlider.value = rivalSlider.maxValue;
            // スライダーが減っていく処理
            float t = delay;
            while (t > 0)
            {
                t -= Time.deltaTime;
                rivalSlider.value = (t / delay) * rivalSlider.maxValue;
                yield return null;
            }
            // テキスト更新とスコア増加
            rivalScore++;
            rivalScoreText.text = rivalScore.ToString();
        }
    }
}
