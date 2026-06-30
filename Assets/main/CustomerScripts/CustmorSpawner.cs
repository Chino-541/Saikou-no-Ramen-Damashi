using UnityEngine;
using System.Collections;

public class CustomerSpawner : MonoBehaviour
{
    // お客さん
    [SerializeField] private GameObject customerPrefab;
    // 範囲
    [SerializeField] private PolygonCollider2D spawnArea;
    // 生成間隔
    [SerializeField] private float spawnDelay = 10f;
    // お客さんが消える(?)
    [SerializeField] private float destroyDelay = 12f;
    // 同時に存在できる人数
    [SerializeField] private int maxSpawn = 5;
    // 生成人数と生成できるかのbool
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
            // boolがいけて規定人数を下回ってたらspawn開始
            if (canSpawn && currentSpawn < maxSpawn)
            {
                Vector2 pos = GetRandomPos();
                GameObject obj = Instantiate(customerPrefab, pos, Quaternion.identity);

                currentSpawn++;
                StartCoroutine(DestroyDelay(obj));
            }

            yield return new WaitForSeconds(spawnDelay);
        }
    }
    // 一定時間たったらお客さんが消えるコルーチン
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
    // ランダムにスポーン
    Vector2 GetRandomPos()
    {
        Bounds b = spawnArea.bounds;
        return new Vector2(Random.Range(b.min.x, b.max.x), Random.Range(b.min.y, b.max.y));
    }
}
