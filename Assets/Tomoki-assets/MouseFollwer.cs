using UnityEngine;
using UnityEngine.InputSystem;

public class MouseFollower : MonoBehaviour
{
    [SerializeField]
    private UIInventoryItem item;
    
    private RectTransform rectTransform;
    private Canvas canvas;

    private void Awake()
    {
        item = GetComponentInChildren<UIInventoryItem>();
        rectTransform = GetComponent<RectTransform>();
        canvas = transform.root.GetComponentInChildren<Canvas>();

       
        if (item != null)
        {
            RectTransform itemRect = item.GetComponent<RectTransform>();
            itemRect.anchoredPosition = Vector2.zero;
        }
    }

    public void SetData(Sprite sprite, int quantity)
    {
        item.SetData(sprite, quantity);
    }

    private void Update()
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)canvas.transform,
            Mouse.current.position.ReadValue(),
            canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : canvas.worldCamera, 
            out Vector2 position
        );
        rectTransform.position = canvas.transform.TransformPoint(position);
    }

    public void Toggle(bool val)
    {
        gameObject.SetActive(val);
    }
}