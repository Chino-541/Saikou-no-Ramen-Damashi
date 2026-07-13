using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MiniGameManager : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    // 問題のパネル
    [SerializeField] private GameObject miniGameUI;
    // 消えるまでの時間
    [SerializeField] private float hideTime = 3f;
    // 注文データ
    [SerializeField] private QuestionDatabase database;
    // 注文のテキスト
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private Button[] buttons;

    // 正解かどうかを渡すイベント
    public System.Action<bool> OnMiniGameEnd;
    
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
        currentQuestion = database.GetRandomQuestion();
        questionText.text = currentQuestion.text;

        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;
            buttons[i].onClick.RemoveAllListeners();
            buttons[i].onClick.AddListener(() => OnButtonClicked(index));
        }
    }

    private void OnButtonClicked(int index)
    {
        bool isCorrect = index == currentQuestion.correctIndex;

        if (isCorrect)
            Debug.Log("正解！");
        else
            Debug.Log("不正解！");

        StartCoroutine(HideMiniGameUI(isCorrect));
    }

    private IEnumerator HideMiniGameUI(bool isCorrect)
    {
        
        miniGameUI.SetActive(false);
        yield return new WaitForSeconds(hideTime);
        // アニメーションの処理をしたい
     

        // 正解かどうかを通知
        OnMiniGameEnd?.Invoke(isCorrect);
    }
}
