using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Ken_PelanganInteract : MonoBehaviour
{
    [Header("Nyanスクリプトへようこそ")]
    [SerializeField] private GameObject _Char;
    [SerializeField] private GameObject _Pel;
    [SerializeField] private GameObject _panel;
    [SerializeField] private int _panelDisp = 5;

    [SerializeField] private Slider _slider;
    [SerializeField] private int _sliderIndex = 0;
    [SerializeField] private static int _sliderIndexMin = 0, _sliderIndexMax = 5;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator interec()
    {
        _slider.minValue = _sliderIndexMin;
        _slider.maxValue = _sliderIndexMax;
        _slider.value = _sliderIndex;

        _panel.SetActive(true);
        if (_panel)
        {
            if(_sliderIndex < _sliderIndexMax)
            {
                while (true)
                {
                    _sliderIndex++;
                    yield return new WaitForSeconds(1f);
                }
                
            }
            else
            {
                Debug.Log("ラメン作成した");
                yield return new WaitForSeconds(3f);
                _panel.SetActive(false);
            }
            
           
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Char"))
        {
            StartCoroutine(interec());
        }
    }
}
