using UnityEngine;
using System.Collections;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject customerPrefab;
    [SerializeField] private PolygonCollider2D spawnArea;
    [SerializeField] private float spawnDelay = 10f;
    [SerializeField] private float destroyDelay = 12f;
    [SerializeField] private int maxSpawn = 5;

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
            if (canSpawn && currentSpawn < maxSpawn)
            {
                Vector2 pos = GetRandomPos();
                GameObject obj = Instantiate(customerPrefab, pos, Quaternion.identity);

                // ƒXƒ|[ƒ“Žž‚É MiniGameManager 
                Customer customer = obj.GetComponent<Customer>();
                customer.Setup(miniGameManager, this);

                currentSpawn++;
                StartCoroutine(DestroyDelay(obj));
            }

            yield return new WaitForSeconds(spawnDelay);
        }
    }

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
