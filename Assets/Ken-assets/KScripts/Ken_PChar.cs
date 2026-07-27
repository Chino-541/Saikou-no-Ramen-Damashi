using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class Ken_PChar : MonoBehaviour
{
    [SerializeField] private Vector2 _MoveInp;
    [SerializeField] Rigidbody2D _Rb;
    [SerializeField] private SpriteRenderer sr;
    // 元の色
    private Color defaultColor;
    // 速さ
    [SerializeField] float _MoveSpeed = 5f;
    // score参照
    [SerializeField] private PlayerScore Score;
    // 移動に関するbool
    public bool canMove = true;
    // ボーナス中
    public bool isBonusTime = false;
    [SerializeField] private int bonusTimer;
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
            _Rb.linearVelocity = Vector2.zero; // 停止
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
        canMove = false; // 停止開始
        yield return new WaitForSeconds(seconds);
        canMove = true;  // ←停止解除
    }

    public IEnumerator BonusTime()
    {
        isBonusTime = true;

        // 元の色を保存
        defaultColor = sr.color;

        float timer = 0f;

        while (timer < bonusTimer)
        {
            // 0〜1の範囲で色相を回す
            float hue = Mathf.Repeat(Time.time * 0.5f, 1f);
            sr.color = Color.HSVToRGB(hue, 1f, 1f);

            timer += Time.deltaTime;
            yield return null;
        }

        // ボーナス終わり
        sr.color = Color.white;

        isBonusTime = false;
        Score.Soldpoint = 0;
    }

}
