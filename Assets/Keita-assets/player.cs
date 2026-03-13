using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    CharacterController cc;
    float axish; // 入力
    public float speed; // ひゃさ
    InputAction moveAction; // moveアクション
    public float Camleft; // カメラ左リミット
    public float CamRight; // カメラ右リミット
    public float CamTop; // カメラ上リミット
    public float CamBottom; // カメラ下リミット
    Animator animator; // アニメーター
    void Start()
    {
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        PlayerInput input = GetComponent<PlayerInput>(); // playerinput取得
        moveAction = input.currentActionMap.FindAction("move"); // movesy得
    }
    void Update()
    {
        Vector2 inputVec = moveAction.ReadValue<Vector2>();

        // 実際に動かす
        Vector3 move = new Vector3(inputVec.x, inputVec.y, 0);
        cc.Move(move * speed * Time.deltaTime);

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
        // アニメーション制御
        //animator.SetBool("isMove", (axish != 0));
    }
}