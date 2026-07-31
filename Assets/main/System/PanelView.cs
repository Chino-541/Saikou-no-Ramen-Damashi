using UnityEngine;

public class PanelView : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Fishing fishing;

    private void Start()
    {
        panel.SetActive(false);
    }

    void Update()
    {
        // íﬁÇËíÜÇÕê‡ñæÉpÉlÉãÇäJÇØÇ»Ç¢
        if (fishing != null && fishing._Fishing)
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
            if (panel.activeSelf)
            {
                panel.SetActive(false);
                Time.timeScale = 1f;
            }
            else
            {
                panel.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
}
