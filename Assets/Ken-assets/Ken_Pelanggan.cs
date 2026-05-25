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

    [BoxGroup("LastS")][SerializeField] private GameObject _PanelScore;
    //public Ken_LScore _LScoreScript;


    [BoxGroup("LastS")][SerializeField] private int _RamenScorenya = 0;
    [BoxGroup("LastS")][SerializeField] private TextMeshProUGUI _RamenScoreTextnya;
    [BoxGroup("LastS")][SerializeField] private int _RamenTerjualnya = 0;
    [BoxGroup("LastS")][SerializeField] private TextMeshProUGUI _RamenTerjualTextnya;
    [BoxGroup("LastS")][SerializeField] private int _TotalScorenya = 0;
    [BoxGroup("LastS")][SerializeField] private string _TotalScoreString;
    [BoxGroup("LastS")][SerializeField] private TextMeshProUGUI _TotalScoreTextnya;

    [BoxGroup("Scene")][SerializeField] private Button _TitleButton;
    [Scene][BoxGroup("Scene")][SerializeField] private int _scene;
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

        _TitleButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(_scene);
        });
    }
}
