using UnityEngine;
using UnityEngine.InputSystem;

public class Ken_GChar : MonoBehaviour
{
    [Header("Nyanスクリプトへようこそ")]
    [SerializeField] private Vector2 _MoveInp;
    [SerializeField] Rigidbody2D _Rb;
    [SerializeField] float _MoveSpeed = 5f;

    private void Awake()
    {
        _Rb = GetComponent<Rigidbody2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _Rb.linearVelocity = _MoveInp * _MoveSpeed;
    }
    public void Move(InputAction.CallbackContext context)
    {
        _MoveInp = context.ReadValue<Vector2>();
    }

}
