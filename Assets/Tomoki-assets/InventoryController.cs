using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private UIInventoryPage inventoryUI;
    [SerializeField] private InventorySO inventoryData;

    private void Start()
    {
        PrepareUI();
        PrepareInventoryData();
    }

    private void PrepareInventoryData()
    {
        // データを初期化し、データが更新されたらUIを更新するイベントを紐づける
        inventoryData.Initialize();
        inventoryData.OnInventoryUpdated += UpdateInventoryUI;
    }

    private void PrepareUI()
    {
        // UI側のスロットをデータで指定した数だけ生成する
        inventoryUI.InitializeInventoryUI(inventoryData.Size);
        
        // UIからのイベント（操作）を受け取ったら、Controllerのメソッドを実行するように紐づける
        inventoryUI.OnSwapItems += HandleSwapItems;
        inventoryUI.OnDescriptionRequested += HandleDescriptionRequest;
        inventoryUI.OnStartDragging += HandleDragging;
        inventoryUI.OnItemActionRequested += HandleItemActionRequest;
    }

    // アイテムが入れ替えられたときの処理

    private void HandleSwapItems(int itemIndex1, int itemIndex2)
    {
        inventoryData.SwapItems(itemIndex1, itemIndex2);
    }

    private void HandleDragging(int itemIndex)
    {
        InventoryItem inventoryItem = inventoryData.GetItemAt(itemIndex);
        if (inventoryItem.IsEmpty) return;
        
        // （本来はここでマウスにアイコンを追従させる処理などを呼び出します）
    }

    private void HandleItemActionRequest(int itemIndex)
    {
        // （アイテムを使用する、捨てるなどの処理を今後ここに追加します）
    }

    private void HandleDescriptionRequest(int itemIndex)
    {
        InventoryItem inventoryItem = inventoryData.GetItemAt(itemIndex);
        if (inventoryItem.IsEmpty)
        {
            inventoryUI.ResetSelection();
            return;
        }
        
       
    }

    private void UpdateInventoryUI(Dictionary<int, InventoryItem> inventoryState)
    {
        foreach (var item in inventoryState)
        {
            inventoryUI.UpdateData(item.Key, item.Value.item.ItemImage, item.Value.quantity);
        }
    }

    // 「I」キーを押したときのインベントリ開閉処理
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventoryUI.isActiveAndEnabled == false)
            {
                inventoryUI.Show();
                // 開いたときに現在のデータに合わせてUIを更新
                UpdateInventoryUI(inventoryData.GetCurrentInventoryState());
            }
            else
            {
                inventoryUI.Hide();
            }
        }
    }
}