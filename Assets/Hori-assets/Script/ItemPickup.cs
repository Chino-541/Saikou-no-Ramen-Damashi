using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public string itemName;
    public int amount = 1;

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Inventory.instance.AddItem(itemName, amount);
            Destroy(gameObject);
        }
    }
}