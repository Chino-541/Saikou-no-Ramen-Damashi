using UnityEngine;
using UnityEngine.UI;
// 変更点1：YourNamespace を HoriAssets に変更
using HoriAssets;

public class ItemPickup : MonoBehaviour
{
    public ItemData itemData;
    public int amount = 1;

    public Transform player;
    public float pickupRange = 2f;

    public GameObject pickupUI;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

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