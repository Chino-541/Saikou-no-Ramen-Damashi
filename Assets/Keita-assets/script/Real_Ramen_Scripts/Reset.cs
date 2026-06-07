using UnityEngine;

public class Reset : MonoBehaviour
{
    [SerializeField] Cook cook;

    [SerializeField] foodButton[] foodButtons;
    [SerializeField] foodSlot[] foodSlots;

    // Cook の初期値を保存
    int initialBeaf;
    int initialFish;
    int initialVeg;

    void Start()
    {
        cook = FindAnyObjectByType<Cook>();
        initialBeaf = cook.beaf;
        initialFish = cook.fish;
        initialVeg = cook.Vegetable;
    }

    public void ResetAll()
    {
        // Cook の値を初期値に戻す
        cook.beaf = initialBeaf;
        cook.fish = initialFish;
        cook.Vegetable = initialVeg;

        // foodButton の UI とボタン状態を戻す
        foreach (var btn in foodButtons)
        {
            btn.ResetButton();   // ← UI とボタンを元に戻す
        }

        // foodSlot の UI を戻す
        foreach (var slot in foodSlots)
        {
            slot.ResetCount();   // ← スロットの数字を 0 に戻す
        }

        Debug.Log("シーン内の食材・UI を初期状態に戻しました");
    }
}
