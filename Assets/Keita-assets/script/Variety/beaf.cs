using UnityEngine;

public class beaf : MonoBehaviour
{
    [SerializeField] Cook cook;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cook = FindAnyObjectByType<Cook>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
                Destroy(gameObject);
                 
                cook.beaf++;
                Debug.Log("‚°‚Á‚¿‚ã");
            }
      

    }
}
