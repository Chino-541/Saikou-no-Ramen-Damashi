using UnityEngine;

public class Fisher : MonoBehaviour
{
    [SerializeField] private Fishing fishSystem;

    private bool isFishing = false;
    private bool playerInArea = false;

    private void Update()
    {
        // プレイヤーが範囲内にいる時だけ
        if (playerInArea)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Eキー押した");

                if (!isFishing)
                {
                    Debug.Log("釣りはじめ");
                    isFishing = true;
                    // Fishingのコルーチンはじめ
                    fishSystem.StartFishing();
                }
            }
        }
    }
    // Trigger内にいる時
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("釣り場にいるよ");
            playerInArea = true;
        }
    }
    // Trigger外に出た時
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("釣り場から出た");
            playerInArea = false;
        }
    }
    // fishingから通知受け取るとこ
    public void EndFishing()
    {
        Debug.Log("Triggerがfalseになたよ");
        isFishing = false;
    }
}
