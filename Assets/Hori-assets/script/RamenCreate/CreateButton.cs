using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateButton : MonoBehaviour
{
    [SerializeField] private string nextSceneName;
    public void OnClickCreate()
    {
        // ラーメンのステータスを保持
        RamenData.Instance.salt = RamenStatusManager.Instance.Salt;
        RamenData.Instance.umami = RamenStatusManager.Instance.Umami;
        RamenData.Instance.spicy = RamenStatusManager.Instance.Spicy;
        RamenData.Instance.fat = RamenStatusManager.Instance.Fat;
        RamenData.Instance.mystery = RamenStatusManager.Instance.Mystery;

        Debug.Log("ステータスを保存しました");

        // シーンを移動
        SceneManager.LoadScene(nextSceneName);
    }

}
