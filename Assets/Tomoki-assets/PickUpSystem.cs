using UnityEngine;
using Inventory.Model;

public class PickUpSystem : MonoBehaviour
{
    [SerializeField] private InventorySO inventoryData;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 何かの当たり判定に触れた
        Debug.Log("何かにぶつかった！ 相手の名前: " + collision.gameObject.name);

        Item item = collision.GetComponent<Item>();

        if (item != null)
        {
            // Itemスクリプトを持っていた
            Debug.Log("Item");

            int reminder = inventoryData.AddItem(item.InventoryItem, item.Quantity);

            if (reminder == 0)
            {
                //：全部拾えた
                Debug.Log("全部拾えた");
                item.DestroyItem();
            }
            else
            {
                // ：拾いきれなかった
                Debug.Log( + reminder + " 個拾えなかった");
                item.Quantity = reminder;
            }
        }
        else
        {
            // Itemじゃなかった！
            Debug.Log("Item スクリプトが付いてない");
        }
    }
}