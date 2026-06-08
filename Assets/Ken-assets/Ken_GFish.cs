using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;



public class Ken_GFish : MonoBehaviour
{
    [Header("Nyanスクリプトへようこそ")]

    [BoxGroup("UI")][SerializeField] private Slider _slider;
    [BoxGroup("Fish System")][SerializeField] private bool _Fishing;
    [BoxGroup("Slider System")][SerializeField] private int _PlusValue = 25;
    [BoxGroup("Slider System")][SerializeField] private int _MinValue = 5;
    [BoxGroup("Slider System")][SerializeField] private int _BaseValue = 0, _MaxValue = 1000;
    [BoxGroup("Slider System")][SerializeField] private int _StartValue = 500;

    [BoxGroup("Fish System")][SerializeField] private bool _FishLoop;
    [BoxGroup("Fish System")][SerializeField] private int _FishTime = 0;
    [BoxGroup("Fish System")][SerializeField] private int _MaxFishTime = 10;
    [BoxGroup("Fish System")][SerializeField] private float _FishSpeed = 3;

    [BoxGroup("Final SystemI")][SerializeField] private int _FinalValue;
    [BoxGroup("Final System")][SerializeField] private bool _GetFish, _MissFish;
    [BoxGroup("Final System")][SerializeField] private int _GetFishBaseValue = 400, _GetFishMaxValue = 600;

    [BoxGroup("Fish Sprite")][SerializeField] private GameObject _GetFishSprite;
    [BoxGroup("Fish Sprite")][SerializeField] private GameObject _MissFishSprite;

    [BoxGroup("UI")][SerializeField] private GameObject _PanelFishing;

    [SerializeField] private Cook cook;

    private void Start()
    {

        SliderSystem();
        FishTimeSystem();
        StartCoroutine(FishTimeSystem());
        //StartCoroutine(FishSystem());
        //FishFinal();
        
    }
    void SliderSystem()
    {
        _GetFish = false;
        _MissFish = false;
        _slider.minValue = _BaseValue;
        _slider.maxValue = _MaxValue;
        _slider.value = _StartValue;

        _MaxFishTime = (int)(_FishSpeed * 10);
        _FishSpeed = _FishSpeed / 10;
    }
    
    
    IEnumerator FishTimeSystem()
    {
        _Fishing = true;
        _FishTime = 0;
        while (_Fishing == true)
        {
            _FishTime++;

            if (_FishTime >= _MaxFishTime)
            {
                _Fishing = false;
            }
            _slider.value -= _MinValue;

            yield return new WaitForSeconds(_FishSpeed);
        }
        FinalValue();
        StartCoroutine(FishFinal());
        
    }
    int FinalValue() => _FinalValue = (int)_slider.value;
    /*
    IEnumerator FishSystem()
    {
        if( _Fishing == true)
        {
            while (_FishLoop == true)
            {
                _slider.value -= _MinValue;
                yield return new WaitForSeconds(0.5f);
               
            }
           
        }
        else
        {
            Debug.Log("aa");
        }
    }
    */

    public void FishPlusSystem(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _slider.value += _PlusValue;
        }

    }
    IEnumerator FishFinal()
    {
        if(_Fishing == false)
        {
            if (_FinalValue >= _GetFishBaseValue & _FinalValue <= _GetFishMaxValue )
            {
                _GetFish = true;
                while (_GetFish == true)
                {
                    cook.fish++;
                    _GetFishSprite.SetActive(true);
                    yield return new WaitForSeconds(3f);
                    _GetFishSprite.SetActive(false);
                    ExitFishing();

                }
              
            }
            else
            {
                _MissFish = true;
                while ( _MissFish == true)
                {
                    _MissFishSprite.SetActive(true);
                    yield return new WaitForSeconds(3f);
                    _MissFishSprite.SetActive(false);
                    cook.fish++;
                    ExitFishing();
                }
            }
        }
    }
    void ExitFishing()
    {
        _Fishing =false;
        _GetFish = false;
        _MissFish = false;

        _FishTime = 0;

        _slider.value = _StartValue;
        _PanelFishing.gameObject.SetActive(false);

        StartCoroutine(FishTimeSystem());
    }

}

