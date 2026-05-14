using UnityEngine;

public class Vegetable : MonoBehaviour
{
    public GameObject banana;
    private Vector3 spawnPos;

    private void Start()
    {
        // Å‰‚É©•ª‚ÌˆÊ’u‚ğ•Û‘¶‚µ‚Ä‚¨‚­
        spawnPos = transform.position;
    }

    private void OnDestroy()
    {
        if (!Application.isPlaying) return;
        // •Û‘¶‚µ‚½ˆÊ’u‚É¶¬
        Instantiate(banana, spawnPos, Quaternion.identity);
    }
}
