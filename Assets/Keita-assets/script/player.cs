using UnityEngine;

public class Player : MonoBehaviour
{
    // animator使えるようにする？
    private Animator anim;
    // 速さ
    public float speed = 2.0f;
    public float dash = 5.0f;
    private float currentSpeed;
    // 攻撃の判定を入れる
    public GameObject Attack;
    // bool isDashing = false;
    Vector2 move = Vector2.zero;

    void Start()
    {
        // 速さの定義？
        currentSpeed = speed;
        // animatorを取得
        anim = GetComponent<Animator>();
        // 攻撃オブジェクトを非表示にする
        Attack.SetActive(false);
    }

    void Update()
    {
        move = Vector2.zero;

        // --- 左右 ---
        if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("left", true);
            anim.SetBool("right", false);
            anim.SetBool("Up", false);
            anim.SetBool("down", false);
            anim.SetBool("move", true);
            move.x = -1;

        }
        else if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("right", true);
            anim.SetBool("left", false);
            anim.SetBool("Up", false);
            anim.SetBool("down", false);
            anim.SetBool("move", true);
            move.x = 1;
        }

        // --- 上下 ---
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("Up", true);
            anim.SetBool("left", false);
            anim.SetBool("right", false);
            anim.SetBool("down", false);
            anim.SetBool("move", true);
            move.y = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("down", true);
            anim.SetBool("left", false);
            anim.SetBool("right", false);
            anim.SetBool("Up", false);
            anim.SetBool("move", true);


            move.y = -1;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetTrigger("jump");
        }
        if (Input.GetKey(KeyCode.RightShift))
        {
            // isDashing = true;
            currentSpeed = dash;
        }
        else
        {
            {
                currentSpeed = speed;
            }
        }

        // キー押してない
        if (move == Vector2.zero)
        {
            anim.SetBool("move", false);
        }
        // 攻撃
        Attacker();
    }

    void FixedUpdate()
    {
        transform.Translate(move.normalized * currentSpeed * Time.fixedDeltaTime);
    }
    void Attacker()
    {

        if (Input.GetKey(KeyCode.V))
        {
            Attack.SetActive(true);

            Debug.Log("攻撃してるよ");
        }
        else
        {
            Attack.SetActive(false);
        }
    }
}