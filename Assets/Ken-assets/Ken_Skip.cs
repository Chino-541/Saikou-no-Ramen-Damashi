using NaughtyAttributes;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ken_Skip : MonoBehaviour
{
    [Scene][SerializeField] private int _SceneIndex;
    [SerializeField] private Button _SkipButton;
    [SerializeField] private AudioSource _SE;
    [SerializeField] private GameObject _CanvasHide;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SkipButton();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SkipButton()
    {
        _SkipButton.onClick.AddListener(() =>
        {
           StartCoroutine(SkipButtonSE());
        });
    }
    IEnumerator SkipButtonSE()
    {
        _SE.Play();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(_SceneIndex);
        _CanvasHide.SetActive(false);
    }
}
