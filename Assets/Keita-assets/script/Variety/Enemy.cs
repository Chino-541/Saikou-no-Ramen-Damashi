using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField] private float Speed = 2.0f;
    public float CurrentSpeed;
    [SerializeField] private float Dash = 8.0f;
    [SerializeField] private int KnockBackpower = 5;
    [SerializeField] private int EnemyHP;

    [SerializeField] private Transform player;
    [SerializeField] private Cook cook;

    private bool isStopped = false; // ← 当たった後に動きを止めるフラグ

    void Start()
    {
        CurrentSpeed = Speed;
    }

    void Update()
    {
        HP();

        {
            Attack();
        }

    }

    // プレイヤー追跡
    void Attack()
    {
        float Distance = Vector2.Distance(transform.position, player.position);

        if (Distance < 5f)
        {
            Vector2 dir = (player.position - transform.position).normalized;
            transform.position += (Vector3)(dir * CurrentSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // ランダムで素材を減らす
            int r = Random.Range(0, 3);
            if (r == 0) cook.beaf--;
            if (r == 1) cook.fish--;
            if (r == 2) cook.Vegetable--;

            // ノックバック処理
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                // プレイヤー → アニマル の逆方向に吹き飛ばす
                Vector2 direction = (collision.transform.position - transform.position).normalized;

                rb.AddForce(direction * KnockBackpower, ForceMode2D.Impulse);
            }
        }
    }



    // HP処理
    void HP()
    {
        if (EnemyHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
