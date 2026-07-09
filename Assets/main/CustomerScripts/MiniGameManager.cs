using System.Collections;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    [SerializeField] private GameObject miniGameUI;
    [SerializeField] private float hideTime = 3f;

    public System.Action OnMiniGameEnd;

    void Start()
    {
        miniGameUI.SetActive(false);
    }

    public void MiniGame()
    {
        miniGameUI.SetActive(true);
        StartCoroutine(HideMiniGameUI());
    }

    private IEnumerator HideMiniGameUI()
    {
        yield return new WaitForSeconds(hideTime);

        miniGameUI.SetActive(false);

        // パネルが閉じたタイミングで通知
        OnMiniGameEnd?.Invoke();
    }
}
