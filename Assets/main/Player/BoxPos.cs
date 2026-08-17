using UnityEngine;
using UnityEngine.UI;

public class BoxPos : MonoBehaviour
{
    // 場所を知りたいオブジェクト
    [Header("Target")]
    [SerializeField] private Transform target;
    // 使うカメラ
    [Header("Camera")]
    [SerializeField] private Camera targetCamera;
    // 矢印の画面端からの距離
    [Header("Settings")]
    [SerializeField] private float screenMargin = 80f;
    // UIの位置操作
    private RectTransform arrowRect;
    // 矢印
    private Image arrowImage;
    // canvasの位置
    private RectTransform canvasRect;

    private void Start()
    {
        arrowRect = GetComponent<RectTransform>();
        arrowImage = GetComponent<Image>();

        Canvas canvas = GetComponentInParent<Canvas>();
        canvasRect = canvas.GetComponent<RectTransform>();
    }

    private void Update()
    {
        // inspectorに設定していないと何も起こらない
        if (target == null || targetCamera == null)
        {
            return;
        }

        // 
        Vector3 screenPos =
            targetCamera.WorldToScreenPoint(target.position);

        // Targetがカメラの後ろにいるか
        bool behindCamera = screenPos.z < 0;

        // Targetが画面内にいるか判定
        bool onScreen =
            // boolのbehindCameraを満たしていなくて
            !behindCamera &&
            // 画面左端よりも右側で
            screenPos.x >= 0 &&
            // 画面右側よりも左側で
            screenPos.x <= Screen.width &&
            // 画面下側よりも上側で
            screenPos.y >= 0 &&
            // 画面上側よりも下側
            screenPos.y <= Screen.height;

        // 画面内なら矢印を消す
        // 画像を非表示にするのでenabled
        arrowImage.enabled = !onScreen;

        // 表示ならreturnで返す
        if (onScreen)
        {
            return;
        }
            
        // カメラからTargetへの方向
        // Targetの位置-カメラの位置
        Vector3 direction =
            target.position - targetCamera.transform.position;

        // Targetがカメラの後ろにいる場合
        // 無理やり方向を-にして画面に映るようにしている
        // カメラより後ろにいるなら書く必要なし
        if (behindCamera)
        {
            direction = - direction;
        }

        // カメラから見てどれくらい右なのか
        // カメラ基準の方向に変換
        float x = Vector3.Dot(
            direction,
            targetCamera.transform.right
        );

        // カメラから見てどれくらい上なのか
        float y = Vector3.Dot(
            direction,
            targetCamera.transform.up
        );
        // 元3Dの方向を2Dにしている
        Vector2 direction2D = new Vector2(x, y).normalized;

        // 画面中央の計算
        Vector2 screenCenter =
            new Vector2(Screen.width, Screen.height) * 0.5f;

        // 画面端から少し内側にする
        float maxX = Screen.width * 0.5f - screenMargin;
        float maxY = Screen.height * 0.5f - screenMargin;

        // ここからよくわからない--------------------------------

        // 画面中央からTarget方向へ
        float scaleX = maxX / Mathf.Abs(direction2D.x);
        float scaleY = maxY / Mathf.Abs(direction2D.y);

        // 画面から出ない位置を選んでる？
        float scale = Mathf.Min(scaleX, scaleY);

        // 画面中央からTargetの方向の画面端への位置
        Vector2 arrowScreenPos =
            screenCenter + direction2D * scale;

        // Canvasのローカル座標に変換
        Vector2 localPos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvasRect,
            arrowScreenPos,
            targetCamera,
            out localPos
        );

        arrowRect.anchoredPosition = localPos;

        // 矢印をTarget方向に回転
        float angle =
            Mathf.Atan2(direction2D.y, direction2D.x) *
            Mathf.Rad2Deg;

        arrowRect.rotation =
            Quaternion.Euler(0, 0, angle - 90f);
    }
}