using UnityEngine;

public class harvest : MonoBehaviour
{
    public ItemData item;   // ← これが野菜の画像やデータ
    [SerializeField] Cook cook;
    private float timer = 0f;

    void Start()
    {
        cook = FindAnyObjectByType<Cook>();
        timer = 0f;
    }

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
                // Inventory に追加（UI も更新される）
                bool success = Inventory.instance.AddItem(item, 1);

                if (success)
                {
                    // Vegetable カウントも増やすならここ
                    cook.Vegetable++;

                    // Vegetable の Harvest() を呼ぶ
                    GetComponent<Vegetable>()?.Harvest();

                    timer = 0f;
                    Debug.Log("採取して Inventory に追加しました");
                }
            }
            else
            {
                Debug.Log("早すぎ待ちなさい");
            }
        }
    }
}
