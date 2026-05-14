using UnityEngine;


public class harvest : MonoBehaviour
{
    private float timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            if (timer >= 8f)
            {
                Destroy(gameObject);
                // ©•ª‚ğíœ
                Destroy(gameObject);

                timer = 0f;
                Debug.Log("Ìæ");
            }
            else
            {
                Debug.Log("‘‚·‚¬‘Ò‚¿‚È‚³‚¢");
            }
        }

    }
    
}