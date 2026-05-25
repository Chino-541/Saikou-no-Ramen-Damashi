using UnityEngine;
using Inventory.Model; 

public class Item : MonoBehaviour
{
    // 何のアイテムか
    [field: SerializeField] public ItemSO InventoryItem { get; private set; }

    // 何個落ちているか
    [field: SerializeField] public int Quantity { get; set; } = 1;

    private void Start()
    {
        
        GetComponent<SpriteRenderer>().sprite = InventoryItem.ItemImage;
    }

    // アイテムを拾いきった時にフィールドから消す処理
    public void DestroyItem()
    {
        Destroy(gameObject);
    }
}