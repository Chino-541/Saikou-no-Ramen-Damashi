using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float Speed = 1.0f;
    public float chargeTime = 3f;
    private float timeCount;

    public float chaseRange = 5f; // ‹ŠE‚Ì”ÍˆÍ
    private Transform player;

    private Vector2 direction; // ƒ‰ƒ“ƒ_ƒ€ˆÚ“®‚Ì•ûŒü

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Å‰‚Ì•ûŒü
        float angle = Random.Range(0f, 360f);
        direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad),
                                Mathf.Sin(angle * Mathf.Deg2Rad));
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        // ’ÇÕ
        if (distance < chaseRange)
        {
            Vector2 playerPos = player.position;

            transform.position = Vector2.MoveTowards(
                transform.position,
                playerPos,
                Speed * Time.deltaTime
            );

            return; 
        }

        // ƒ‰ƒ“ƒ_ƒ€ˆÚ“®
        timeCount += Time.deltaTime;

        transform.position += (Vector3)(direction * Speed * Time.deltaTime);

        if (timeCount > chargeTime)
        {
            float angle = Random.Range(0f, 360f);
            direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad),
                                    Mathf.Sin(angle * Mathf.Deg2Rad));

            timeCount = 0;
        }
    }
}