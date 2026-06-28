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
    private bool canMove = true;

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
        if (!canMove)
        {
            _rb.linearVelocity = Vector2.zero;
            anim.SetBool("isRunning", false);
            ResetDirectionBools();
            return;
        }

        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(inputX, inputY).normalized;

        _rb.linearVelocity = dir * currentSpeed;

        //  方向アニメーション
        UpdateDirectionBools(inputX, inputY);

        anim.SetBool("isRunning", dir.magnitude > 0);

        currentSpeed = Input.GetKey(KeyCode.RightShift) ? dash : speed;

        Attacker();
    }


    void UpdateDirectionBools(float inputX, float inputY)
    {
        // 入力があるときだけ方向を更新する
        if (inputX != 0 || inputY != 0)
        {
            ResetDirectionBools();

            if (inputX > 0)
            {
                anim.SetBool("right", true);
                sr.flipX = false;
                facing = Vector2.right;
                return;
            }
            else if (inputX < 0)
            {
                anim.SetBool("left", true);
                sr.flipX = true;
                facing = Vector2.left;
                return;
            }

            if (inputY > 0)
            {
                anim.SetBool("up", true);
                facing = Vector2.up;
            }
            else if (inputY < 0)
            {
                anim.SetBool("down", true);
                facing = Vector2.down;
            }
        }

        // 入力がないときは何もしない（最後の向きを維持）
    }

    //  全方向 false にする
    void ResetDirectionBools()
    {
        anim.SetBool("up", false);
        anim.SetBool("down", false);
        anim.SetBool("right", false);
        anim.SetBool("left", false);
    }

    // 攻撃
    public AudioSource attackSound;

    void Attacker()
    {
        if (Input.GetKeyDown(KeyCode.V) && !isAttacking)
        {
            attackSound.Play();  // 攻撃音
            Debug.Log("attacking");
            StartCoroutine(AttackForOneSecond());
        }
    }


    IEnumerator AttackForOneSecond()
    {
        isAttacking = true;

        Attack.transform.localPosition = facing * 0.7f;

        Attack.SetActive(true);
        anim.SetBool("isAttacking", true);

        yield return new WaitForSeconds(0.5f);

        anim.SetBool("isAttacking", false);
        Attack.SetActive(false);
        isAttacking = false;
    }

    // 入力無効化
    public void DisableInput(float seconds)
    {
        StartCoroutine(DisableInputCoroutine(seconds));
    }

    private IEnumerator DisableInputCoroutine(float seconds)
    {
        canMove = false;
        yield return new WaitForSeconds(seconds);
        canMove = true;
    }

    // スピードアップ
    public void SpeedUp(float seconds)
    {
        StartCoroutine(SpeedUpCoroutine(seconds));
    }

    IEnumerator SpeedUpCoroutine(float seconds)
    {
        float originalSpeed = speed;
        float originalDash = dash;

        speed = originalSpeed * 2f;
        dash = originalDash * 2f;

        yield return new WaitForSeconds(seconds);

        speed = originalSpeed;
        dash = originalDash;
    }
}
