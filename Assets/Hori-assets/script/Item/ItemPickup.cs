using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    public string itemName;
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
            if (Inventory.instance != null)
            {
                Inventory.instance.AddItem(itemName, amount);
                Destroy(gameObject);
            }
        }
    }
    

}