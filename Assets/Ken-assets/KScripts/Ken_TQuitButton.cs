using UnityEngine;
using UnityEngine.UI;

public class Ken_TQuitButton : MonoBehaviour
{
    [Header("Nyanスクリプトへようこそ")]
    [SerializeField] private Button _QuitButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        QuitSystem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void QuitSystem()
    {
        _QuitButton.onClick.RemoveAllListeners();
        _QuitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }
}
