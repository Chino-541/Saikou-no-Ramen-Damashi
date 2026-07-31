using UnityEngine;

public class Fisher : MonoBehaviour
{
    [SerializeField] private Fishing fishSystem;

    private bool isFishing = false;
    private bool playerInArea = false;

    private void Update()
    {
        // 釣りできる範囲にいるとき
        if (playerInArea)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Eキー押した");

                if (!isFishing)
                {
                    Debug.Log("釣りはじめ");
                    isFishing = true;

                    fishSystem.StartFishing();
                }
            }
        }
    }

    // 釣り範囲に入ってる間
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("釣り場にいるよ");
            playerInArea = true;
        }
    }
    // 出たとき
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("釣り場から出た");
            playerInArea = false;
        }
    }
    // 終わったときにboolをfalseに戻す
    public void EndFishing()
    {
        Debug.Log("Triggerがfalseになたよ");
        isFishing = false;
    }
}
