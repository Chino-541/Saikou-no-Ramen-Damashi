using UnityEngine;

public class Customer : MonoBehaviour
{
    private MiniGameManager miniGame;
    private CustomerSpawner spawner;

    public void Setup(MiniGameManager manager, CustomerSpawner spawnerRef)
    {
        miniGame = manager;
        spawner = spawnerRef;

        // ミニゲーム終了時にこの Customer を消す
        miniGame.OnMiniGameEnd += DestroySelf;
    }

    private void DestroySelf()
    {
        // すでに破棄されていたら何もしない
        if (this == null) return;

        // スポナーに通知
        spawner.CustomerDestroyed();

        // 自分を消す
        Destroy(gameObject);

        // イベント解除（重要）
        miniGame.OnMiniGameEnd -= DestroySelf;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            miniGame.MiniGame();
        }
    }
}
