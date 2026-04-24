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

        // --- 移動入力 ---
        if (Input.GetKey(KeyCode.A)) move.x = -1;
        if (Input.GetKey(KeyCode.D)) move.x = 1;
        if (Input.GetKey(KeyCode.W)) move.y = 1;
        if (Input.GetKey(KeyCode.S)) move.y = -1;

        // --- ダッシュ ---
        currentSpeed = Input.GetKey(KeyCode.RightShift) ? dash : speed;

        // --- 向きとアニメーション ---
        if (move != Vector2.zero)
        {
            anim.SetBool("move", true);

            // 方向判定
            if (Mathf.Abs(move.x) > Mathf.Abs(move.y))
            {
                // 横方向
                if (move.x > 0) anim.SetInteger("Direction", 2); // 右
                else anim.SetInteger("Direction", 1);            // 左
            }
            else
            {
                // 縦方向
                if (move.y > 0) anim.SetInteger("Direction", 3); // 上
                else anim.SetInteger("Direction", 0);            // 下
            }
        }
        else
        {
            anim.SetBool("move", false);
        }

        // --- ジャンプ ---
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("jump");
        }

        // --- 攻撃 ---
        Attacker();
    }

    void FixedUpdate()
    {
        transform.Translate(move.normalized * currentSpeed * Time.fixedDeltaTime);
    }

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
        Attack.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        Attack.SetActive(false);
        isAttacking = false;
    }
}
