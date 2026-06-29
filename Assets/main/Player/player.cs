using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer sr;

    // ƒXƒs[ƒhŠÖ˜A
    public float speed = 2.0f;
    public float dash = 5.0f;
    private float currentSpeed;

    private Rigidbody2D _rb;

    // UŒ‚obj
    public GameObject Attack;

    // UŒ‚ƒN[ƒ‹ƒ^ƒCƒ€
    public float attackCooldown = 0.5f;   // ’Êí‚ÌUŒ‚ŠÔŠu
    private float currentAttackCooldown;  // ¡‚ÌUŒ‚ŠÔŠu
    private bool canAttack = true;

    Vector2 facing = Vector2.down;

    bool isAttacking = false;
    private bool canMove = true;

    // ƒoƒt‚Ì‚ÌƒI[ƒ‰“I‚È
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

        currentAttackCooldown = attackCooldown; // ‰Šú‰»
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

    // UŒ‚ˆ—
    void Attacker()
    {
        if (Input.GetKeyDown(KeyCode.V) && canAttack)
        {
            attackSound.Play();
            StartCoroutine(AttackForOneSecond());
            StartCoroutine(AttackCooldownCoroutine());
        }
    }

    IEnumerator AttackCooldownCoroutine()
    {
        canAttack = false;
        yield return new WaitForSeconds(currentAttackCooldown);
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

    // “ü—Í–³Œø‰»
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

    // ƒXƒs[ƒhƒAƒbƒv
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

    // UŒ‚ŠÔŠu’Zkj
    public void PowerUp(float seconds)
    {
        StartCoroutine(PowerUpCoroutine(seconds));
    }

    IEnumerator PowerUpCoroutine(float seconds)
    {
        float originalCooldown = attackCooldown;

        // UŒ‚ŠÔŠu‚ğ’Zk
        currentAttackCooldown = attackCooldown * 0.3f;

        aura.SetActive(true);
        // sr.color = Color.red;

        yield return new WaitForSeconds(seconds);

        // Œ³‚É–ß‚·
        currentAttackCooldown = originalCooldown;
        aura.SetActive(false);
       //  sr.color = Color.white;
    }
}
