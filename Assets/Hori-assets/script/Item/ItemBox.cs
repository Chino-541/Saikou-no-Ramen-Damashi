using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public Transform player;
    public float interactRange = 2f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if (player = null) return;
        float distance = Vector2.Distance(transform.position, player.position);
        {
            Inventory.instance.MoveAllToBox();
        }
        if (distance < interactRange && Input.GetKeyDown(KeyCode.E))
        {
            if (Inventory.instance != null)
            {
                Inventory.instance.MoveAllToBox();
            }
        }

    }
}