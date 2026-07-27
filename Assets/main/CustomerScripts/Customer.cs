using UnityEngine;

public class Customer : MonoBehaviour
{
    // ミニゲームとスポナー
    private MiniGameManager miniGame;
    private CustomerSpawner spawner;

    // ミニゲームとスポナーのセット
    public void Setup(MiniGameManager manager, CustomerSpawner spawnerRef)
    {
        miniGame = manager;
        spawner = spawnerRef;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Ken_PChar ken = collision.gameObject.GetComponent<Ken_PChar>();

            // BonusTime 中ならミニゲームなしで即得点
            if (ken.isBonusTime)  // ← BonusTime フラグを使う
            {
                miniGame.OnMiniGameEnd?.Invoke(true);
                DestroySelf(true);
                return;
            }

            // 通常時はミニゲーム開始
            miniGame.OnMiniGameEnd += DestroySelf;
            miniGame.MiniGame();
        }
    }


    // 引数で正誤判定
    private void DestroySelf(bool isCorrect)
    {
        if (this == null) return;

        // スポナーに通知
        spawner.CustomerDestroyed();

        // 自分を消す
        Destroy(gameObject);

        // イベント解除
        miniGame.OnMiniGameEnd -= DestroySelf;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Track"))
        {
            // スポナーに通知
            spawner.CustomerDestroyed(); 
            Destroy(gameObject);
        }
    }
}
