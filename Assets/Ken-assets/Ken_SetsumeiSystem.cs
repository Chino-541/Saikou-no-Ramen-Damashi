
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Ken_SetsumeiSystem : MonoBehaviour
{
    [Header("Nyanスクリプトへようこそ")]

    [SerializeField] private TextMeshProUGUI _CharName;
    [SerializeField] private TextMeshProUGUI _CharText;
    [SerializeField] private Image _CharImage;

    [SerializeField] private float _CharTextSpeed = 0.05f;
    [SerializeField] private int _CharTextDelay = 1;

    [SerializeField] private Button _AutoClickButton;
    [SerializeField] private TextMeshProUGUI _AutoClickButtonT;

    [SerializeField] private Animator _CharNaikTurun;

    public string _RamenYa = "ラーメン屋";
    public string _PlayerName = "Player";

    public bool _AutoClickText = false;

  
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(CharSetsumeiText());
        AutoClickSystem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator CharSetsumeiText()
    {
        _CharName.text = _RamenYa;
        _CharName.color = Color.purple;
        _CharNaikTurun.SetTrigger("CharNaikTurun");
        yield return StartCoroutine(CharSetsumeiSystem("こんにちは"));
        yield return StartCoroutine(AutoClickText());
        //yield return new WaitForSeconds(_CharTextDelay);

        yield return StartCoroutine(CharSetsumeiSystem("俺の夢はラーメン屋になることなんだ！"));
        yield return StartCoroutine(AutoClickText());
        //yield return new WaitForSeconds(_CharTextDelay);

        yield return StartCoroutine(CharSetsumeiSystem("俺の夢を叶えるために、手伝ってくれないかい"));
        yield return StartCoroutine(AutoClickText());
        // yield return new WaitForSeconds(_CharTextDelay);

        _CharName.text = _PlayerName;
        _CharName.color = Color.blue;
        _CharNaikTurun.SetTrigger("CharNaikTurun");
        yield return StartCoroutine(CharSetsumeiSystem("いいよ！"));
        yield return StartCoroutine(AutoClickText());
        //yield return new WaitForSeconds(_CharTextDelay);

        yield return StartCoroutine(CharSetsumeiSystem("何をすればいいのか？"));
        yield return StartCoroutine(AutoClickText());
        //yield return new WaitForSeconds(_CharTextDelay);

        _CharName.text = _RamenYa;
        _CharName.color = Color.purple;
        _CharNaikTurun.SetTrigger("CharNaikTurun");
        yield return StartCoroutine(CharSetsumeiSystem("まず、食材収集から"));
        yield return StartCoroutine(AutoClickText());
        //yield return new WaitForSeconds(_CharTextDelay);
    }
    IEnumerator CharSetsumeiSystem(string _CharT)
    {
        _CharText.text = "";

        foreach (char T in _CharT)
        {
            _CharText.text += T;

            yield return new WaitForSeconds(_CharTextSpeed);
            
        }
    }

    IEnumerator AutoClickText()
    {
        if (_AutoClickText == true)
        {
            yield return new WaitForSeconds(_CharTextDelay);
        }

        else
        {
            // To Stop 
            yield return new WaitUntil(() =>
                Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)
            );

            yield return new WaitForSeconds(_CharTextDelay/2);
        }
    }
    void AutoClickSystem()
    {
        _AutoClickButtonT.text = "OFF";
        _AutoClickButton.image.color = Color.red;

        _AutoClickButton.onClick.AddListener(() =>
        {
            _AutoClickText = !_AutoClickText;

            if (_AutoClickText == true)
            {
                _AutoClickButtonT.text = "AUTO";
                _AutoClickButton.image.color = Color.white;

            }
            else
            {
                _AutoClickButtonT.text = "OFF";
                _AutoClickButton.image.color = Color.red;

            }
        });
    }

    
}
