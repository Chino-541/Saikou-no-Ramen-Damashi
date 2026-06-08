using System.Collections;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Fadein : MonoBehaviour
{
    //[SerializeField] private GameObject _StartTutorPanel;
    [SerializeField] private GameObject _MainTutorPanel;
    [SerializeField] private TextMeshProUGUI _Tmp;
    [SerializeField] private string _TmpTex;
    [SerializeField] private Image _StartTutorPanelImage;
    private float _Duration = 0.01f;
    [SerializeField] private bool _boolC = false;


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
        Time.timeScale = 0f;

        yield return new WaitForSecondsRealtime(0.5f);
        _Tmp.text = _TmpTex;
        yield return new WaitForSecondsRealtime(0.5f);

        Color StartC = _StartTutorPanelImage.color;
        Color endC = new Color(StartC.r, StartC.g, StartC.b, 1f);

        while (true)
        {
            endC.a -= 0.002f;
            _StartTutorPanelImage.color = endC;

            yield return new WaitForSecondsRealtime(_Duration);

            if (endC.a < 0.5f)
            {
                _Tmp.gameObject.SetActive(false);
            }
            else if (endC.a < 0.1f)
            {
                break;
            }
        }

        // UI ブロック解除
        _StartTutorPanelImage.raycastTarget = false;

        // 親の Panel ごと消す
        _StartTutorPanelImage.transform.parent.gameObject.SetActive(false);

        Time.timeScale = 1f;
    }

}