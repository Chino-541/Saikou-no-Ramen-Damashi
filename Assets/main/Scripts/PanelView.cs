using NaughtyAttributes;
using UnityEngine;

public class PanelView : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    private void Start()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            panel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void Onclickbutton()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
    }
}
