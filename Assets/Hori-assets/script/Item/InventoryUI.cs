using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Transform content;
    public GameObject itemPrefab;

    void Start()
    {
        Inventory.instance.onItemChanged += UpdateUI;
        UpdateUI();
    }

    void UpdateUI()
    {
        // ëSçÌèú
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }

        // çƒê∂ê¨
        foreach (var item in Inventory.instance.GetItems())
        {
            GameObject obj = Instantiate(itemPrefab, content);

            obj.GetComponentInChildren<Text>().text =
                item.Key + " x" + item.Value;
        }
    }
}