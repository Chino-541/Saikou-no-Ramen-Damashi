using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ken_Pelanggan : MonoBehaviour
{
    [Header("Nyanスクリプトへようこそ")]
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _customer;

    //[SerializeField] private float _minX, _minY, _maxX, _maxY;

    [SerializeField] private bool _BisaSpawn = false;
    [SerializeField] private int _SpawnDelay = 10;
    [SerializeField] private float _SpawnDestroy = 12;

    [SerializeField] private int _Spawn = 0;
    [SerializeField] private const int _MinSpawn = 0;
    [SerializeField] private int _MaxSpawn = 5;


    [SerializeField] private PolygonCollider2D _PColl;

    [SerializeField] private static int _poin = 0;
    [SerializeField] private string _SPoin = "販売した数：";
    [SerializeField] private TextMeshProUGUI _TmpPoin;

    public static Ken_Pelanggan _PelangganInstance;


    [SerializeField] private int _WaktuMain = 60;
    [SerializeField] private TextMeshProUGUI _TmpWaktuMain;
    [SerializeField] private Rigidbody2D _RigidbodyPlayer;

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

                Destroy(Spawner, _SpawnDestroy);

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
        _TmpWaktuMain.text = _BisaSpawn.ToString();


        _BisaSpawn = true;
        while (_BisaSpawn)
        {
            _WaktuMain--;
            _TmpWaktuMain.text = _BisaSpawn.ToString();
            yield return new WaitForSeconds(1);
            if (_WaktuMain == 0)
            {
                _BisaSpawn = false;
                //Stop gerak 
                //_RigidbodyPlayer.constraints = false;
                _RigidbodyPlayer.constraints = RigidbodyConstraints2D.FreezePositionX
                                            | RigidbodyConstraints2D.FreezePositionY;


            }
        }
        
    }
}
