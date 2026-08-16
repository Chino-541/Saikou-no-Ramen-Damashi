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
        if(isMystery && Input.GetKeyDown(KeyCode.Space))
        {
            TryUseBarrier();
        }
        // バリアをプレイヤーに追従させる
        if (barrier.activeSelf)
            barrier.transform.position = transform.position;
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
    // 停止に関する関数
    public void DisableInput(float seconds)
    {
        StartCoroutine(DisableInputCoroutine(seconds));
    }
    // 停止に関するコルーチン
    private IEnumerator DisableInputCoroutine(float seconds)
    {
        canMove = false; // 停止開始
        yield return new WaitForSeconds(seconds);
        canMove = true;  // ←停止解除
    }
    // ボーナスタイム中の処理
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

        // ボーナス終わり → 元の色に戻す
        sr.color = defaultColor;
        RamenFace.SetActive(false);
        Debug.Log("ボーナス終わり");

        isBonusTime = false;
        Score.Soldpoint = 5;
        Score.UpdateUI();
    }


    // Speedを外部から変更する
    public void SetMoveSpeed(float speed)
    {
        _MoveSpeed = speed;
    }

    // mysteryが一番高い場合の処理
    // バリア発動処理
    private void TryUseBarrier()
    {
        if (!canUseBarrier) return;
        StartCoroutine(BarrierRoutine());
    }

    // バリアのコルーチン
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

        // クールダウン（15秒）
        yield return new WaitForSeconds(barrierCooldown);

        canUseBarrier = true;
        Debug.Log("バリア再使用可能");
    }
}
