using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer2 : MonoBehaviour
{
    // カウントダウン
    [SerializeField] private float countdownTime = 3;
    [SerializeField] private TextMeshProUGUI countdownText;

    // ゲーム時間
    [SerializeField] private float timeLimit = 60;
    [SerializeField] private TextMeshProUGUI timeText;

    // player関連
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private Player player;

    // シーン遷移
    [SerializeField] private string SceneName;

    // 終了時の文字
    [SerializeField] private TextMeshProUGUI finishText;

    private bool isFinished = false;
    private bool isCounting = false;
    public System.Action OnTimeUp;

    private CustomerSpawner spawner;

    private void Start()
    {
        timeText.gameObject.SetActive(false);
        countdownText.gameObject.SetActive(false);
        finishText.gameObject.SetActive(false);

        CountDown();
    }

    // 開始前カウントダウン
    void CountDown()
    {
        isCounting = true;
        StartCoroutine(CountdownCoroutine());
    }

    IEnumerator CountdownCoroutine()
    {
        timeText.gameObject.SetActive(true);
        countdownText.gameObject.SetActive(true);

        float countdown = countdownTime;
        while (countdown > 0)
        {
            player.DisableInput(3f);
            countdownText.text = countdown.ToString("F0");
            yield return new WaitForSeconds(1f);
            countdown--;
        }

        countdownText.text = "開始！";
        yield return new WaitForSeconds(1f);

        countdownText.gameObject.SetActive(false);
        isCounting = false;

        StartCoroutine(TimerLoop());
    }
    // タイマーのコルーチン
    IEnumerator TimerLoop()
    {

        while (timeLimit > 0)
        {
            timeLimit--;

            int minutes = Mathf.FloorToInt(timeLimit / 60);
            int seconds = Mathf.FloorToInt(timeLimit % 60);

            timeText.text = $"{minutes:00}:{seconds:00}";

            if (timeLimit == 3)
            {
                timeText.gameObject.SetActive(false);
                StartCoroutine(LastCountdown());
            }

            if (timeLimit <= 0)
            {
                timeLimit = 0;
                FinishTimer();
            }

            yield return new WaitForSeconds(1);
        }

        playerRb.constraints = RigidbodyConstraints2D.FreezePositionX |
                               RigidbodyConstraints2D.FreezePositionY;

        OnTimeUp?.Invoke();
    }
    // 残り３秒のカウントダウン
    IEnumerator LastCountdown()
    {
        countdownText.gameObject.SetActive(true);

        float countdown2 = 3;
        while (countdown2 > 0)
        {
            countdownText.text = countdown2.ToString("F0");
            yield return new WaitForSeconds(1f);
            countdown2--;
        }

        countdownText.text = "終了！";
        yield return new WaitForSeconds(1f);

        countdownText.gameObject.SetActive(false);
    }
    // ゲーム終了処理
    void FinishTimer()
    {
        isFinished = true;

        player.DisableInput(9999f);

        finishText.gameObject.SetActive(true);
        finishText.text = "終了！";

        StartCoroutine(ChangeScene());
    }
    // シーン切り替えのコルーチン
    private IEnumerator ChangeScene()
    {
        // 3秒待ってシーン遷移
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneName);
    }
}
