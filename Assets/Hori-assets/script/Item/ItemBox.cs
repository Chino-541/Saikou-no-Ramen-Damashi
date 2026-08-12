using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public Transform player;
    public float interactRange = 2f;

    public GameObject interactUI; // 近づいたら出るUI

    private bool isPlayerTouching = false;

    void Start()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        if (obj != null)
        {
            player = obj.transform;
        }

        if (interactUI != null)
        {
            interactUI.SetActive(false); 
        }
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        // UI の表示条件：接触していて、距離が近い
        bool canShowUI = isPlayerTouching && distance < interactRange;

        if (interactUI != null)
        {
            interactUI.SetActive(canShowUI);
        }

        // Eキーでアイテム回収
        if (canShowUI && Input.GetKeyDown(KeyCode.E))
        {
            if (Inventory.instance != null)
            {
                Inventory.instance.MoveAllToBox();
                Debug.Log("アイテムを回収しました！");
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerTouching = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerTouching = false;

            if (interactUI != null)
            {
                interactUI.SetActive(false); // 離れたら消す
            }
        }
    }
}
