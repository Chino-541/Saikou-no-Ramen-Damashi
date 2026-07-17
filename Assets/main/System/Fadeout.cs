using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fadeout : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private GameObject panel;
    [SerializeField] private Image panelImage;

    [Header("Fade Settings")]
    [SerializeField] private float fadeSpeed = 0.02f;
    [SerializeField] private float startDelay = 0.5f;

    public bool Started = false;
    public bool IsFinished { get; private set; } = false;

    private void Start()
    {
        panel.SetActive(false);
    }

    private void Update()
    {
        // 外部から Started = true にされたらフェードアウト開始
        if (Started && !IsFinished)
        {
            Started = false;
            StartCoroutine(FadeOutRoutine());
        }
    }

    private IEnumerator FadeOutRoutine()
    {
        panel.SetActive(true);

        yield return new WaitForSecondsRealtime(startDelay);

        Color color = panelImage.color;
        color.a = 0f;
        panelImage.color = color;

        // フェードアウト（透明 → 不透明）
        while (color.a < 1f)
        {
            color.a += fadeSpeed;
            panelImage.color = color;
            yield return null;
        }
        SceneManager.LoadScene("SetsumeiTemplate");
        // 完了フラグ
        IsFinished = true;
    }
}
