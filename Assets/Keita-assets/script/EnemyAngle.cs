using UnityEngine;

public class EnemyAngle : MonoBehaviour
{
    public float chargeTime = 3f;
    private float timeCount;

    public float Angle = 45f;   // 視界の角度
    public float Distance = 5f; // 視界の距離
    public Transform player;
    void Update()
    {
        timeCount += Time.deltaTime;

        // 3秒ごとに左右反転
        if (timeCount > chargeTime)
        {
            float x = transform.localScale.x;
            transform.localScale = new Vector3(-x, transform.localScale.y, transform.localScale.z);
            timeCount = 0;
        }

        CheckView();
    }

    void CheckView()
    {
        if (player == null) return;

        // プレイヤーへの方向ベクトル
        Vector2 PlayerDirection = player.position - transform.position;

        // 敵の「前方向」＝ scale.x に応じて right か -right を使う
        Vector2 forward = (transform.localScale.x > 0) ? Vector2.right : Vector2.left;

        // 距離チェック
        if (PlayerDirection.magnitude > Distance) return;

        // 角度チェック
        float angle = Vector2.Angle(forward, PlayerDirection);

        if (angle < Angle)
        {
            Debug.Log("見ーつけた");
            Destroy(player.gameObject);
        }
    }
}
