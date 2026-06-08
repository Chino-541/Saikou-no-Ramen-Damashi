using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RamenStatusManager : MonoBehaviour
{
    public static RamenStatusManager Instance;

    public Slider saltSlider;
    public Slider umamiSlider;
    public Slider spicySlider;
    public Slider fatSlider;
    public Slider mysterySlider;

    List<ItemData> selectedFoods = new();

    void Awake()
    {
        Instance = this;
    }

    public void AddFood(ItemData item)
    {
        if (selectedFoods.Count >= 3)
            return;

        selectedFoods.Add(item);

        CalculateStatus();
    }

    void CalculateStatus()
    {
        int salt = 0;
        int umami = 0;
        int spicy = 0;
        int fat = 0;
        int mystery = 0;

        foreach (ItemData item in selectedFoods)
        {
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
    }

    public void ClearFoods()
    {
        selectedFoods.Clear();
        CalculateStatus();
    }
}