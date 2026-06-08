using UnityEngine;


public class harvest : MonoBehaviour
{
    public ItemData item;
    [SerializeField] Cook cook;
    private float timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // cookがアタッチされているオブジェクトを探す
        cook = FindAnyObjectByType<Cook>();
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
                // Vegetable の Harvest() を呼ぶ
                GetComponent<Vegetable>()?.Harvest();

                cook.Vegetable++;
                timer = 0f;

                Debug.Log("採取");
            }
            else
            {
                Debug.Log("早すぎ待ちなさい");
            }
        }
    }

}