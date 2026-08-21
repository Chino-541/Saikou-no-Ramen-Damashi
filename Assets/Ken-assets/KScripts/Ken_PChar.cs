using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class Ken_PChar : MonoBehaviour
{
    [SerializeField] private GameObject RamenFace;
    [SerializeField] private Vector2 _MoveInp;
    [SerializeField] Rigidbody2D _Rb;
    [SerializeField] private SpriteRenderer sr;

    // ★ Animator
    [SerializeField] private Animator anim;

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

    // mysteryが一番高い場合
    public bool isMystery = false;
    private bool canUseBarrier = true;
    [SerializeField] private GameObject barrier;
    [SerializeField] private float barrierCooldown = 15f;
    [SerializeField] private float barrierTime = 2f;


    private void Awake()
    {
        barrier.SetActive(false);
        RamenFace.SetActive(false);

        _Rb = GetComponent<Rigidbody2D>();

        // ★ Animatorを取得
        if (anim == null)
        {
            anim = GetComponent<Animator>();
        }

        // 最初は下向き
        anim.SetBool("down", true);
    }


    void Update()
    {
        if (canMove)
        {
            _Rb.linearVelocity = _MoveInp * _MoveSpeed;

            // ★ 移動方向に応じてアニメーション変更
            UpdateDirectionAnimation();
        }
        else
        {
            _Rb.linearVelocity = Vector2.zero;

            // 動けないときは方向アニメーションを止める
            ResetDirectionAnimation();
        }


        if (isMystery && Input.GetKeyDown(KeyCode.Space))
        {
            TryUseBarrier();
        }

        // バリアをプレイヤーに追従させる
        if (barrier.activeSelf)
            barrier.transform.position = transform.position;
    }


    // =========================
    // 移動入力
    // =========================

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


    // =========================
    // 上下左右アニメーション
    // =========================

    private void UpdateDirectionAnimation()
    {
        // 入力がない場合は何もしない
        // → 最後の方向を維持
        if (_MoveInp == Vector2.zero)
        {
            return;
        }

        // 一度全部OFF
        ResetDirectionAnimation();

        // 横方向を優先
        if (_MoveInp.x > 0)
        {
            anim.SetBool("right", true);
            sr.flipX = false;
        }
        else if (_MoveInp.x < 0)
        {
            anim.SetBool("left", true);
            sr.flipX = true;
        }
        else if (_MoveInp.y > 0)
        {
            anim.SetBool("up", true);
        }
        else if (_MoveInp.y < 0)
        {
            anim.SetBool("down", true);
        }
    }


    // =========================
    // 方向アニメーションOFF
    // =========================

    private void ResetDirectionAnimation()
    {
        anim.SetBool("up", false);
        anim.SetBool("down", false);
        anim.SetBool("left", false);
        anim.SetBool("right", false);
    }


    // =========================
    // 停止
    // =========================

    public void DisableInput(float seconds)
    {
        StartCoroutine(DisableInputCoroutine(seconds));
    }


    private IEnumerator DisableInputCoroutine(float seconds)
    {
        canMove = false;
        _MoveInp = Vector2.zero;

        yield return new WaitForSeconds(seconds);

        canMove = true;
    }


    // =========================
    // ボーナスタイム
    // =========================

    public IEnumerator BonusTime()
    {
        RamenFace.SetActive(true);
        isBonusTime = true;
        Debug.Log("ボーナス中");

        // 元の色を保存
        defaultColor = sr.color;

        float timer = 0f;

        while (timer < bonusTimer)
        {
            Score.Soldpoint = 0;
            Score.UpdateUI();

            // 虹色（Hue を回す）
            float hue = Mathf.Repeat(Time.time * 0.5f, 1f);
            Color rainbow = Color.HSVToRGB(hue, 1f, 1f);

            // 透明度を徐々に下げる（1 → 0）
            float alpha = Mathf.Lerp(1f, 0f, timer / bonusTimer);

            rainbow.a = alpha;

            sr.color = rainbow;

            timer += Time.deltaTime;
            yield return null;
        }

        // 元の色に戻す
        sr.color = defaultColor;
        RamenFace.SetActive(false);

        Debug.Log("ボーナス終わり");

        isBonusTime = false;
        Score.Soldpoint = 5;
        Score.UpdateUI();
    }


    // =========================
    // Speedを外部から変更する
    // =========================

    public void SetMoveSpeed(float speed)
    {
        _MoveSpeed = speed;
    }


    // =========================
    // バリア
    // =========================

    private void TryUseBarrier()
    {
        if (!canUseBarrier)
            return;

        StartCoroutine(BarrierRoutine());
    }


    private IEnumerator BarrierRoutine()
    {
        canUseBarrier = false;

        // バリアを出す
        barrier.SetActive(true);
        Debug.Log("バリア発動");

        // バリアが出ている時間
        yield return new WaitForSeconds(barrierTime);

        // バリアを消す
        barrier.SetActive(false);
        Debug.Log("バリア終了");

        // クールダウン
        yield return new WaitForSeconds(barrierCooldown);

        canUseBarrier = true;
        Debug.Log("バリア再使用可能");
    }
}