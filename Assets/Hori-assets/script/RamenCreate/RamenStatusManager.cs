using UnityEngine;
using UnityEngine.UI;

public class RamenStatusManager : MonoBehaviour
{
    public static RamenStatusManager Instance;

    [Header("投入枠")]
    public foodSlot[] foodSlots;

    [Header("ステータス")]
    public Slider saltSlider;
    public Slider umamiSlider;
    public Slider spicySlider;
    public Slider fatSlider;
    public Slider mysterySlider;

    void Awake()
    {
        Instance = this;
    }

    public void CalculateStatus()
    {
        int salt = 0;
        int umami = 0;
        int spicy = 0;
        int fat = 0;
        int mystery = 0;

        foreach (foodSlot slot in foodSlots)
        {
            ItemData item = slot.GetItem();
            if (item == null)
                continue;

            salt += item.saltiness;
            umami += item.umami;
            spicy += item.spiciness;
            fat += item.fatness;
            mystery += item.mystery;
        }

        saltSlider.value = Mathf.Clamp(salt, 0, 100);
        umamiSlider.value = Mathf.Clamp(umami, 0, 100);
        spicySlider.value = Mathf.Clamp(spicy, 0, 100);
        fatSlider.value = Mathf.Clamp(fat, 0, 100);
        mysterySlider.value = Mathf.Clamp(mystery, 0, 100);

        // ステータスを保存（次のシーンで使う）
        RamenStatusData.salt = salt;
        RamenStatusData.umami = umami;
        RamenStatusData.spicy = spicy;
        RamenStatusData.fat = fat;
        RamenStatusData.mystery = mystery;

        RamenStatusData.total = salt + umami + spicy + fat + mystery;
    }
}
