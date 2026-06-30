using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ken_Skip : MonoBehaviour
{
    [Scene][SerializeField] private int _SceneIndex;
    [SerializeField] private Button _SkipButton;
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
            SceneManager.LoadScene(_SceneIndex);
        });
    }
}
