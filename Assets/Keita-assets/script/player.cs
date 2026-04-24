using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private Animator anim;

    public float speed = 2.0f;
    public float dash = 5.0f;
    private float currentSpeed;

    public GameObject Attack;

    Vector2 move = Vector2.zero;
    Vector2 facing = Vector2.down; // 初期向き
    bool isAttacking = false;

    void Start()
    {
        currentSpeed = speed;
        anim = GetComponent<Animator>();
        Attack.SetActive(false);
    }

    void Update()
    {
        move = Vector2.zero;

        // --- 左右 ---
        if (Input.GetKey(KeyCode.A))
        {
            move.x = -1;
            facing = Vector2.left;
            SetAnimDirection("left");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            move.x = 1;
            facing = Vector2.right;
            SetAnimDirection("right");
        }

        // --- 上下 ---
        if (Input.GetKey(KeyCode.W))
        {
            move.y = 1;
            facing = Vector2.up;
            SetAnimDirection("Up");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            move.y = -1;
            facing = Vector2.down;
            SetAnimDirection("down");
        }

        // 移動していない
        if (move == Vector2.zero)
        {
            anim.SetBool("move", false);
        }

        // ジャンプ
        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetTrigger("jump");
        }

        // ダッシュ
        currentSpeed = Input.GetKey(KeyCode.RightShift) ? dash : speed;

        // 攻撃
        Attacker();
    }

    void FixedUpdate()
    {
        transform.Translate(move.normalized * currentSpeed * Time.fixedDeltaTime);
    }

    // アニメーション方向設定
    void SetAnimDirection(string dir)
    {
        anim.SetBool("move", true);
        anim.SetBool("left", dir == "left");
        anim.SetBool("right", dir == "right");
        anim.SetBool("Up", dir == "Up");
        anim.SetBool("down", dir == "down");
    }

    // 攻撃処理
    void Attacker()
    {
        if (Input.GetKeyDown(KeyCode.V) && !isAttacking)
        {
            StartCoroutine(AttackForOneSecond());
        }
    }

    IEnumerator AttackForOneSecond()
    {
        isAttacking = true;

        // 攻撃位置をプレイヤーの正面に移動
        Attack.transform.localPosition = facing * 0.5f;

        Attack.SetActive(true);
        Debug.Log("攻撃してるよ");

        yield return new WaitForSeconds(0.5f);

        Attack.SetActive(false);
        isAttacking = false;
    }
}
