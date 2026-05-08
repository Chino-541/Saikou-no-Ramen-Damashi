using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class Ken_GFish : MonoBehaviour
{
    [SerializeField] private Slider _Slider;
    [SerializeField] private float _Value = 50;

    [SerializeField] private float _MinValue = 1f;
    [SerializeField] private float _PlusValue = 1f;

    private void Update()
    {
        _Slider.value = _Value;
        _Value -= _MinValue * Time.deltaTime;
       // if(Input.GetKeyDown(KeyCode.Escape))
        {
            //_Value += _PlusValue;
        }
        _Value= Mathf.Clamp(_Value, 0, 100); 

    }
    public void PlusValue(InputAction.CallbackContext context)
    {
        if (context.performed || context.started)
        {
            _Value += _PlusValue * Time.deltaTime;
            Debug.Log("a");
        }
    }



    //void fishing ()

}

