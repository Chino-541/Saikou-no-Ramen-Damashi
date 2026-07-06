using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class Ken_CSystem : MonoBehaviour
{
    [Header("Nyanスクリプトへようこそ")]
    [SerializeField] private int _PV = 0;
    [SerializeField] private int _RV = 0;
    //[SerializeField] private GameObject _Player, _Rival;
    //[SerializeField] private GameObject _T1, _T2, _T3, _T4, _T5;
    [SerializeField] private int _T1Value, _T2Value, _T3Value, _T4Value, _T5Value;
    [SerializeField] private TextMeshProUGUI _T1, _T2, _T3, _T4, _T5;
    [SerializeField] private int _RValueMin = 3, _RValueMax = 8;
    [SerializeField] private bool _BT1 = false , _BT2 = false, _BT3 = false, _BT4 = false, _BT5 = false;
    [SerializeField] private bool _TB =  true;
    [SerializeField] private int _Delay = 1;
    [SerializeField] private Button B1, B2, B3, B4, B5;
    [SerializeField] private TextMeshProUGUI _PvTMP;
    public Ken_CTime _CTime;

    bool Work =false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RValue();
        
    }

    // Update is called once per frame
    void Update()
    {
        _PvTMP.text = _PV.ToString();
        RDisplay();
    }
    void RValue()
    {
        
        _T1Value = UnityEngine.Random.Range(_RValueMin, _RValueMax);
        _T2Value = UnityEngine.Random.Range(_RValueMin, _RValueMax);
        _T3Value = UnityEngine.Random.Range(_RValueMin, _RValueMax);
        _T4Value = UnityEngine.Random.Range(_RValueMin, _RValueMax);
        _T5Value = UnityEngine.Random.Range(_RValueMin, _RValueMax);

        RDisplay();

        B1.onClick.AddListener(() => StartCoroutine(ValueSystem(1)));
        B2.onClick.AddListener(() => StartCoroutine(ValueSystem(2)));
        B3.onClick.AddListener(() => StartCoroutine(ValueSystem(3)));
        B4.onClick.AddListener(() => StartCoroutine(ValueSystem(4)));
        B5.onClick.AddListener(() => StartCoroutine(ValueSystem(5)));

    }
    void RDisplay()
    {
        _T1.text = _T1Value.ToString();
        _T2.text = _T2Value.ToString();
        _T3.text = _T3Value.ToString();
        _T4.text = _T4Value.ToString();
        _T5.text = _T5Value.ToString();
    }
    IEnumerator ValueSystem(int buttonID)
    {
        if (Work)
            yield break;

        Work = true;
        while (Work == true)
        {
            switch(buttonID)
            {
                case 1:
                    if(_T1Value <= 0)
                    {
                        Work = false;
                        yield break;
                    }
                    _T1Value--;
                    break;
                case 2:
                    if (_T2Value <= 0)
                    {
                        Work = false;
                        yield break;
                    }
                    _T2Value--;
                    break;
                case 3:
                    if (_T3Value <= 0)
                    {
                        Work = false;
                        yield break;
                    }
                    _T3Value--;
                    break;
                case 4:
                    if (_T4Value <= 0)
                    {
                        Work = false;
                        yield break;
                    }
                    _T4Value--;
                    break;
                case 5:
                    if (_T5Value <= 0)
                    {
                        Work = false;
                        yield break;
                    }
                    _T5Value--;
                    break;
            }
            _PV++;
            RDisplay();
            yield return new WaitForSeconds(_Delay);
        }
        /*
        if (_CTime._Timer == true)
        {
            if (_TB  == false)
            {
                Debug.Log("1");
                if (_BT1 == true)
                {
                    Debug.Log("2");
                    for (int i = _T1Value; i > 0; i--)
                    {
                        _PV++;
                        Debug.Log("3");
                    }
                    /*
                    while (_T1Value > 0)
                    {
                        _T1Value--;
                        _PV++;
                        yield return new WaitForSeconds(_Delay);

                    }
                    
                    _BT1 = false;
                    RValue();
                    _TB = true;
                }
                else if (_BT2 == true)
                {
                    while (_T2Value > 0)
                    {
                        _T2Value--;
                        _PV++;
                        yield return new WaitForSeconds(_Delay);
                    }
                    _BT2 = false;
                    RValue();
                    _TB = true;
                }
                else if (_BT3 == true)
                {
                    while (_T3Value > 0)
                    {
                        _T3Value--;
                        _PV++;
                        yield return new WaitForSeconds(_Delay);
                    }
                    _BT3 = false;
                    RValue();
                    _TB = true;
                }
                else if (_BT4 == true)
                {
                    while (_T4Value > 0)
                    {
                        _T4Value--;
                        _PV++;
                        yield return new WaitForSeconds(_Delay);
                    }
                    _BT4 = false;
                    RValue();
                    _TB = true;
                }
                else if (_BT5 == true)
                {
                    while (_T5Value > 0)
                    {
                        _T5Value--;
                        _PV++;
                        yield return new WaitForSeconds(_Delay);
                    }
                    _BT5 = false;
                    RValue();
                    _TB = true;
                }
                
                {
                    B1.onClick.AddListener(() =>
                    {
                        _BT1 = true;
                    });
                }
            
            }
         


        }
        else
        {
            Debug.Log("o");
        }
        */

        
    }
    /*
    void transferbool()
    {
        B1.onClick.AddListener(() =>
        {
            _BT1 = true;
            _TB = false;
        });
        B2.onClick.AddListener(() =>
        {
            _BT2 = true;
            _TB = false;
        });
        B3.onClick.AddListener(() =>
        {
            _BT3 = true;
            _TB = false;
        });
        B4.onClick.AddListener(() =>
        {
            _BT4 = true;
            _TB = false;
        });
        B5.onClick.AddListener(() =>
        {
            _BT5 = true;
            _TB = false;
        });
    }
    void TransBool()
    {
        if (_BT1 == false && _BT2 == false && _BT3 == false && _BT4 == false && _BT5 == false)
        {
            _TB = true;
        }
    }
    */
    
}
