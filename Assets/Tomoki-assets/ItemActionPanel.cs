using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // 文字を扱うために追加

namespace Inventory.UI
{
    public class ItemActionPanel : MonoBehaviour
    {
        [SerializeField] private GameObject panel;
        [SerializeField] private Button actionButtonPrefab; // 生成するボタンのプレハブ
        [SerializeField] private Transform buttonContainer; // ボタンを並べる親要素（自分自身）

        public void Awake()
        {
            panel.SetActive(false);
        }

        // メニューの表示・非表示を切り替える
        public void Toggle(bool val)
        {
            if (val == true)
            {
                RemoveOldButtons(); 
            }
            panel.SetActive(val);
        }

        public void SetPosition(Vector2 position)
        {
            panel.transform.position = position;
        }

       
        public void AddButton(string name, Action onClickAction)
        {
            Button button = Instantiate(actionButtonPrefab, buttonContainer);
            button.GetComponentInChildren<TMP_Text>().text = name;
            button.onClick.AddListener(() => onClickAction());
        }

        private void RemoveOldButtons()
        {
            foreach (Transform child in buttonContainer)
            {
                Destroy(child.gameObject);
            }
        }
    }
}