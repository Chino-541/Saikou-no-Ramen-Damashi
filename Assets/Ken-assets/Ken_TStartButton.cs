using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ken_TStartButton : MonoBehaviour
{
    [Header("Nyanスクリプトへようこそ")]
    private Button _SButton;
    [Scene]
    [SerializeField] private string _Scene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _SButton = GetComponent<Button>();
        _SButton.onClick.AddListener(StartButton);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void StartButton()
    {
        Debug.Log("aa");
        SceneManager.LoadScene(_Scene);

    }
}
