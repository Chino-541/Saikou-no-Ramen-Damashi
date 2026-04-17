using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator anim;
    public float speed = 2.0f;
    public float dash = 5.0f;
    public GameObject bullet;
    private float currentSpeed;
    // bool isDashing = false;
    Vector2 move = Vector2.zero;

    void Start()
    {
        currentSpeed = speed;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        move = Vector2.zero;

        // --- ç∂âE ---
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

        // --- è„â∫ ---
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

        // Ç«ÇÃÉLÅ[Ç‡âüÇµÇƒÇ¢Ç»Ç¢
        if (move == Vector2.zero)
        {
            anim.SetBool("move", false);
        }
    }

    void FixedUpdate()
    {
        transform.Translate(move.normalized * currentSpeed * Time.fixedDeltaTime);
    }
    void shoot()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }
}