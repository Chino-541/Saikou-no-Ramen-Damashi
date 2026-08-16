using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<Player>().SpeedUp(7f);
            Destroy(gameObject);
        }
    }
}
