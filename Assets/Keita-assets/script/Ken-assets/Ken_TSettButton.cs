using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

public class Ken_TSettButton : MonoBehaviour
{
    [Header("Nyanスクリプトへようこそ")]
    [SerializeField] private Button _SettButton;
    [SerializeField] private GameObject _SettPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _SettButton.onClick.AddListener(SettPanel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SettPanel()
    {

    }
}
