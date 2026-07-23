using System.Collections;
using UnityEngine;

public class TrackSpawn : MonoBehaviour
{
    [SerializeField] private GameObject track;

    // 危険地帯（点滅する場所）
    [SerializeField] private GameObject[] dangerZone;

    // トラックがスポーンする場所
    [SerializeField] private GameObject[] SpawnArea;

    [SerializeField] private float timer = 10f;

    private bool isBlinking = false;
    private Coroutine blinkRoutine;

    private SpriteRenderer currentSR; // 今点滅している場所

    private Color blinkRed = new Color(1f, 0f, 0f, 100f / 255f);
    private Color transparent = new Color(1f, 1f, 1f, 0f);

    private int spawnIndex; // どの場所からスポーンするかの値

    void Start()
    {
        // 最初にランダムでスポーン場所を決める
        spawnIndex = Random.Range(0, SpawnArea.Length);

        // 対応する危険地帯の SpriteRenderer を取得
        currentSR = dangerZone[spawnIndex].GetComponent<SpriteRenderer>();
        currentSR.color = transparent;
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
                StopCoroutine(blinkRoutine);

            currentSR.color = transparent;
            isBlinking = false;

            // 対応する SpawnArea の位置にトラックを生成
            Instantiate(track, SpawnArea[spawnIndex].transform.position, Quaternion.identity);

            // 次のスポーン場所をランダムで決める
            spawnIndex = Random.Range(0, SpawnArea.Length);
            currentSR = dangerZone[spawnIndex].GetComponent<SpriteRenderer>();
            currentSR.color = transparent;

            timer = 10f;
        }
    }

    IEnumerator BlinkDanger()
    {
        while (true)
        {
            currentSR.color = blinkRed;
            yield return new WaitForSeconds(0.2f);

            currentSR.color = transparent;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
