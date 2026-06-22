using UnityEngine;
using System.Collections;

public class Player2 : MonoBehaviour
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
      
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(inputX, inputY).normalized;

  
        _rb.linearVelocity = dir * currentSpeed;

  
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

        
        if (inputY > 0)
            facing = Vector2.up;
        else if (inputY < 0)
            facing = Vector2.down;

       
        anim.SetBool("isRunning", dir.magnitude > 0);

       
        currentSpeed = Input.GetKey(KeyCode.RightShift) ? dash : speed;

       
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
