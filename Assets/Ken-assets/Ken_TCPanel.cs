// using UnityEditor.ShaderGraph.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class Ken_TCPanel : MonoBehaviour
{
    [Header("Nyanスクリプトへようこそ")]
    [SerializeField] private Button _CButton;
    [SerializeField] private GameObject _CPanel;
    [SerializeField] private AudioSource _SE;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _CButton.onClick.AddListener(() =>  CPanelSE() );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CPanelSE()
    {
        _SE.Play();
        _CPanel.SetActive(false);
    }

}
