using UnityEngine;

public class Customer : MonoBehaviour
{
    // ミニゲームとスポナー
    private MiniGameManager miniGame;
    private CustomerSpawner spawner;

    // ミニゲームとスポナーのセットアップ
    public void Setup(MiniGameManager manager, CustomerSpawner spawnerRef)
    {
        miniGame = manager;
        spawner = spawnerRef;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // ミニゲームを起こしたCustomerのイベントを登録
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
}
