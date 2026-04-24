using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float timer = 0f;
    public GameObject banana;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 10f)
        {
            Instantiate(banana, transform.position, Quaternion.identity);
            timer = 0f; // ŒJ‚è•Ô‚µ
        }
    }
}
