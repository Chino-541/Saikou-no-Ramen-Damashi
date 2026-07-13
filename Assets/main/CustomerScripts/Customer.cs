using UnityEngine;

public class Customer : MonoBehaviour
{
    private MiniGameManager miniGame;
    private CustomerSpawner spawner;

    public void Setup(MiniGameManager manager, CustomerSpawner spawnerRef)
    {
        miniGame = manager;
        spawner = spawnerRef;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // ミニゲームを起こした「この Customer だけ」イベント登録する
            miniGame.OnMiniGameEnd += DestroySelf;

            miniGame.MiniGame();
        }
    }

    // bool を受け取る形にする（使わなくてもOK）
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
