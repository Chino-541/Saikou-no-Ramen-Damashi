using UnityEngine;
using UnityEngine.InputSystem;

public class DotMove : MonoBehaviour
{
    CharacterController cc;
    InputAction moveAction;

    float axish;
    public float tileSize = 1f;   // 1マスの大きさ
    public float moveSpeed = 5f;  // 補間速度
    public float Camleft; // カメラ左リミット
    public float CamRight; // カメラ右リミット
    public float CamTop; // カメラ上リミット
    public float CamBottom; // カメラ下リミット
    Animator anm; // アニメーター

    bool isMoving = false;
    Vector3 targetPos;

    void Start()
    {
        
        anm = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
        PlayerInput input = GetComponent<PlayerInput>();
        moveAction = input.currentActionMap.FindAction("move");
    }

    void Update()
    {
        if (!isMoving)
        {
            Vector2 inputVec = moveAction.ReadValue<Vector2>();

            // 入力が入った瞬間だけ動く
            if (inputVec.sqrMagnitude > 0.1f)
            {
                Vector3 dir = new Vector3(
                    Mathf.Round(inputVec.x),
                    Mathf.Round(inputVec.y),
                    0
                );

                if (dir != Vector3.zero)
                {
                    targetPos = transform.position + dir * tileSize;
                    isMoving = true;
                }
            }
        }
        else
        {
            // 目的地まで移動
            Vector3 move = (targetPos - transform.position);
            Vector3 step = move.normalized * moveSpeed * Time.deltaTime;

            if (step.sqrMagnitude >= move.sqrMagnitude)
            {
                // 到着
                transform.position = targetPos;
                isMoving = false;
            }
            else
            {
                cc.Move(step);
            }
        }

        axish = moveAction.ReadValue<Vector2>().x; // 入力をとる
        if (axish > 0.0f) // 向き調整
        {
            transform.localScale = new Vector2(1, 1); // 右移動
        }
        else if (axish < 0.0f)
        {
            transform.localScale = new Vector2(-1, 1); // 左右反転
        }
        // カメラ制御
        float x = Mathf.Clamp(transform.position.x, Camleft, CamRight);
        float y = Mathf.Clamp(transform.position.y, CamBottom, CamTop);
        Vector3 camPos = new Vector3(x, y, -10); // カメラ位置のvector3を作る
        Camera.main.transform.position = camPos; // カメラの更新座標
    }
}