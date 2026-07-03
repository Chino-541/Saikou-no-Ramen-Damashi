using UnityEngine;

public class TrackSpawn : MonoBehaviour
{
    // 妨害オブジェクト
    [SerializeField] private GameObject track;
    [SerializeField] private float timer = 10f;

    void Update()
    {
        // 0になったら1台生成
        timer -= Time.deltaTime;
        if (timer == 0)
        {
            Instantiate(track,transform.position, Quaternion.identity);
            timer = 10;
        }
    
    }
}
