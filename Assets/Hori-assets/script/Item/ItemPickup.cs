using UnityEngine;
using UnityEngine.UI;
using HoriAssets;

public class ItemPickup : MonoBehaviour
{
    public ItemData itemData;
    public int amount = 1;

    public Transform player;
    public float pickupRange = 2f;

    public GameObject pickupUI;

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
    }

    void Update()
    {
        if (player == null) return;

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
            if (HoriAssets.Inventory.instance != null)
            {
                bool success = HoriAssets.Inventory.instance.AddItem(itemData, amount);

                if (success)
                {
                    if (CompareTag("Vegetable"))
                    {
                        timer = 0f; // Vegetable だけクールタイム開始
                    }

                    Debug.Log($"{itemData.name} を拾った");
                    Destroy(gameObject);
                }
            }
        }
    }
}
