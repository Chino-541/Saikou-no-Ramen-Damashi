using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private Animator anim;

    public float speed = 2.0f;
    public float dash = 5.0f;
    private float currentSpeed;
    private Rigidbody2D _rb;
    public GameObject Attack;

    Vector2 move = Vector2.zero;
    Vector2 facing = Vector2.down; 
    bool isAttacking = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        currentSpeed = speed;
        anim = GetComponent<Animator>();
        Attack.SetActive(false);
    }

    void Update()
    {
       // move = Vector2.zero;
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(inputX, inputY).normalized;
        _rb.linearVelocity = dir * currentSpeed;
        

        // --- ???E ---
        if (Input.GetKey(KeyCode.A))
        {
            // move.x = -1;
            facing = Vector2.left;
            SetAnimDirection("left");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            // move.x = 1;
            facing = Vector2.right;
            SetAnimDirection("right");
        }

        // --- ?? ---
        if (Input.GetKey(KeyCode.W))
        {
            // move.y = 1;
            facing = Vector2.up;
            SetAnimDirection("Up");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            // move.y = -1;
            facing = Vector2.down;
            SetAnimDirection("down");
        }

        // ???????????
        if (move == Vector2.zero)
        {
            anim.SetBool("move", false);
        }

        // ƒWƒƒƒ“ƒv
        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetTrigger("jump");
        }

        
        currentSpeed = Input.GetKey(KeyCode.RightShift) ? dash : speed;

       
        Attacker();
    }

    void FixedUpdate()
    {
        transform.Translate(move.normalized * currentSpeed * Time.fixedDeltaTime);
    }

    
    void SetAnimDirection(string dir)
    {
        anim.SetBool("move", true);
        anim.SetBool("left", dir == "left");
        anim.SetBool("right", dir == "right");
        anim.SetBool("Up", dir == "Up");
        anim.SetBool("down", dir == "down");
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

       
        Attack.transform.localPosition = facing * 0.5f;

        Attack.SetActive(true);
        Debug.Log("attaking");

        yield return new WaitForSeconds(0.5f);

        Attack.SetActive(false);
        isAttacking = false;
    }
}
