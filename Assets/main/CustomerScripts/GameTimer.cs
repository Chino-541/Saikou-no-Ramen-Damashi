using UnityEngine;
using TMPro;
using System.Collections;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private int timeLimit = 60;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private Rigidbody2D playerRb;

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
            timeText.color = (timeLimit % 2 == 0) ? Color.red : Color.blue;

            yield return new WaitForSeconds(1);
        }

        spawner.canSpawn = false;

        playerRb.constraints = RigidbodyConstraints2D.FreezePositionX |
                               RigidbodyConstraints2D.FreezePositionY;

        OnTimeUp?.Invoke();
    }
}
