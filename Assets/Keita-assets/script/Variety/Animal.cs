using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

using UnityEngine.UIElements;

public class Animal : MonoBehaviour
{
    public Transform player;

    // 体力関係
    public int EnemyHp = 2;
    int CurrentHp;

    // 速さ関係
    public float Speed = 1f;
    public float dash = 3f;
    float CurrentSpeed;

    // ランダム移動関係
    public float chargeTime = 3f;
    private float timeCount;

    // 
    private Vector2 direction;
    private SpriteRenderer Sr;
    private Rigidbody2D rb2;

    public GameObject item;

    // 逃げる時用のbool
    bool isEscape = false; 

    void Start()
    {
        // プレイヤーを取得
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Sr = GetComponent<SpriteRenderer>();
        rb2 = GetComponent<Rigidbody2D>();

        CurrentSpeed = Speed;
        CurrentHp = EnemyHp;

        // ランダムな方向を設定
        float angle = Random.Range(0f, 360f);
        direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad),
                                Mathf.Sin(angle * Mathf.Deg2Rad));
    }

    void Update()
    {
        if (!isEscape)
        {
            // 体力が１以外の時ランダム移動
            timeCount += Time.deltaTime;
            transform.position += (Vector3)(direction * CurrentSpeed * Time.deltaTime);

            if (timeCount > chargeTime)
            {
                float angle = Random.Range(0f, 360f);
                direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad),
                                        Mathf.Sin(angle * Mathf.Deg2Rad));
                timeCount = 0;
            }
        }
        else
        {
            
            Escape();
        }
    }

    public void Hp()
    {
        if (CurrentHp == 1)
        {
            CurrentSpeed = dash;
            isEscape = true; // 逃走開始
            Debug.Log("ピンチ");
        }
        else if (CurrentHp <= 0)
        {
            Destroy(gameObject);
            Instantiate(item, transform.position, Quaternion.identity);
            Debug.Log("uwaaa");
        }
    }
    // ダメージ処理
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Attack"))
        {
            CurrentHp--;        // 先に減らす
            Hp();               // 減った後の値で判定
            StartCoroutine(Damage());
        }
    }

    // ダメージ演出
    IEnumerator Damage()
    {
        Sr.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        Sr.color = Color.white;
    }

    // 逃げる処理
    void Escape()
    {
        if (player == null) return;

        // プレイヤーから離れる方向
        Vector2 Es = (transform.position - player.position).normalized;

        transform.position += (Vector3)(Es * CurrentSpeed * Time.deltaTime);
    }
}
