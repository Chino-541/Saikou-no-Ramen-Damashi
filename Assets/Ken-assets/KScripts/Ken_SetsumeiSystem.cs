
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;
using UnityEngine.SceneManagement;


public class Ken_SetsumeiSystem : MonoBehaviour
{
    [Header("Nyanスクリプトへようこそ")]

    [BoxGroup("UI")][SerializeField] private TextMeshProUGUI _CharName;
    [BoxGroup("UI")][SerializeField] private TextMeshProUGUI _CharText;
    [BoxGroup("UI")][SerializeField] private Image _CharImage;

    [BoxGroup("TextSystem")][SerializeField] private float _CharTextSpeed = 0.05f;
    [BoxGroup("TextSystem")][SerializeField] private int _CharTextDelay = 1;

    [BoxGroup("AutoClick")][SerializeField] private Button _AutoClickButton;
    [BoxGroup("AutoClick")][SerializeField] private TextMeshProUGUI _AutoClickButtonT;

    [BoxGroup("Animation")][SerializeField] private Animator _CharNaikTurun;

    [BoxGroup("UI")][SerializeField] private Image _RamenYaImage;
    [BoxGroup("UI")][SerializeField] private Image _PlayerImage;

    [BoxGroup("Name")] public string _Ojiisan = "知らないおじいさん";
    [BoxGroup("Name")] public string _RamenYa = "ラーメン屋";
    [BoxGroup("Name")][SerializeField] Color _RamenYaColour = Color.purple;

    [BoxGroup("Name")] public string _PlayerName = "Player";
    [BoxGroup("Name")][SerializeField] Color _PlayerColour = Color.blue;

    [BoxGroup("AutoClick")] public bool _AutoClickText = false;

    [BoxGroup("Pilihan")][SerializeField] private TMP_InputField _PlayerNameInput;
    [BoxGroup("Pilihan")][SerializeField] private Button _PlayerInputB;

    [BoxGroup("Jawaban")][SerializeField] private Button _ChoiceYes;
    [BoxGroup("Jawaban")][SerializeField] private Button _ChoiceNo;

    [BoxGroup("NScene")][Scene][SerializeField] private int _NScene;

