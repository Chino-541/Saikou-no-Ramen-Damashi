using System.Collections;
using UnityEngine;

public class TrackSpawn : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private GameObject track;

    [SerializeField] private float timer = 10f;

    private bool isBlinking = false;
    private Coroutine blinkRoutine;

    // 薄い赤色
    private Color blinkRed = new Color(1f, 0f, 0f, 100f/ 255f);
    private Color transparent = new Color(1f, 1f, 1f, 0f); // 完全透明

    void Start()
    {
        sr.color = transparent;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        // 残り3秒で点滅開始
        if (timer <= 3f && !isBlinking)
        {
            blinkRoutine = StartCoroutine(BlinkDanger());
            isBlinking = true;
        }

        // 0になったら生成して点滅停止
        if (timer <= 0f)
        {
            if (blinkRoutine != null)
            {
                StopCoroutine(blinkRoutine);
            }

            sr.color = transparent; // 完全透明に戻す
            isBlinking = false;

            Instantiate(track, transform.position, Quaternion.identity);
            timer = 10f;
        }
    }

    IEnumerator BlinkDanger()
    {
        while (true)
        {
            sr.color = blinkRed; // 薄い赤
            yield return new WaitForSeconds(0.2f);

            sr.color = transparent; // 透明
            yield return new WaitForSeconds(0.2f);
        }
    }
}
