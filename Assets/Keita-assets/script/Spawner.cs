using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float timer = 0f;
    public GameObject banana;

    // ”ÍˆÍ
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

            Vector3 pos = new Vector3(
                x,
                y,
                transform.position.z
            );

            Instantiate(banana, pos, Quaternion.identity);
            timer = 0f;
        }
    } 
}
