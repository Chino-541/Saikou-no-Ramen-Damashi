using UnityEngine;
using HoriAssets;

public class ItemBox : MonoBehaviour
{
    public Transform player;
    public float interactRange = 2f;

    void Start()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        if (obj != null)
        {
            player = obj.transform;
        }
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance < interactRange && Input.GetKeyDown(KeyCode.E))
        {
            if (HoriAssets.Inventory.instance != null)
            {
                HoriAssets.Inventory.instance.MoveAllToBox();
            }
            else
            {
                Debug.LogError("Inventory.instance ‚ª null");
            }
        }
    }
}