using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Create : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickButton);
    }

    void OnClickButton()
    {
        // 最新ステータスを保存
        RamenStatusManager.Instance.CalculateStatus();

        // スコア Debug
        Debug.Log("素材スコア ");
        Debug.Log("素材スコア合計: " + FoodScoreData.score);
    
        SceneManager.LoadScene("Customer");
    }
}
