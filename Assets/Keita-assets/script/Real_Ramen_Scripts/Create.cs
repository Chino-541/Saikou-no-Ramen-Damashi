using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Create : MonoBehaviour
{
    [SerializeField] private GameObject completaPanel;
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickButton);
    }
    void LoadCustomerScene()
    {
        SceneManager.LoadScene("Customer");
    }

    void OnClickButton()
    {
        int itemCount = 0;

        foreach (foodSlot slot in RamenStatusManager.Instance.foodSlots)
        {
            if (slot.GetItem() != null)
            {
                itemCount++;
            }
        }

        if (itemCount < 4)
        {
            Debug.Log("素材を4つ入れてください！");
            return;
        }

        // 最新ステータスを保存
        RamenStatusManager.Instance.CalculateStatus();

        // スコア Debug
        Debug.Log("素材スコア ");
        Debug.Log("素材スコア合計: " + FoodScoreData.score);
    
        completaPanel.SetActive(true);
        Invoke(nameof(LoadCustomerScene), 2f);
    }
}
