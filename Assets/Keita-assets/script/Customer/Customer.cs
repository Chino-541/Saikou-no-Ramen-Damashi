using UnityEngine;

public class Customer : MonoBehaviour
{
    private int score;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("ramen"))
        {
            score++;
            Destroy(gameObject);

        }
    }
}
