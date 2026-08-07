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
    // Playerがボーナスタイムの時に使う
    [SerializeField] private Ken_PChar player;

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
            bool isBonus = player.isBonusTime;

            // ボーナス中はスポーン数制限なし
            if (isBonus || currentSpawn < maxSpawn)
            {
                Vector2 pos = GetRandomPos();
                GameObject obj = Instantiate(customerPrefab, pos, Quaternion.identity);

                Customer customer = obj.GetComponent<Customer>();
                customer.Setup(miniGameManager, this);

                currentSpawn++;
            }

            // ボーナス中はスポーン間隔が半分
            // ?はif分の短縮みたいなやつでtrueなら：より左の処理、falseなら:より右の処理を返す
            float waitTime = isBonus ? spawnTime / 2f : spawnTime;
            yield return new WaitForSeconds(waitTime);
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

    // 外部からお客さんの最大数を変更する
    public void SetCustomerCount(int count)
    {
        maxSpawn = count;
    }
}
