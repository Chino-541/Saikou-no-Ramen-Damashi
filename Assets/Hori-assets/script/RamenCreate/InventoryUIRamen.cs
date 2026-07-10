using UnityEngine;

public class InventoryUIRamen : MonoBehaviour
{
    public Transform content;
    public GameObject slotPrefab;
    public foodSlot[] foodSlots;

    void Start()
    {
        Refresh();

        Storage.instance.onItemChanged += Refresh;
    }

    void OnDestroy()
    {
        if (Storage.instance != null)
            Storage.instance.onItemChanged -= Refresh;
    }

    void Refresh()
    {
        Debug.Log("content = " + content);
        Debug.Log("slotPrefab = " + slotPrefab);
        Debug.Log("Inventory.instance = " + Inventory.instance);
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }

        foreach (var pair in Storage.instance.GetItems())
        {
            ItemData item = pair.Key;

            GameObject obj =
                Instantiate(slotPrefab, content);

            foodButton button =
                obj.GetComponent<foodButton>();

            Debug.Log("button = " + button);

            button.Setup(item, foodSlots);
        }
    }
}