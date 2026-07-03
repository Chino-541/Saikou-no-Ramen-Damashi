using System.Collections;
using UnityEngine;

public class TrackSpawn : MonoBehaviour
{
    // Areaの色
    [SerializeField] private Material sr;
    // 通る位置
    [SerializeField] private GameObject DArea;
    [SerializeField] private GameObject track;
   
    [SerializeField] private float timer = 10f;

    private bool isBlinking = false;

    void Update()
    {
        timer -= Time.deltaTime;

        // 残り3秒になったら点滅開始
        if (timer <= 3f && !isBlinking)
        {
            StartCoroutine(BlinkDanger());
            isBlinking = true;
        }

        // 0になったら生成して点滅停止
        if (timer <= 0f)
        {
            StopCoroutine(BlinkDanger());
            sr.color = Color.white; // 色を戻す
            isBlinking = false;

            Instantiate(track, transform.position, Quaternion.identity);
            timer = 10f;
        }
    }

    IEnumerator BlinkDanger()
    {
        while (true)
        {
            sr.color = Color.red;
            yield return new WaitForSeconds(0.2f);

            sr.color = Color.white;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
