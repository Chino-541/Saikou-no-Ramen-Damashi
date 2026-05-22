using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/Inventory Data")]
public class InventorySO : ScriptableObject
{
    // インベントリの中身のリスト（インスペクターで初期アイテムを設定可能）
    [SerializeField] private List<InventoryItem> inventoryItems;
    
    // インベントリの最大枠数
    [field: SerializeField] public int Size { get; private set; } = 10;

   
    public event Action<Dictionary<int, InventoryItem>> OnInventoryUpdated;

    // ゲーム開始時にインベントリを初期化する
    public void Initialize()
    {
        inventoryItems = new List<InventoryItem>();
        for (int i = 0; i < Size; i++)
        {
            inventoryItems.Add(InventoryItem.GetEmptyItem());
        }
    }

    // 現在のインベントリの状態を取得する
    public Dictionary<int, InventoryItem> GetCurrentInventoryState()
    {
        Dictionary<int, InventoryItem> returnValue = new Dictionary<int, InventoryItem>();
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].IsEmpty) continue;
            returnValue[i] = inventoryItems[i];
        }
        return returnValue;
    }

    // 特定のスロットにあるアイテムを取得する
    public InventoryItem GetItemAt(int itemIndex)
    {
        return inventoryItems[itemIndex];
    }

    // アイテムの入れ替え
    public void SwapItems(int itemIndex1, int itemIndex2)
    {
        InventoryItem item1 = inventoryItems[itemIndex1];
        inventoryItems[itemIndex1] = inventoryItems[itemIndex2];
        inventoryItems[itemIndex2] = item1;

       
        InformAboutChange();
    }

    
    private void InformAboutChange()
    {
        OnInventoryUpdated?.Invoke(GetCurrentInventoryState());
    }
}

// インベントリの1スロット分のデータを表す
[Serializable]
public struct InventoryItem
{
    public int quantity; // 所持数
    public ItemSO item;  // アイテムのデータ

    // スロットが空かどうかを判定
    public bool IsEmpty => item == null;

    // 空のスロットを作成して返す
    public static InventoryItem GetEmptyItem()
        => new InventoryItem
        {
            item = null,
            quantity = 0
        };
}