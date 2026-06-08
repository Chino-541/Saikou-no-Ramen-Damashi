using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TMP_CountdownTimer : MonoBehaviour
{
    public float timeLeft = 60f;
    public TextMeshProUGUI timerText;
    public string nextSceneName = "NextScene";

    void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft < 0)
        {
            timeLeft = 0;
            SceneManager.LoadScene(nextSceneName); 
        }

        int minutes = Mathf.FloorToInt(timeLeft / 60);
        int seconds = Mathf.FloorToInt(timeLeft % 60);

        timerText.text = $"{minutes:00}:{seconds:00}";
    }
}