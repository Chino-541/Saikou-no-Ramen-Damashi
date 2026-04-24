using Unity.VisualScripting;
using UnityEngine;

public class Animal : MonoBehaviour
{
    // 体力
    public int EnemyHp = 2;
    int CurrentHp;
    // 速さ
    public float Speed = 1f;
    public float dash = 3f;
    float CurrentSpeed;
    // 方向が切り替わる時間
    public float chargeTime = 3f;
    private float timeCount;
    // 視界の範囲
    public float chaseRange = 5f;
    // prayerを格納
    private Transform player;
    // ランダム移動の方向
    private Vector2 direction;
    private Rigidbody2D rb2;
    public GameObject item;
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        // 速さの定義？
        CurrentSpeed = Speed;
        // 体力の定義？
        CurrentHp = EnemyHp;
        // Playerタグのオブジェクトを探す
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // 最初の方向
        float angle = Random.Range(0f, 360f);
        direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad),
                                Mathf.Sin(angle * Mathf.Deg2Rad));
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        // 追跡
        if (distance < chaseRange)
        {
            Vector2 playerPos = player.position;

            transform.position = Vector2.MoveTowards(
                transform.position,
                playerPos,
                CurrentSpeed * Time.deltaTime
            );
            return;
        }

        // ランダム移動
        timeCount += Time.deltaTime;

        transform.position += (Vector3)(direction * CurrentSpeed * Time.deltaTime);

        if (timeCount > chargeTime)
        {
            float angle = Random.Range(0f, 360f);
            direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad),
                                    Mathf.Sin(angle * Mathf.Deg2Rad));

            timeCount = 0;
        }
        Hp();
    }
    void Hp()
    {
        if (CurrentHp == 1)
        {
            CurrentSpeed = dash;     
            Debug.Log("ピンチ");
        }
        else if (CurrentHp < 0)
        {
            Destroy(gameObject);
            Instantiate(item, transform.position, Quaternion.identity);
            Debug.Log("uwaaa");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Attack"))
        {
            CurrentHp--;
        }
    }
}

