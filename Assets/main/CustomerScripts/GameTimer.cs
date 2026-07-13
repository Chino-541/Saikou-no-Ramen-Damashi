using System.Collections;
using TMPro;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    // 時間
    [SerializeField] private float timeLimit = 60;
    [SerializeField] private TextMeshProUGUI timeText;
    // player関連
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private Ken_PChar player;
    // シーン遷移の時に使う
    [SerializeField] private string SceneName;
    // 終了したときの文字
    [SerializeField] private TextMeshProUGUI finishText;

    private bool isFinished = false; 

    public System.Action OnTimeUp;

    private CustomerSpawner spawner;

    private void Start()
    {
        spawner = FindObjectOfType<CustomerSpawner>();
        spawner.canSpawn = true;

        StartCoroutine(TimerLoop());
    }

    IEnumerator TimerLoop()
    {
        while (timeLimit > 0)
        {
            timeLimit--;
            timeText.text = timeLimit.ToString();

            if(timeLimit < 5)
            {
                timeText.text = timeLimit.ToString();
                timeText.color = (timeLimit % 2 == 0) ? Color.red : Color.white;
            }
            
            if(timeLimit <= 0)
            {
                timeLimit = 0;
                FinishTimer();
            }

            yield return new WaitForSeconds(1);
        }

        spawner.canSpawn = false;

        playerRb.constraints = RigidbodyConstraints2D.FreezePositionX |
                               RigidbodyConstraints2D.FreezePositionY;

        OnTimeUp?.Invoke();
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
         yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneName);
    }
}
