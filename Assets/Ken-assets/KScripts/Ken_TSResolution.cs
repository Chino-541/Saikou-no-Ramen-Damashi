using NaughtyAttributes;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class Ken_TSResolution : MonoBehaviour
{
    [Header("Nyanスクリプトへようこそ")]
    [SerializeField] private Button _PlusButton;
    [SerializeField] private Button _MinButton;
    [SerializeField] private Image[] _images;

    [Range(0,2)]
    [SerializeField] private int _RIndex;

    [SerializeField] private TextMeshProUGUI _ResText;

    private int _RMaxIndex = 2;

    
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _RIndex = 2;
        RMax();
        _PlusButton.onClick.AddListener(RPlus);
        _MinButton.onClick.AddListener(RMin);
        AppRes();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void RMin()
    {
        _RIndex--;
        _RIndex = Mathf.Clamp(_RIndex, 0, _RMaxIndex);
        AppRes();
    }
    void RPlus()
    {
        _RIndex++;
        _RIndex = Mathf.Clamp(_RIndex, 0, _RMaxIndex);
        AppRes();
    }
    void AppRes()
    {
        switch (_RIndex)
        {
            case 0:
                IColor();
                Screen.SetResolution(1280, 720, FullScreenMode.Windowed);
                break;

            case 1:
                IColor();
                Screen.SetResolution(1920, 1080, FullScreenMode.Windowed);
                break;

            case 2:
                IColor();
                Screen.SetResolution(2560, 1440, FullScreenMode.Windowed);
                break;
        }
    }
    void IColor()
    {
        if (_RIndex == 0)
        {
            _images[0].color = Color.red;
            _images[1].color = Color.grey;
            _images[2].color = Color.grey;
            _ResText.text = ("1280 x 720").ToString();
        }
        else if (_RIndex == 1)
        {
            _images[0].color = Color.grey;
            _images[1].color = Color.red;
            _images[2].color = Color.grey;
            _ResText.text = ("1920 x 1080").ToString();
        }
        else if ( _RIndex == 2)
        {
            _images[0].color = Color.grey;
            _images[1].color = Color.grey;
            _images[2].color = Color.red;
            _ResText.text = ("2560 x 1440").ToString();
        }
    }
    void RMax()
    {
        _RMaxIndex = 1;
        foreach (Resolution res in Screen.resolutions)
        {
            if (res.width == 2560 && res.height == 1440)
            {
                _RMaxIndex = 2;
                break;
            }
            else
            {
                _RMaxIndex = 1;
            }
        }
    }

}
