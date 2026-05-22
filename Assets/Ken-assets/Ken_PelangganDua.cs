using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;

public class Ken_PelangganDua : MonoBehaviour
{
    [Header("Nyanスクリプトへようこそ")]
    [SerializeField] private int _Duration;
    [SerializeField] private GameObject _Panel;
    [SerializeField] private int _PanelDuration;

    [SerializeField] private Slider _Slider;


    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Char"))
        {
           // StartCoroutine(Interek());
            Debug.Log("aaa");



        }
    }
    
    /*
    IEnumerator Interek()
    {
        GameObject _panelGO = Instantiate(_Panel);
        _panelGO.transform.SetParent(transform);
        yield return new WaitForSeconds(10000);
        
        GameObject _sliderGO = Instantiate(_Slider);
        _sliderGO.transform.
        //Instantiate(_Panel);
        
    }
    */
}