using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public bool playerNear = false;

    void Update()
    {
        if (playerNear && Input.GetMouseButtonDown(0))
        {
            Inventory.instance.MoveAllToBox();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = false;
        }
    }
}