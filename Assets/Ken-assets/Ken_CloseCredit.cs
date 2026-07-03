using UnityEngine;
using UnityEngine.UI;

public class Ken_CloseCredit : MonoBehaviour
{
    [Header("Nyanスクリプトへようこそ")]
    [SerializeField] private Button _CreditButton;
    [SerializeField] private GameObject _Credit;
    [SerializeField] private AudioSource _SE;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _CreditButton.onClick.AddListener(CreditOpen);
        //_Credit.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CreditOpen()
    {
        _SE.Play();
        _Credit.gameObject.SetActive(false);
    }
}