using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer sr;

    public float speed = 2.0f;
    public float dash = 5.0f;
    private float currentSpeed;
    private Rigidbody2D _rb;
    public GameObject Attack;

    Vector2 facing = Vector2.down;
    bool isAttacking = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        currentSpeed = speed;
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        Attack.SetActive(false);
    }

    void Update()
    {
        // 入力取得
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(inputX, inputY).normalized;

        // 移動
        _rb.linearVelocity = dir * currentSpeed;

        // 左右反転は flipX を使う（子オブジェクトに影響しない）
        if (inputX > 0)
        {
            sr.flipX = false;
            facing = Vector2.right;
        }
        else if (inputX < 0)
        {
            sr.flipX = true;
            facing = Vector2.left;
        }

        // 上下の向き
        if (inputY > 0)
            facing = Vector2.up;
        else if (inputY < 0)
            facing = Vector2.down;

        // 走るアニメーション
        anim.SetBool("isRunning", dir.magnitude > 0);

        // ダッシュ
        currentSpeed = Input.GetKey(KeyCode.RightShift) ? dash : speed;

        // 攻撃
        Attacker();
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

        // 攻撃方向に合わせて位置を更新
        Attack.transform.localPosition = facing * 0.2f;

        Attack.SetActive(true);
        anim.SetBool("isAttacking", true);
        Debug.Log("attacking");

        yield return new WaitForSeconds(0.5f);

        anim.SetBool("isAttacking", false);
        Attack.SetActive(false);
        isAttacking = false;
    }
}
