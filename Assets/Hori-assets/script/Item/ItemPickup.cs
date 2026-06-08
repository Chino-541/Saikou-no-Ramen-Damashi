using UnityEngine;
using UnityEngine.UI;
<<<<<<< HEAD
// 変更点1：YourNamespace を HoriAssets に変更
using HoriAssets;
=======
>>>>>>> main

public class ItemPickup : MonoBehaviour
{
    public ItemData itemData;
    public int amount = 1;

    public Transform player;
    public float pickupRange = 2f;

    public GameObject pickupUI;

<<<<<<< HEAD
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
=======
    private float timer = 0f;              // ← 最初は0秒（拾えない）
    public float pickupCooldown = 8f;      // 8秒クールタイム

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Vegetable タグ以外はクールタイムなし
        if (!CompareTag("Vegetable"))
        {
            timer = pickupCooldown; // すぐ拾える
        }
>>>>>>> main
    }

    void Update()
    {
        if (player == null) return;

<<<<<<< HEAD
        float distance = Vector2.Distance(transform.position, player.position);

        // UIの表示
        if (pickupUI != null)
        {
            pickupUI.SetActive(distance < pickupRange);
        }

        // アイテムを拾う
        if (distance < pickupRange && Input.GetKeyDown(KeyCode.E))
        {
            bool success = false;

            // 変更点2：頭に「HoriAssets.」をつける
            if (HoriAssets.Inventory.instance != null)
            {
                // 変更点3：頭に「HoriAssets.」をつける
                success = HoriAssets.Inventory.instance.AddItem(itemData, amount);
            }

            if (success)
            {
                Destroy(gameObject);
            }
        }
    }
}
=======
        timer += Time.deltaTime;

        float distance = Vector2.Distance(transform.position, player.position);

        bool canPickup;

        if (CompareTag("Vegetable"))
        {
            // Vegetable は 8 秒経たないと拾えない
            canPickup = (distance < pickupRange) && (timer >= pickupCooldown);
        }
        else
        {
            // それ以外は距離だけで拾える
            canPickup = (distance < pickupRange);
        }

        // UI 表示
        if (pickupUI != null)
        {
            pickupUI.SetActive(canPickup);
        }

        // 拾う処理
        if (canPickup && Input.GetKeyDown(KeyCode.E))
        {
            if (Inventory.instance != null)
            {
                bool success = Inventory.instance.AddItem(itemData, amount);

                if (success)
                {
                    if (CompareTag("Vegetable"))
                    {
                        timer = 0f; // Vegetable だけクールタイム開始
                    }

                    Debug.Log($"{itemData.name} を拾った");
                }
            }
        }
    }
}
>>>>>>> main
