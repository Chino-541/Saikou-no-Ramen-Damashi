using UnityEngine;
using UnityEngine.UI;

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
        //　UIの表示
        if (pickupUI != null)
        {
            pickupUI.SetActive(distance < pickupRange);
        }
        //　アイテムを拾う
        if (distance < pickupRange &&Input.GetKeyDown(KeyCode.E))
        {
            bool success = false;
            if (Inventory.instance != null)
            {
                success = Inventory.instance.AddItem(itemData, amount);
            }
            if(success)
            {
                Destroy(gameObject);
            }
        }
    }
    

}