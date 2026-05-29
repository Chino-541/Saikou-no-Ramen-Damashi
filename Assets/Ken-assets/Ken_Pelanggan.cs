using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ken_Pelanggan : MonoBehaviour
{
    [Header("Nyanスクリプトへようこそ")]
    [BoxGroup("Player")][SerializeField] private GameObject _player;
    [BoxGroup("Player")][SerializeField] private GameObject _customer;

    //[SerializeField] private float _minX, _minY, _maxX, _maxY;

    [BoxGroup("Spawn")][SerializeField] private bool _BisaSpawn = false;
    [BoxGroup("Spawn")][SerializeField] private int _SpawnDelay = 10;
    [BoxGroup("Spawn")][SerializeField] private float _SpawnDestroy = 12;

    [BoxGroup("Spawn")][SerializeField] private int _Spawn = 0;
    [BoxGroup("Spawn")][SerializeField] private const int _MinSpawn = 0;
    [BoxGroup("Spawn")][SerializeField] private int _MaxSpawn = 5;


    [BoxGroup("Spawn")][SerializeField] private PolygonCollider2D _PColl;

    [BoxGroup("Poin")] public int _poin = 0;
    [BoxGroup("Poin")][SerializeField] private string _SPoin = "販売した数：";
    [BoxGroup("Poin")][SerializeField] private TextMeshProUGUI _TmpPoin;

    public static Ken_Pelanggan _PelangganInstance;


    [BoxGroup("Waktu Main")][SerializeField] private int _WaktuMain = 60;
    [BoxGroup("Waktu Main")][SerializeField] private TextMeshProUGUI _TmpWaktuMain;
    [BoxGroup("Waktu Main")][SerializeField] private Rigidbody2D _RigidbodyPlayer;

    //==================================================================

    [BoxGroup("LastS")][SerializeField] private GameObject _PanelScore;
    //public Ken_LScore _LScoreScript;


    [BoxGroup("LastS")][SerializeField] private int _RamenScorenya = 0;
    [BoxGroup("LastS")][SerializeField] private TextMeshProUGUI _RamenScoreTextnya;
    [BoxGroup("LastS")][SerializeField] private int _RamenTerjualnya = 0;
    [BoxGroup("LastS")][SerializeField] private TextMeshProUGUI _RamenTerjualTextnya;
    [BoxGroup("LastS")][SerializeField] private int _TotalScorenya = 0;
    [BoxGroup("LastS")][SerializeField] private string _TotalScoreString;
    [BoxGroup("LastS")][SerializeField] private TextMeshProUGUI _TotalScoreTextnya;

    //==================================================================

    //[BoxGroup("Scene")][SerializeField] private Button _TitleButton;
    //[Scene][BoxGroup("Scene")][SerializeField] private int _scene;
    [BoxGroup("RivalS")][SerializeField] private Button _toRivalScore;

    [BoxGroup("Rival")][SerializeField] private int _RivalRamenScore;
    [BoxGroup("Rival")][SerializeField] private TextMeshProUGUI _RivalTextScore;
    [BoxGroup("Rival")][SerializeField] private int _DelayRivalScore;
    [BoxGroup("Rival")][SerializeField] private int _MinDelayRivalRamenScore = 3;
    [BoxGroup("Rival")][SerializeField] private int _MaxDelayRivalRamenScore = 6;
    [BoxGroup("Rival")][SerializeField] private Slider _DelayRivalSlider;
    [BoxGroup("Rival")][SerializeField] private const int _MinDelayRivalSlider = 0;
    [BoxGroup("Rival")][SerializeField] private int _MaxDelayRivalSlider;
    [BoxGroup("Rival")][SerializeField] private float _FloatRivalSlider;


    //~~~~~~~~~~~~~~
    [BoxGroup("RivalS")][SerializeField] private GameObject _RivalPanelScore;
    [BoxGroup("RivalS")][SerializeField] private TextMeshProUGUI _RivalPanelScoreText;
    [BoxGroup("RivalS")][SerializeField] private TextMeshProUGUI _RivalPanelRamenScoreText;

    [BoxGroup("RivalS")][SerializeField] private int _RivalTotalScorenya = 0;
    [BoxGroup("RivalS")][SerializeField] private string _RivalTotalScoreString;
    [BoxGroup("RivalS")][SerializeField] private TextMeshProUGUI _RivalTotalScoreTextnya;
    [BoxGroup("RivalS")][SerializeField] private Button _toResult;


    [BoxGroup("Scene")][SerializeField] private Button _TitleButton;
    [Scene][BoxGroup("Scene")][SerializeField] private int _scene;

    //==================================================================

    [BoxGroup("ResultWin")][SerializeField] private GameObject _ResultWinPanel;
    [BoxGroup("ResultWin")][SerializeField] private Button _WinKembaliKeTitle;
    [BoxGroup("ResultWin")][SerializeField] private TextMeshProUGUI _ResultWinScoreText;

    [BoxGroup("ResultLose")][SerializeField] private GameObject _ResultlosePanel;
    [BoxGroup("ResultLose")][SerializeField] private Button _LoseKembaliKeTitle;
    [BoxGroup("ResultLose")][SerializeField] private TextMeshProUGUI _ResultLoseScoreText;

    



    private void Awake()
    {
        _PelangganInstance = this;
    }

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnPelangan());
        StartCoroutine(WaktuMainNya());
        

        _TmpPoin.text = _SPoin+_poin.ToString();
        _PanelScore.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnPelangan()
    {
       while(true)
        {
            if (_BisaSpawn && _Spawn < _MaxSpawn)

            {
                Vector2 SPos = Rpos();
                //Spawn
                GameObject Spawner = Instantiate(_customer, SPos, Quaternion.identity);
                _Spawn++;

                //Destroy(Spawner, _SpawnDestroy);
                StartCoroutine(DestroyDelay(Spawner));

                StartCoroutine(SpawnDelay());


            }
            yield return new WaitForSeconds(_SpawnDelay);
        }
        
        
    }
    IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(_SpawnDestroy);
        _Spawn--;
    }
    Vector2 Rpos()
    {
        //ngambil di dalam area
        Bounds _bounds = _PColl.bounds;

        float ranX = Random.Range(_bounds.min.x, _bounds.max.x);
        float ranY = Random.Range(_bounds.min.y, _bounds.max.y);
        Vector2 _SpawnPos = new Vector2(ranX, ranY);

        return _SpawnPos;
    }
    public void yangterjual()
    {
        _poin++;
        _TmpPoin.text = _SPoin + _poin.ToString();
    }
    IEnumerator WaktuMainNya()
    {
        _TmpWaktuMain.text = _WaktuMain.ToString();


        _BisaSpawn = true;
        StartCoroutine(RivalSystem());
        while (_BisaSpawn)
        {
            _WaktuMain--;
            int _hasilBagi = _WaktuMain % 2;
            if (_hasilBagi == 0)
            {
                _TmpWaktuMain.color = Color.red;
                _TmpWaktuMain.text = _WaktuMain.ToString();
            }
            else
            {
                _TmpWaktuMain.color = Color.blue;
                _TmpWaktuMain.text = _WaktuMain.ToString();
            }
               // _TmpWaktuMain.text = _WaktuMain.ToString();
            yield return new WaitForSeconds(1);
            if (_WaktuMain == 0)
            {
                _BisaSpawn = false;
                //Stop gerak 
                //_RigidbodyPlayer.constraints = false;
                _RigidbodyPlayer.constraints = RigidbodyConstraints2D.FreezePositionX
                                            | RigidbodyConstraints2D.FreezePositionY;
                _PanelScore.SetActive(true);
                _RivalPanelScore.SetActive(false);
                LastScore();
                //_LScoreScript.ScorAkhirnya();
               


            }
        }
        
    }
    IEnumerator DestroyDelay (GameObject obj)
    {
        yield return new WaitForSeconds(_SpawnDestroy);
        
        if(obj != null)
        {
            Ken_PelangganDua pelanggan = obj.GetComponent<Ken_PelangganDua>();

            if(pelanggan != null && pelanggan._melayani)
            {
                yield break;

            }
            Destroy(obj);
        }
    }
    void LastScore()
    {
        RivalScorePanel();
        //222222222222222222222
        _RamenScorenya = 1;

        _RamenScoreTextnya.text = _RamenScorenya.ToString();

        _RamenTerjualnya = _poin;
        _RamenTerjualTextnya.text = _RamenTerjualnya.ToString();

        _TotalScorenya = (_RamenScorenya * _poin);
        Debug.Log(_TotalScorenya);
        //_TotalScoreTextnya.text = _TotalScorenya.ToString();
        _TotalScoreString = "合計 : "+ _TotalScorenya.ToString();
        _TotalScoreTextnya.text = _TotalScoreString;
        //_TotalScoreTextnya.text = (_poin*_RamenScorenya).ToString();

        /*
        _TitleButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(_scene);
        });
        */

        _toRivalScore.onClick.AddListener(()=>
        {
            _RivalPanelScore.SetActive(true);
            _PanelScore.SetActive(false);
        });
    }
    IEnumerator RivalSystem()
    {
        _RivalRamenScore = 0;
        _RivalTextScore.text = _RivalRamenScore.ToString();
        Debug.Log("aaaa");
        while (_BisaSpawn)
        {
            /*
            _DelayRivalScore = Random.Range(_MinDelayRivalRamenScore, _MaxDelayRivalRamenScore);
            _RivalRamenScore++;
            Debug.Log("nnnn");
            _RivalTextScore.text = _RivalRamenScore.ToString();
            yield return new WaitForSeconds(_DelayRivalScore);
            */

            _DelayRivalScore = Random.Range(_MinDelayRivalRamenScore, _MaxDelayRivalRamenScore);
            _FloatRivalSlider = _DelayRivalScore * 100f;
            _DelayRivalSlider.maxValue = _FloatRivalSlider ;
            _DelayRivalSlider.value = _FloatRivalSlider;

            float _DurationSlider = _DelayRivalScore;
            float _TimerSlider = _DurationSlider;

            while (_TimerSlider > 0)
            {
                _TimerSlider -= Time.deltaTime;
                _DelayRivalSlider.value = (_TimerSlider / _DurationSlider) * _FloatRivalSlider;
                yield return null;
            }
            _DelayRivalSlider.value = 0;
            _RivalRamenScore++;
            _RivalTextScore.text = _RivalRamenScore.ToString();

            /*
            while (_DelayRivalSlider.value > 0)
            {
                yield return new WaitForSeconds(1f);

                _DelayRivalSlider.value -= 1;
            }

            _RivalRamenScore++;
            _RivalTextScore.text = _RivalRamenScore.ToString();
            */

            /*

            _MaxDelayRivalSlider = _DelayRivalScore;
            _DelayRivalSlider.maxValue = _MaxDelayRivalSlider;
            for (int i = _MaxDelayRivalSlider; i >= 0;i--)
            {
                _DelayRivalSlider.value = i;
                
            }
            _RivalRamenScore++;
            _RivalTextScore.text = _RivalRamenScore.ToString();
            yield return new WaitForSeconds(_DelayRivalSlider.value);
            */


        }
        RivalScorePanel();
    }
    void RivalScorePanel()
    {
        _RivalPanelScoreText.text = _RivalRamenScore.ToString();
        _RivalPanelRamenScoreText.text = _RamenScorenya.ToString();

        _RivalTotalScorenya = (_RamenScorenya * _RivalRamenScore);
        _RivalTotalScoreString = "合計 : " + _RivalTotalScorenya.ToString();
        _RivalTotalScoreTextnya.text = _RivalTotalScoreString;

        /*
        _TitleButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(_scene);
        });
        */

        _ResultWinPanel.SetActive(false);
        _ResultlosePanel.SetActive(false);

        _toResult.onClick.AddListener(() =>
        {
            Result();
            //_RivalPanelScore.SetActive(false);
           
        });


    }
    void Result()
    {
        //menang
        if (_TotalScorenya > _RivalTotalScorenya)
        {
            _WinKembaliKeTitle.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(_scene);
            });
            _ResultWinScoreText.text = _TotalScorenya.ToString();
            _ResultWinPanel.SetActive(true);
        }
        //kalah
        else
        {
            _LoseKembaliKeTitle.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(_scene);
            });
            _ResultWinScoreText.text = _TotalScorenya.ToString();
            _ResultlosePanel.SetActive(true);
        }
        _RivalPanelScore.SetActive(false);
    }

}
