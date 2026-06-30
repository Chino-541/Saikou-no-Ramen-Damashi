using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer sr;

    // スピード関連
    public float speed = 2.0f;
    public float dash = 5.0f;
    private float currentSpeed;

    private Rigidbody2D _rb;

    // 攻撃obj
    public GameObject Attack;

    // 攻撃クールタイム
    public float attackCooldown = 0.5f;
    private float currentAttackCooldown;

    // ゲーム開始時に攻撃できるようにする
    private bool canAttack = true;

    Vector2 facing = Vector2.down;

    bool isAttacking = false;
    private bool canMove = true;

    // バフの時のオーラ的な
    public GameObject aura;

    public AudioSource attackSound;

    void Start()
    {
        aura.SetActive(false);
        _rb = GetComponent<Rigidbody2D>();
        currentSpeed = speed;
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        Attack.SetActive(false);

        currentAttackCooldown = attackCooldown;

        //  Animator の攻撃フラグを必ず初期化
        anim.SetBool("isAttacking", false);
    }

    void Update()
    {
        // 動けない時の処理
        if (!canMove)
        {
            _rb.linearVelocity = Vector2.zero;
            anim.SetBool("isRunning", false);
            ResetDirectionBools();
            return;
        }

        // ★ 攻撃していないときは攻撃アニメーションを強制OFF
        if (!isAttacking)
            anim.SetBool("isAttacking", false);

        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(inputX, inputY).normalized;

        _rb.linearVelocity = dir * currentSpeed;

        UpdateDirectionBools(inputX, inputY);

        anim.SetBool("isRunning", dir.magnitude > 0);

        currentSpeed = Input.GetKey(KeyCode.RightShift) ? dash : speed;

        Attacker();
    }

    void UpdateDirectionBools(float inputX, float inputY)
    {
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
    }

    void ResetDirectionBools()
    {
        anim.SetBool("up", false);
        anim.SetBool("down", false);
        anim.SetBool("right", false);
        anim.SetBool("left", false);
    }

    // 攻撃処理
    void Attacker()
    {
        if (Input.GetKeyDown(KeyCode.V) && canAttack)
        {
            StartCoroutine(AttackForOneSecond());
            StartCoroutine(AttackCooldownCoroutine());
        }
    }

    IEnumerator AttackCooldownCoroutine()
    {
        canAttack = false;
        attackSound.Play();
        isAttacking = true;

        yield return new WaitForSeconds(currentAttackCooldown);

        isAttacking = false;
        canAttack = true;
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

        // ★ Animator が null でも落ちないようにする
        if (anim != null)
        {
            anim.SetBool("isDisabled", true);
        }
        else
        {
            Debug.LogWarning("Player: Animator がまだ初期化されていません（Start() より前に呼ばれています）");
        }

        yield return new WaitForSeconds(seconds);

        if (anim != null)
        {
            anim.SetBool("isDisabled", false);
        }

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
        sr.color = Color.yellow;
        aura.SetActive(true);

        speed = originalSpeed * 2f;
        dash = originalDash * 2f;

        yield return new WaitForSeconds(seconds);

        aura.SetActive(false);
        sr.color = Color.white;

        speed = originalSpeed;
        dash = originalDash;
    }

    // 攻撃間隔短縮
    public void PowerUp(float seconds)
    {
        StartCoroutine(PowerUpCoroutine(seconds));
    }

    IEnumerator PowerUpCoroutine(float seconds)
    {
        float originalCooldown = attackCooldown;

        currentAttackCooldown = attackCooldown * 0.3f;

        aura.SetActive(true);

        yield return new WaitForSeconds(seconds);

        currentAttackCooldown = originalCooldown;
        aura.SetActive(false);
    }
}
