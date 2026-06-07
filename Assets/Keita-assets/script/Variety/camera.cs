using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform player; //

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void LateUpdate()
    {
        // 目標位置（プレイヤー位置 + オフセット）
        Vector3 nextPos = player.position + offset;

        // 現在位置から目標位置へ移動
        Vector3 newPos = Vector3.Lerp(transform.position, nextPos, smoothSpeed);

        // カメラの位置を更新
        transform.position = newPos;
    }
}