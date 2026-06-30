using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class Timer : MonoBehaviour
{
    public float timeLeft = 60f;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI finishText;
    public string SceneName;
    public Fadein fadein;

    public Player player;   // Player を Inspector でセットする

    private bool isFinished = false;

    void Start()
    {
        finishText.gameObject.SetActive(false);
    }

    void Update()
    {
        // フェードインが終わるまでタイマー停止
        if (!fadein.IsFinished)
            return;

        if (isFinished)
            return;

        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0)
        {
            timeLeft = 0;
            FinishTimer();
        }

        int minutes = Mathf.FloorToInt(timeLeft / 60);
        int seconds = Mathf.FloorToInt(timeLeft % 60);

        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    void FinishTimer()
    {
        isFinished = true;

        //  時間切れ → Player を停止
        player.DisableInput(9999f);

        finishText.gameObject.SetActive(true);
        finishText.text = "終了！";

        StartCoroutine(ChangeSceneAfterDelay());
    }

    private IEnumerator ChangeSceneAfterDelay()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneName);
    }
}
