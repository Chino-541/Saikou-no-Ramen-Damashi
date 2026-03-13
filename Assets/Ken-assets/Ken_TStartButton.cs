using NaughtyAttributes;
using NaughtyAttributes.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ken_TStartButton : MonoBehaviour
{
    [Header("Nyanスクリプトへようこそ")]
    [SerializeField] private Button _SButton;
    [Scene]
    [SerializeField] private string _Scene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _SButton.onClick.AddListener(StartButton);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StartButton()
    {
        SceneManager.LoadScene(_Scene);
    }
}
