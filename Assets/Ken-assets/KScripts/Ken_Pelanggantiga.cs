using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Ken_Pelanggantiga : MonoBehaviour
{
    [Header("Nyanスクリプトへようこそ")]
    [SerializeField] private PlayerInput _playerInp;
    public static Ken_Pelanggantiga instance;
    //[SerializeField] private GameObject _Panel;
    [SerializeField] private Image[] _Image;
    [SerializeField] private float _Delay = 5.0f;
    //[SerializeField] private Color _BaseColor;
    //[SerializeField] private Color _FullColor;
    //[SerializeField] private int _SliderMinVal = 0, _SliderMaxVal = 5;
    //[SerializeField] private int _SliderValue;

    [SerializeField] private AudioSource _SakuseiSEI;
    [SerializeField] private AudioSource _SakuseiSEII;
    [SerializeField] private AudioSource _SakuseiSEIII;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //PelangantigaInterek();

        //manggil interek 
        //StartCoroutine(PelangganInterectDelay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        instance = this;
    }
    /*

    public void PelangantigaInterek()
    {
        

            for (int i = 5; i < 0; i--)
            {

                _Image[i].gameObject.SetActive(false);
                

            }
            Debug.Log("f");
        
    }
    */

    public IEnumerator PelangganInterectDelay()
    {
        /*
        _Image[0].gameObject.SetActive(true);
        _Image[1].gameObject.SetActive(true);
        _Image[2].gameObject.SetActive(true);
        _Image[3].gameObject.SetActive(true);
        _Image[4].gameObject.SetActive(true);
        */
        _SakuseiSEI.Play();
        _SakuseiSEII.Play();
        _playerInp.DeactivateInput();

        for (int j = 0; j < _Image.Length; j++)
        {
            _Image[j].gameObject.SetActive(true);
        }

        for (int i = 0; i < _Image.Length; i++)
        {
            _Image[i].gameObject.SetActive(false);
            yield return new WaitForSeconds(_Delay / 10);
        }

        _SakuseiSEI.Stop();
        _SakuseiSEII.Stop();
        _SakuseiSEIII.Play();
        _playerInp.ActivateInput();
    }
    /*

    }
    IEnumerator PelangganInterectDelay()
    {
        _Image[0].gameObject.SetActive(true);
        _Image[1].gameObject.SetActive(true);
        _Image[2].gameObject.SetActive(true);
        _Image[3].gameObject.SetActive(true);
        _Image[4].gameObject.SetActive(true);

        for (int i = 0; i < _Image.Length; i++)
        {
            _Image[i].gameObject.SetActive(false);
            yield return new WaitForSeconds(_Delay/10);
        }
        
    }
    */
    
    
}
