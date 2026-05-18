using System.Collections;
using UnityEngine;

public class Ken_Pelangan : MonoBehaviour
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



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnPelangan());
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
}
