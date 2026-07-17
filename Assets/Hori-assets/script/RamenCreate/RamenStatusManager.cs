using JetBrains.Annotations;
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

    public int salt;
    public int umami;
    public int spicy;
    public int fat;
    public int mystery;

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

        saltSlider.value = salt;
        umamiSlider.value = umami;
        spicySlider.value = spicy; 
        fatSlider.value = fat;
        mysterySlider.value  = mystery;
    }

    public void ClearFoods()
    {
        foreach (foodSlot slot in foodSlots)
        {
            slot.Clear();
        }

        CalculateStatus();
    }

    public int Salt => (int) saltSlider.value;
    public int Umami => (int)umamiSlider.value;
    public int Spicy => (int)spicySlider.value;
    public int Fat => (int)fatSlider.value;
    public int Mystery => (int)mysterySlider.value;


}