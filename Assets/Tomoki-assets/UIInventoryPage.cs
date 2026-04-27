using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class UIInventoryPage : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    [SerializeField]
    private UIInvantoryItem itemPrefab;

    [SerializeField]
    private RectTransform contentpanel;


    List<UIInvantoryItem> listOfUIItem = new List<UIInvantoryItem>();

    public void InitializeInventoryUI(int inventorysize)
    {
        for (int i = 0; i < inventorysize; i++)
        {
            UIInvantoryItem uiItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            uiItem.transform.SetParent(contentpanel);
            listOfUIItem.Add(uiItem);
        }


    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
    
