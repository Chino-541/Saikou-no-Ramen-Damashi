using UnityEngine;
using UnityEngine.SceneManagement;

public class Vegetable : MonoBehaviour
{
    public GameObject banana;
    private Vector3 spawnPos;
    private bool harvested = false;

    private void Start()
    {
        spawnPos = transform.position;
    }

    public void Harvest()
    {
        harvested = true;
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if (!Application.isPlaying) return;

        // 採取による Destroy 以外（シーン切り替えなど）は生成しない
        if (!harvested) return;

        Instantiate(banana, spawnPos, Quaternion.identity);
    }
}
