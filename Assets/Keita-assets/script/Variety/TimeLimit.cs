using System.Collections;
using UnityEngine;

public class TimeLimit : MonoBehaviour
{
    private SpriteRenderer sr;

    float totalTime = 10f;
    bool isBlinking = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        totalTime -= Time.deltaTime;

        // 2ïbà»â∫Ç…Ç»Ç¡ÇΩÇÁì_ñ≈
        if (totalTime <= 2f && !isBlinking)
        {
            isBlinking = true;
            StartCoroutine(Blink());
            Debug.Log("âÛÇÍÇÈÇ‹Ç≈Ç†Ç∆2ïb");
        }

        // 0ïbà»â∫Ç≈âÛÇÍÇÈ
        if (totalTime <= 0f)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Blink()
    {
        float interval = 0.2f;

        while (totalTime > 0f) // âÛÇÍÇÈÇ‹Ç≈ì_ñ≈
        {
            sr.enabled = !sr.enabled;
            yield return new WaitForSeconds(interval);
        }

        sr.enabled = true; // ç≈å„ÇÕï\é¶Ç…ñﬂÇ∑
    }
}
