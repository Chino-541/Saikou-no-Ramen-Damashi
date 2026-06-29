using UnityEngine;

public class Fisher : MonoBehaviour
{
    [SerializeField] private GameObject FishingUI;   // 釣りUI
    [SerializeField] private Ken_GFish fishSystem;   // 釣りロジック

    private bool isFishing = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            if (!isFishing)
            {
                isFishing = true;

                // UI を表示
                FishingUI.SetActive(true);

                // Ken_GFish に釣り開始を指示
               // fishSystem.StartFishing();

                Debug.Log("釣り開始");
            }
        }
    }

    // Ken_GFish から呼び出される釣り終了フラグ
    public void EndFishingFlag()
    {
        isFishing = false;
    }
}
