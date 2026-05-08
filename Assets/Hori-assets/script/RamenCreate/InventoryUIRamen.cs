using System.Collections.Generic;
using UnityEngine;

public class InventoryUIRamen : MonoBehaviour
{
    public GameObject slotPrefab;
    public Transform content;

    public List<Sprite> testSprites;

    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject slot = Instantiate(slotPrefab, content);

            SlotUI ui = slot.GetComponent<SlotUI>();

            if (i < testSprites.Count)
            {
                ui.SetItem(testSprites[i], Random.Range(1, 99));
            }
        }
    }
}