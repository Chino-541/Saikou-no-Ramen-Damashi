using System.Collections;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Ken_TutorSystem : MonoBehaviour
{
    //[SerializeField] private GameObject _StartTutorPanel;
    [SerializeField] private GameObject _MainTutorPanel;
    [SerializeField] private TextMeshProUGUI _Tmp;
    [SerializeField] private string _TmpTex;
    [SerializeField] private Image _StartTutorPanelImage;
    private float _Duration = 0.01f;
    [SerializeField] private bool _boolC = false;
    [SerializeField] private AudioSource _SEAruhi;
  
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(StartTutor());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator StartTutor()
    {
        
        //_MainTutorPanel.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        _Tmp.text = _TmpTex.ToString();
        _SEAruhi.Play();
        yield return new WaitForSeconds(0.5f);

        Color StartC = _StartTutorPanelImage.color;
        Color endC = new Color(StartC.r, StartC.g, StartC.b,1f);

        _boolC = true;
        while (true)
        {
            endC.a -= 0.002f;
            _StartTutorPanelImage.color = endC;
            yield return new WaitForSeconds(_Duration);
            if (endC.a < 0.5f)
            {
                _Tmp.gameObject.SetActive(false);
            }
            else if (endC.a < 0.1f)
            {
                //_boolC=false;
                //_StartTutorPanel.SetActive(false);
                break;
            }
        }
        _StartTutorPanelImage.gameObject.SetActive(false);
        //_MainTutorPanel.gameObject.SetActive(true);


        /*
        _bool1 = true;
        _bool2 = false;
        _StartTutorPanel.SetActive(true);
       
        Color startC = _StartTutorPanelImage.color;
        Color endC = new Color(startC.r, startC.g, startC.b,0f);

        while (_bool1 == true)
        {
            endC.a += 0.01f;
            _StartTutorPanelImage.color = endC;
            yield return new WaitForSeconds(_Duration);
            if(endC.a == 255)
            {
                _bool1= false;
            }
        }
        yield return new WaitForSeconds(_TextDelay);
        _bool2 = true;
        while (_bool2 == true)
        {
            endC.a -= 0.01f;
            _StartTutorPanelImage.color = endC;
            yield return new WaitForSeconds(_Duration);
            if (endC.a == 0f)
            {
                _bool2  = false;
            }
        }
        */





    }
}
