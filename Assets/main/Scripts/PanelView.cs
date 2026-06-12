using UnityEngine;

public class PanelView : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    // 釣りスクリプト参照
    [SerializeField] private Ken_GFish fishing;

    private void Start()
    {
        panel.SetActive(false);
    }

    void Update()
    {
        // 釣り中は説明パネルを開けない
        if (fishing != null && fishing)
        {
            if (panel.activeSelf)
            {
                panel.SetActive(false);
                Time.timeScale = 1f;
            }
            return;
        }

        RulePanel();
    }

    public void Onclickbutton()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RulePanel()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            panel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
