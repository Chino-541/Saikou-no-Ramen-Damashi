using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Fadein : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private GameObject mainTutorPanel;
    [SerializeField] private TextMeshProUGUI tmpText;
    [SerializeField] private string displayText;
    [SerializeField] private Image startTutorPanelImage;

    [Header("Fade Settings")]
    [SerializeField] private float fadeSpeed = 0.002f;
    [SerializeField] private float startDelay = 0.5f;
    [SerializeField] private float textDelay = 0.5f;

    public bool IsFinished { get; private set; } = false;

    private void Start()
    {
        StartCoroutine(StartTutor());
    }

    private IEnumerator StartTutor()
    {
        // 最初の待機
        yield return new WaitForSecondsRealtime(startDelay);

        // テキスト表示
        tmpText.text = displayText;
        yield return new WaitForSecondsRealtime(textDelay);

        // フェード開始
        Color color = startTutorPanelImage.color;
        color.a = 1f;

        while (color.a > 0f)
        {
            color.a -= fadeSpeed;
            startTutorPanelImage.color = color;

            // テキストを途中で消す
            if (color.a < 0.01f)
                tmpText.gameObject.SetActive(false);

            // 0.3 以下になったら UI ブロック解除
            if (color.a < 0.3f)
                break;

            yield return null;
        }

        // UI ブロック解除
        startTutorPanelImage.raycastTarget = false;

        // 親ごと非表示
        startTutorPanelImage.transform.parent.gameObject.SetActive(false);

        IsFinished = true;
    }
}
