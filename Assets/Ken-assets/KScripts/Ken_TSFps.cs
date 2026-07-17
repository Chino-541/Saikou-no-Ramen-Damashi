using System;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Ken_TSFps : MonoBehaviour
{
    [Header("Nyanスクリプトへようこそ")]
    [SerializeField] private Button _PlusButton;
    [SerializeField] private Button _MinButton;
    [SerializeField] private Image[] _images;

    [Range(0, 1)]
    [SerializeField] private int _FpsIndex;
    [SerializeField] private TextMeshProUGUI _FpsText;
    [SerializeField] private AudioSource _SE;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        _FpsIndex = 1;
        AppRes();
        //_FpsText.text = ("60 FPS").ToString();
        //_images[1].color = Color.red;

        _PlusButton.onClick.AddListener(RPlus);
        _MinButton.onClick.AddListener(RMin);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void RMin()
    {
        _SE.Play();
        _FpsIndex--;
        _FpsIndex = Mathf.Clamp(_FpsIndex, 0, 1);
        AppRes();
    }
    void RPlus()
    {
        _SE.Play();
        _FpsIndex++;
        _FpsIndex = Mathf.Clamp(_FpsIndex, 0, 1);
        AppRes();
    }
    void AppRes()
    {
        switch (_FpsIndex)
        {
            case 0:
                IColor();
                Application.targetFrameRate = 30;
                break;

            case 1:
                IColor();
                Application.targetFrameRate = 60;
                break;
        }
    }
    void IColor()
    {
        if (_FpsIndex == 0)
        {
            _images[0].color = Color.red;
            _images[1].color = Color.grey;
            _FpsText.text = ("30 FPS").ToString();
        }
        else if (_FpsIndex == 1)
        {
            _images[0].color = Color.grey;
            _images[1].color = Color.red;
            _FpsText.text = ("60 FPS").ToString();
        }
    }
}
