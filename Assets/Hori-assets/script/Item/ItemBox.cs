using UnityEngine;
using HoriAssets; // ←念のためこれも追加しておきます

public class ItemBox : MonoBehaviour
{
    public Transform player;
    public float interactRange = 2f;

    void Start()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        if (obj != null)
        {
            this.player = obj.transform;
        }
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance < interactRange && Input.GetKeyDown(KeyCode.E))
        {
            // 変更点1：頭に「HoriAssets.」をつける
            if (HoriAssets.Inventory.instance != null)
            {
                // 変更点2：頭に「HoriAssets.」をつける
                HoriAssets.Inventory.instance.MoveAllToBox();
            }
            else
            {
                Debug.LogError("Inventory.instance が null");
            }
        }
    }
}