    [SerializeField] private AudioSource _SEText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _PlayerNameInput.gameObject.SetActive(false);
        _PlayerInputB.gameObject.SetActive(false);  
        _ChoiceYes.gameObject.SetActive(false);
        _ChoiceNo.gameObject.SetActive(false);
        //-----------------------------------------------------------
        StartCoroutine(CharSetsumeiText());
        AutoClickSystem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator CharSetsumeiText()
    {
        /*
        _CharName.text = _Ojiisan;
        _CharName.color = _RamenYaColour;
        _CharImage.sprite = _RamenYaImage.sprite;
        _CharNaikTurun.SetTrigger("CharNaikTurun");
        yield return StartCoroutine(CharSetsumeiSystem("こんにちは"));
        yield return StartCoroutine(AutoClickText());
        //yield return new WaitForSeconds(_CharTextDelay);
        */
        

        _CharName.text = _PlayerName;
        _CharName.color = _PlayerColour;
        _CharImage.sprite = _PlayerImage.sprite;
        _CharNaikTurun.SetTrigger("CharNaikTurun");
        yield return StartCoroutine(CharSetsumeiSystem("店長！やってるかい"));
        yield return StartCoroutine(AutoClickText());

        _CharName.text = _Ojiisan;
        _CharName.color = _RamenYaColour;
        _CharImage.sprite = _RamenYaImage.sprite;
        //_CharNaikTurun.SetTrigger("CharNaikTurun");
        yield return StartCoroutine(CharSetsumeiSystem("。。。"));
        yield return StartCoroutine(AutoClickText());

        _CharName.text = _PlayerName;
        _CharName.color = _PlayerColour;
        _CharImage.sprite = _PlayerImage.sprite;
        yield return StartCoroutine(CharSetsumeiSystem("そういえばアンタはいつもどんな感じでラーメン作ってんだい？"));
        yield return StartCoroutine(AutoClickText());

        _CharName.text = _PlayerName;
        _CharName.color = _PlayerColour;
        _CharImage.sprite = _PlayerImage.sprite;
        yield return StartCoroutine(CharSetsumeiSystem("常連のよしみでよ、良かったら見せてくれよ"));
        yield return StartCoroutine(AutoClickText());

        _CharName.text = _Ojiisan;
        _CharName.color = _RamenYaColour;
        _CharImage.sprite = _RamenYaImage.sprite;
        _CharNaikTurun.SetTrigger("CharNaikTurun");
        yield return StartCoroutine(CharSetsumeiSystem("。。。いいぜ"));
        yield return StartCoroutine(AutoClickText());

        _CharName.text = _PlayerName;
        _CharName.color = _PlayerColour;
        _CharImage.sprite = _PlayerImage.sprite;
        _CharNaikTurun.SetTrigger("CharNaikTurun");
        yield return StartCoroutine(CharSetsumeiSystem("よしきた！"));
        yield return StartCoroutine(AutoClickText());

        _CharName.text = _Ojiisan;
        _CharName.color = _RamenYaColour;
        _CharImage.sprite = _RamenYaImage.sprite;
        _CharNaikTurun.SetTrigger("CharNaikTurun");
        yield return StartCoroutine(CharSetsumeiSystem("まず食材を集めてもらう"));
        yield return StartCoroutine(AutoClickText());

        _CharName.text = _Ojiisan;
        _CharName.color = _RamenYaColour;
        _CharImage.sprite = _RamenYaImage.sprite;
        _CharNaikTurun.SetTrigger("CharNaikTurun");
        yield return StartCoroutine(CharSetsumeiSystem("いい食材が採れる場所があるからそこに行って調達してきな"));
        yield return StartCoroutine(AutoClickText());

        _CharName.text = _PlayerName;
        _CharName.color = _PlayerColour;
        _CharImage.sprite = _PlayerImage.sprite;
        _CharNaikTurun.SetTrigger("CharNaikTurun");
        yield return StartCoroutine(CharSetsumeiSystem("わかった！"));
        yield return StartCoroutine(AutoClickText());

        _CharName.text = _Ojiisan;
        _CharName.color = _RamenYaColour;
        _CharImage.sprite = _RamenYaImage.sprite;
        _CharNaikTurun.SetTrigger("CharNaikTurun");
        yield return StartCoroutine(CharSetsumeiSystem("時間になったら戻ってきてもらうからな"));
        yield return StartCoroutine(AutoClickText());

        _CharName.text = _Ojiisan;
        _CharName.color = _RamenYaColour;
        _CharImage.sprite = _RamenYaImage.sprite;
        _CharNaikTurun.SetTrigger("CharNaikTurun");
        yield return StartCoroutine(CharSetsumeiSystem("Tabキーで操作説明が見れます"));
        yield return StartCoroutine(AutoClickText());
        /*
        //-----------------------------------------------------------
        yield return StartCoroutine(PlayerNameIn());

        _CharName.text = _Ojiisan;
        _CharName.color =_RamenYaColour;
        _CharImage.sprite = _RamenYaImage.sprite;
        //_CharNaikTurun.SetTrigger("CharNaikTurun");
        yield return StartCoroutine(CharSetsumeiSystem("へぇ～、よろしくね"+_PlayerName+"さん"));
        yield return StartCoroutine(AutoClickText());

        _CharName.text = _PlayerName;
        _CharName.color = _PlayerColour;
        _CharImage.sprite = _PlayerImage.sprite;
        yield return StartCoroutine(CharSetsumeiSystem("それで、おじいさんはなにものだ？"));
        yield return StartCoroutine(AutoClickText());

        _CharName.text = _RamenYa;
        _CharName.color = _RamenYaColour;
        _CharImage.sprite = _RamenYaImage.sprite;
        yield return StartCoroutine(CharSetsumeiSystem("僕はラーメン屋さん。"));
        yield return StartCoroutine(AutoClickText());

        yield return StartCoroutine(CharSetsumeiSystem("僕と一緒にラーメンを作らないかい？"));
        yield return StartCoroutine(AutoClickText());

        //-----------------------------------------------------------
        bool PlayerChoice = false;

        yield return StartCoroutine(ChoiceYes((pilihan) =>
        {
            PlayerChoice = pilihan;
        }));

        if(PlayerChoice)
        {
            yield return StartCoroutine(CharSetsumeiSystem("いいね！"));
        }
        else
        {
            _CharNaikTurun.SetTrigger("CharNaikTurun");
            yield return StartCoroutine(CharSetsumeiSystem("はあ！、なんだって！！！"));
        }
        yield return StartCoroutine(AutoClickText());

        //-----------------------------------------------------------
        */
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(_NScene);
      
    }
    IEnumerator CharSetsumeiSystem(string _CharT)
    {
        _SEText.Play();
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
    IEnumerator PlayerNameIn()
    {
        _PlayerNameInput.gameObject.SetActive(true);
        _PlayerInputB.gameObject.SetActive(true);   
        _PlayerNameInput.text = "";
        _PlayerNameInput.ActivateInputField();

        bool _PlayerNameInBool = false;

       _PlayerInputB.onClick.RemoveAllListeners();
        _PlayerInputB.onClick.AddListener(() =>
        {
            if (!string.IsNullOrEmpty(_PlayerNameInput.text))
            {
                _PlayerNameInBool = true;
            }
        });

        yield return new WaitUntil(() => _PlayerNameInBool);

        _PlayerName = _PlayerNameInput.text;
        _PlayerNameInput.gameObject.SetActive(false);
        _PlayerInputB.gameObject.SetActive(false);
    }
    IEnumerator ChoiceYes(System.Action<bool> pilihan)
    {
        _ChoiceYes.gameObject.SetActive(true); 
        _ChoiceNo.gameObject.SetActive(true);

        bool _Choiced = false;
        bool _Answer = false;

        _ChoiceYes.onClick.RemoveAllListeners();
        _ChoiceNo.onClick.RemoveAllListeners();

        _ChoiceYes.onClick.AddListener(() =>
        {
            _Answer = true;
            _Choiced = true;
        });
        _ChoiceNo.onClick.AddListener(() =>
        {
            _Answer = false;
            _Choiced = true;
        });
        yield return new WaitUntil(() => _Choiced);

        _ChoiceYes.gameObject.SetActive(false);
        _ChoiceNo.gameObject.SetActive(false);
        //tunggu
        pilihan?.Invoke(_Answer);
    }
    
}
