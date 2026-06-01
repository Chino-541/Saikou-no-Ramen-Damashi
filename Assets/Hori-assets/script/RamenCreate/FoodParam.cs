using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodParam : MonoBehaviour
{
    public List<ItemData> cookingItems =
        new List<ItemData>();

    public Slider saltSlider;
    public Slider umamiSlider;
    public Slider karamiSlider;
    public Slider aburaSlider;
    public Slider sinpiSlider;

    public void UpdateParam()
    {
        int salt = 0;
        int umami = 0;
        int karami = 0;
        int abura = 0;
        int sinpi = 0;

        foreach (ItemData item in cookingItems)
        {
            salt += item.saltiness;
            umami += item.umami;
            karami += item.spiciness;
            abura += item.fatness;
            sinpi += item.mystery;
        }

        saltSlider.value = Mathf.Clamp(salt, 0, 100);
        umamiSlider.value = Mathf.Clamp(umami, 0, 100);
        karamiSlider.value = Mathf.Clamp(karami, 0, 100);
        aburaSlider.value = Mathf.Clamp(abura, 0, 100);
        sinpiSlider.value = Mathf.Clamp(sinpi, 0, 100);
    }
}