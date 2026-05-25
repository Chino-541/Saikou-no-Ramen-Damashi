using System;
using System.Collections.Generic;
using System.Linq; // ← 追加：データ検索（Any）に必要！
using UnityEngine;

namespace Inventory.Model
{
    [CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/Inventory Data")]
    public class InventorySO : ScriptableObject
    {
        [SerializeField] private List<InventoryItem> inventoryItems;

        [field: SerializeField] public int Size { get; private set; } = 10;

        public event Action<Dictionary<int, InventoryItem>> OnInventoryUpdated;

        public void Initialize()
        {
            if (inventoryItems == null)
            {
                inventoryItems = new List<InventoryItem>();
            }

            while (inventoryItems.Count < Size)
            {
                inventoryItems.Add(InventoryItem.GetEmptyItem());
            }
        }

        // =========================================================
        // ▼▼▼ Part 17 で追加：アイテムをリュックにしまう処理 ▼▼▼
        // =========================================================

        public int AddItem(ItemSO item, int quantity)
        {
            // ① スタックできない（1枠に1個の）アイテムの場合
            if (item.IsStackable == false)
            {
                while (quantity > 0 && IsInventoryFull() == false)
                {
                    quantity -= AddItemToFirstFreeSlot(item, 1);
                }
                InformAboutChange();
                return quantity; // リュックがいっぱいで拾えなかった余りの数を返す
            }

            // ② スタックできる（まとめられる）アイテムの場合
            quantity = AddStackableItem(item, quantity);
            InformAboutChange();
            return quantity;
        }

        // 空き枠を探して入れる処理
        private int AddItemToFirstFreeSlot(ItemSO item, int quantity)
        {
            InventoryItem newItem = new InventoryItem
            {
                item = item,
                quantity = quantity
            };

            for (int i = 0; i < inventoryItems.Count; i++)
            {
                if (inventoryItems[i].IsEmpty)
                {
                    inventoryItems[i] = newItem;
                    return quantity;
                }
            }
            return 0;
        }

        // リュックが満杯かどうかを判定する処理
        private bool IsInventoryFull()
            => inventoryItems.Where(item => item.IsEmpty).Any() == false;

        // まとめられるアイテムの計算処理（はみ出した分を次に入れる等）
        private int AddStackableItem(ItemSO item, int quantity)
        {
            for (int i = 0; i < inventoryItems.Count; i++)
            {
                if (inventoryItems[i].IsEmpty)
                    continue;

                // 同じアイテムを見つけたら
                if (inventoryItems[i].item.ID == item.ID)
                {
                    // あと何個まとめられるか計算
                    int amountPossibleToTake = inventoryItems[i].item.MaxStackSize - inventoryItems[i].quantity;

                    if (quantity > amountPossibleToTake)
                    {
                        // 枠の限界まで入れて、残りの数を次に回す
                        inventoryItems[i] = inventoryItems[i].ChangeQuantity(inventoryItems[i].item.MaxStackSize);
                        quantity -= amountPossibleToTake;
                    }
                    else
                    {
                        // 全部まとめられたら終了
                        inventoryItems[i] = inventoryItems[i].ChangeQuantity(inventoryItems[i].quantity + quantity);
                        InformAboutChange();
                        return 0;
                    }
                }
            }
            // 同じアイテムの枠が限界だったら、新しい空き枠に入れる
            while (quantity > 0 && IsInventoryFull() == false)
            {
                int newQuantity = Mathf.Clamp(quantity, 0, item.MaxStackSize);
                quantity -= newQuantity;
                AddItemToFirstFreeSlot(item, newQuantity);
            }
            return quantity;
        }

        // =========================================================
        // ▲▲▲ ここまで追加 ▲▲▲
        // =========================================================


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

        public InventoryItem GetItemAt(int itemIndex)
        {
            return inventoryItems[itemIndex];
        }

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

    [Serializable]
    public struct InventoryItem
    {
        public int quantity;
        public ItemSO item;

        public bool IsEmpty => item == null;

        // ▼ 追記：アイテムの「数だけを変更した新しい状態」を作る機能
        public InventoryItem ChangeQuantity(int newQuantity)
        {
            return new InventoryItem
            {
                item = this.item,
                quantity = newQuantity
            };
        }

        public static InventoryItem GetEmptyItem()
            => new InventoryItem
            {
                item = null,
                quantity = 0
            };
    }
}