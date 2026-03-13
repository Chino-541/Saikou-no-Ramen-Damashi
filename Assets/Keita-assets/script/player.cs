using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    Rigidbody2D rb;
    float axish; // 入力
    public float speed; // 速さ
    public float Dash;
    InputAction moveAction; // moveアクション
    bool isDash;

    public float Camleft;   // カメラ左リミット
    public float CamRight;  // カメラ右リミット
    public float CamTop;    // カメラ上リミット
    public float CamBottom; // カメラ下リミット

    void Start()
    {
        isDash = false;
        rb = GetComponent<Rigidbody2D>();

        PlayerInput input = GetComponent<PlayerInput>();
        moveAction = input.currentActionMap.FindAction("move");
    }

    void Update()
    {
        Vector2 inputVec = moveAction.ReadValue<Vector2>();
        rb.linearVelocity = inputVec * speed;

        // Rigidbody2D の移動は MovePosition を使う
        // Vector2 move = inputVec * speed * Time.deltaTime;
        //rb.MovePosition(rb.position + move);

        // 向き調整
        axish = inputVec.x;
        if (axish > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (axish < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }

        // カメラ制御
        float x = Mathf.Clamp(transform.position.x, Camleft, CamRight);
        float y = Mathf.Clamp(transform.position.y, CamBottom, CamTop);
        Camera.main.transform.position = new Vector3(x, y, -10);
        float currentSpeed = isDash ? speed * Dash : speed;

if (Keyboard.current.leftShiftKey.wasPressedThisFrame)
            isDash = true;

        if (Keyboard.current.leftShiftKey.wasReleasedThisFrame)
            isDash = false;

    }
   
}
