using UnityEngine;
using UnityEngine.InputSystem;

public class Ken_PChar : MonoBehaviour
{
    [Header("Nyanスクリプトへようこそ")]
    [SerializeField] private Vector2 _MoveInp;
    [SerializeField] Rigidbody2D _Rb;
    [SerializeField] float _MoveSpeed = 5f;


    [SerializeField] private Sprite _Idle;
    [SerializeField] private Sprite _left;
    [SerializeField] private Sprite _Back;
    [SerializeField] private Sprite _right;

    private SpriteRenderer _Renderer;
   


    private void Awake()
    {
        _Rb = GetComponent<Rigidbody2D>();
        _Renderer = GetComponent<SpriteRenderer>();
        
       
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _Rb.linearVelocity = _MoveInp * _MoveSpeed;
        RamenYaAni();
    }
    public void Move(InputAction.CallbackContext context)
    {
        _MoveInp = context.ReadValue<Vector2>();
        
    }
    void RamenYaAni()
    {
        
        //_Anim.SetBool("Kiri", false);
        //_Anim.SetBool("Kanan", false);
        //_Anim.SetBool("Back", false);
        //_Anim.SetBool("Idle", false);

        if (_MoveInp == Vector2.zero)
        {
           // _Anim.SetBool("Idle", true);
            _Renderer.sprite = _Idle;
            
        }
       
        else if (Mathf.Abs(_MoveInp.x) > Mathf.Abs(_MoveInp.y))
        {
            //_Renderer.sprite = _left;

            if (_MoveInp.x > 0)
            {
                //_Anim.SetBool("Kanan", true);
                //transform.rotation = Quaternion.Euler(0, -180, 0);
                _Renderer.sprite = _right;
            }
            else if (_MoveInp.x < 0)
            {
                //_Anim.SetBool("Kiri", true);
                //transform.rotation = Quaternion.Euler(0, 0, 0);
                _Renderer.sprite = _left;
            }
        }
        
        else
        {
            if (_MoveInp.y > 0)
            {
                //_Anim.SetBool("Back", true); 
                _Renderer.sprite= _Back;
            }
            else if (_MoveInp.y < 0)
            {
                //_Anim.SetBool("Idle", true);
                _Renderer.sprite = _Idle;
            }
        }
    }


}
