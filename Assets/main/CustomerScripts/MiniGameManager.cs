using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MiniGameManager : MonoBehaviour
{
    [SerializeField] private GameObject miniGameUI;
    [SerializeField] private float hideTime = 3f;
    [SerializeField] private PlayerScore Score;
    [SerializeField] private QuestionDatabase database;
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private Button[] buttons;

    public System.Action OnMiniGameEnd;

    private Question currentQuestion;

    void Start()
    {
        miniGameUI.SetActive(false);
    }

    public void MiniGame()
    {
        miniGameUI.SetActive(true);
        SetupQuestion();
    }

    private void SetupQuestion()
    {
        // ランダムで問題を取得
        currentQuestion = database.GetRandomQuestion();

        // 問題文を表示
        questionText.text = currentQuestion.text;

        // ボタンにイベント登録
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;
            buttons[i].onClick.RemoveAllListeners();
            buttons[i].onClick.AddListener(() => OnButtonClicked(index));
        }
    }

    private void OnButtonClicked(int index)
    {
        if (index == currentQuestion.correctIndex)
        {
            Debug.Log("正解！");
        }
        else
        {
            Debug.Log("不正解！");
        }

        StartCoroutine(HideMiniGameUI());
    }

    private IEnumerator HideMiniGameUI()
    {
        yield return new WaitForSeconds(hideTime);

        miniGameUI.SetActive(false);

        // ミニゲーム終了通知
        OnMiniGameEnd?.Invoke();
    }
}
