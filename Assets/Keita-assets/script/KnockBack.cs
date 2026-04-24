using UnityEngine;

public class KnockBack : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Attack"))
        {
            // プレイヤーをノックバックさせる
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            Vector2 knockbackDirection = (transform.position - collision.transform.position).normalized;
            float knockbackForce = 5.0f; // ノックバックの強さを調整
            rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
        }
    }
}
