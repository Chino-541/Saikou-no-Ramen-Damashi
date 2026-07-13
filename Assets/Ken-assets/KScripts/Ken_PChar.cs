using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Ken_PChar : MonoBehaviour
{
    [SerializeField] private Vector2 _MoveInp;
    [SerializeField] Rigidbody2D _Rb;
    [SerializeField] float _MoveSpeed = 5f;

    private bool canMove = true; 

    private void Awake()
    {
        _Rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (canMove)
        {
            _Rb.linearVelocity = _MoveInp * _MoveSpeed;
        }
        else
        {
            _Rb.linearVelocity = Vector2.zero; // í‚é~
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (canMove)
        {
            _MoveInp = context.ReadValue<Vector2>();
        }
        else
        {
            _MoveInp = Vector2.zero;
        }
    }

    public void DisableInput(float seconds)
    {
        StartCoroutine(DisableInputCoroutine(seconds));
    }

    private IEnumerator DisableInputCoroutine(float seconds)
    {
        canMove = false; // í‚é~äJén
        yield return new WaitForSeconds(seconds);
        canMove = true;  // Å©í‚é~âèú
    }
}
