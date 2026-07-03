using UnityEngine;


public class beaf : MonoBehaviour
{
    public ItemData item; // scriptableObj
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
            // Inventory に追加（UI も更新される）
            bool success = Inventory.instance.AddItem(item, 1);
            Destroy(gameObject);
                 
                cook.beaf++;
                Debug.Log("げっちゅ");
            }
      

    }
}
