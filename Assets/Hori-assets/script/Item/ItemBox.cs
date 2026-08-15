using System.Collections;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    [SerializeField] private GameObject NoItemUI;   // アイテムがない場合のUI
    [SerializeField] private GameObject interactUI; // 吹き出しUI

    private bool isPlayerTouching = false; // BOXに触れているかbool

    void Start()
    {
        if (interactUI != null)
            interactUI.SetActive(false);

        if (NoItemUI != null)
            NoItemUI.SetActive(false);
    }

    void Update()
    {
        // Inventoryにアイテムがあるか
        bool hasItems = Inventory.instance != null &&
                        Inventory.instance.GetItems().Count > 0;

        // アイテムを持っていたらUIを表示
        if (interactUI != null)
            interactUI.SetActive(hasItems);

        // Eキー判定
        if (Input.GetKeyDown(KeyCode.E))
        {
            // BOXに触れている時だけ反応
            if (isPlayerTouching)
            {
                // アイテムを持っていたら
                if (hasItems)
                {
                    // アイテム収納
                    Inventory.instance.MoveAllToBox();
                    Debug.Log("アイテム収納！");
                }
                // 持っていない場合
                else
                {
                    // 2秒間表示のコルーチン
                    StartCoroutine(NoItem());
                    Debug.Log("アイテムないです！");
                }
            }
        }
    }

    IEnumerator NoItem()
    {
        NoItemUI.SetActive(true);
        yield return new WaitForSeconds(2f);
        NoItemUI.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            isPlayerTouching = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            isPlayerTouching = false;
    }
}
