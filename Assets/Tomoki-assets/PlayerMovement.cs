using UnityEngine;

// 💡 これを書いておくと、スクリプトを付けた時に自動でRigidbody2Dも追加してくれます
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("移動スピード")]
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;

    private void Start()
    {
        // プレイヤーに付いている Rigidbody2D（物理エンジン）を取得
        rb = GetComponent<Rigidbody2D>();

        // 見下ろし型ゲームの場合、重力で下に落ちていかないように 0 に設定
        rb.gravityScale = 0f;

        // 壁にぶつかった時にキャラクターがクルクル回転しないように固定
        rb.freezeRotation = true;
    }

    private void Update()
    {
        // 入力の受け取り（W/S/A/Dキー や 矢印キーに自動対応しています）
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // 💡 斜め移動のスピードが速くならないように正規化（長さを1に）する
        movement = movement.normalized;
    }

    private void FixedUpdate()
    {
        // 物理エンジンを使ってキャラクターを実際に動かす
        rb.linearVelocity = movement * moveSpeed;
    }
}