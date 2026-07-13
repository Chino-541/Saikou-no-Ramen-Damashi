using UnityEngine;
using System.Collections;

public class CustomerSpawner : MonoBehaviour
{
    // お客さんのプレハブ
    [SerializeField] private GameObject customerPrefab;
    // スポーンするエリア
    [SerializeField] private PolygonCollider2D spawnArea;
    // スポーン間隔
    [SerializeField] private float spawnTime;

   [SerializeField] private float destroyDelay = 12f;
   // 場に存在できる最大数
   [SerializeField] private int maxSpawn = 10;
    // minigameManagerの参照的な
    [SerializeField] private MiniGameManager miniGameManager;

    private int currentSpawn = 0;
   public bool canSpawn = false;

    private void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            if (currentSpawn < maxSpawn)
            {
                Vector2 pos = GetRandomPos();
                GameObject obj = Instantiate(customerPrefab, pos, Quaternion.identity);

                // スポーン時に MiniGameManager 
                Customer customer = obj.GetComponent<Customer>();
                customer.Setup(miniGameManager, this);

                currentSpawn++;
               // StartCoroutine(DestroyDelay(obj));
            }

            yield return new WaitForSeconds(spawnTime);
        }
    }
    /*
    IEnumerator DestroyDelay(GameObject obj)
    {
        yield return new WaitForSeconds(destroyDelay);

        if (obj != null)
        {
            var pelanggan = obj.GetComponent<Ken_PelangganDua>();
            if (pelanggan != null && pelanggan._melayani)
                yield break;

            Destroy(obj);
            currentSpawn--;
        }
    }
    */
    public void CustomerDestroyed()
    {
        currentSpawn--;
    }

    Vector2 GetRandomPos()
    {
        Bounds b = spawnArea.bounds;
        return new Vector2(Random.Range(b.min.x, b.max.x), Random.Range(b.min.y, b.max.y));
    }
}
