using NaughtyAttributes;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ken_TStartButton : MonoBehaviour
{
    [Header("Nyanスクリプトへようこそ")]
    [SerializeField] private Button _SButton;
    [Scene]
    [SerializeField] private int _Scene;
    [SerializeField] private AudioSource _SE;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //_SButton.onClick.AddListener(StartButton);
        _SButton.onClick.AddListener(() => StartCoroutine(StartButtons()));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator StartButtons()
    {
        _SE.Play();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene( _Scene );
    }

    //void StartButton()
    //{
    //    _SE.Play();
    //    SceneManager.LoadScene(_Scene);
    //}
    
    
}
