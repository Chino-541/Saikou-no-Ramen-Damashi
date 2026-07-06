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
    [SerializeField] private float startDelay = 0.5f;
    [SerializeField] private float textDelay = 0.5f;
    [SerializeField] private float fadeDuration = 1.0f;   // ★ 秒指定フェード

    public bool IsFinished { get; private set; } = false;

    public Player player;   // ★ Player を Inspector でセットする

    private void Start()
    {
        StartCoroutine(StartTutor());
    }

    private IEnumerator StartTutor()
    {
        // ★ フェードイン中はプレイヤーを停止
        player.DisableInput(9999f);

        yield return new WaitForSecondsRealtime(startDelay);

        tmpText.text = displayText;
        yield return new WaitForSecondsRealtime(textDelay);

        // フェード開始
        Color color = startTutorPanelImage.color;
        color.a = 1f;
        startTutorPanelImage.color = color;

        float t = 0f;

        while (t < fadeDuration)
        {
            t += Time.unscaledDeltaTime;

            float normalized = 1f - (t / fadeDuration);
            color.a = normalized;
            startTutorPanelImage.color = color;

            if (color.a < 0.01f)
                tmpText.gameObject.SetActive(false);

            yield return null;
        }

        color.a = 0f;
        startTutorPanelImage.color = color;

        startTutorPanelImage.raycastTarget = false;
        startTutorPanelImage.transform.parent.gameObject.SetActive(false);

        IsFinished = true;

        // ★ フェードイン終了 → プレイヤーを動かせるようにする
        player.DisableInput(0f);
    }
}
