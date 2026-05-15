using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ken_CTime : MonoBehaviour
{
    [SerializeField] private int _M, _S;
    [SerializeField] private int _SMax = 60;
    [SerializeField] private TextMeshProUGUI _TMP;
    [SerializeField] private string TString;
    public bool _Timer;
    // Start is cal led once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(STimer());
       
    }

    // Update is called once per frame
    void Update()
    {
        TDisplay();
    }
    IEnumerator STimer()
    {
  
        _Timer = true;
        while (_Timer == true)
        {
            //_S--;
            yield return new WaitForSeconds(1);
            if (_S <= 0)
            {
                if(_M != 0)
                {
                    _M--;
                    _S = _SMax;
                    yield return new WaitForSeconds(1);
                }
                
                else
                {
                    _Timer = false;
                    break;
                    
                }
            }
            _S--;

        }
        
    }
    void TDisplay()
    {
        if (_S >= 0 && _S <= 9)
        {
            TString = _M.ToString() + ":" + "0" + _S.ToString();
        }
        else
        {
            TString = _M.ToString() + ":" + _S.ToString();
        }
        _TMP.text = TString;
    }
}
