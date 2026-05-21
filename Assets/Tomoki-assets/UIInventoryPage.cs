using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class UIInventoryPage : MonoBehaviour
{
    [SerializeField]
    private UIInventoryItem itemPrefab;
    [SerializeField]
    private RectTransform contentpanel;
    [SerializeField]
    private UIInventoryDescription itemDescription;
    [SerializeField]
    private MouseFollower mouseFollower;

    List<UIInventoryItem> listOfUIItem = new List<UIInventoryItem>();

    public Sprite image;
    public int quantity;
    public string title;
    public string description;

    private int currentlyDraggedItemIndex = -1; 

    private void Awake()
    {
        Hide();
        mouseFollower.Toggle(false); 
        itemDescription.ResetDescription();
    }

    public void InitializeInventoryUI(int inventorysize)
    {
        foreach (var item in listOfUIItem)
        {
            Destroy(item.gameObject);
        }
        listOfUIItem.Clear();

        for (int i = 0; i < inventorysize; i++)
        {
            UIInventoryItem uiItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            uiItem.transform.SetParent(contentpanel);
            uiItem.transform.localScale = Vector3.one; 
            uiItem.transform.localPosition = Vector3.zero;

            listOfUIItem.Add(uiItem);
            
            uiItem.OnItemClicked += HandleItemSelection;
            uiItem.OnItemBeginDrag += HandleBeginDrag;
            uiItem.OnItemDroppedOn += HandleSwap;
            uiItem.OnItemEndDrag += HandleEndDrag;
            uiItem.OnRightItemMouseBtnClick += HandleShowItemActions; 
        }

        if (inventorysize > 0 && image != null)
        {
            listOfUIItem[0].SetData(image, quantity);
        }
    }

    private void HandleItemSelection(UIInventoryItem item)
    {
        Debug.Log("アイテムクリック: " + item.name); 
        itemDescription.SetDescription(image, title, description);
        
        foreach (var inventoryItem in listOfUIItem)
        {
            inventoryItem.Deselect();
        }
        item.Select();
    }

    private void HandleBeginDrag(UIInventoryItem item)
    {
        int index = listOfUIItem.IndexOf(item);
        if (index == -1) return;

        currentlyDraggedItemIndex = index;

        mouseFollower.Toggle(true);
        mouseFollower.SetData(image, quantity); 
    }

    private void HandleSwap(UIInventoryItem item)
    {
    }

    private void HandleEndDrag(UIInventoryItem item)
    {
        mouseFollower.Toggle(false);
        currentlyDraggedItemIndex = -1;
    }

    private void HandleShowItemActions(UIInventoryItem item)
    {
    }

    public void Show()
    {
        InitializeInventoryUI(5); 
        gameObject.SetActive(true);
        itemDescription.ResetDescription(); 
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}