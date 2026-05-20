using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float timer = 0f;
    public GameObject banana;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 20f)
        {
            float x = Random.Range(minX, maxX);
            float y = Random.Range(minY, maxY);
            Vector3 pos = new Vector3(x, y, transform.position.z);
            Instantiate(banana, pos, Quaternion.identity);
            timer = 0f;
        }
    }

    // Åö ê∂ê¨îÕàÕÇ Scene è„Ç…ï\é¶
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        float width = maxX - minX;
        float height = maxY - minY;

        Vector3 center = new Vector3(
            (minX + maxX) / 2f,
            (minY + maxY) / 2f,
            transform.position.z
        );

        Gizmos.DrawWireCube(center, new Vector3(width, height, 0.1f));
    }
}
