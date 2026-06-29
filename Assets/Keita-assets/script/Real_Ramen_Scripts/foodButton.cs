using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class foodButton : MonoBehaviour
{
<<<<<<< HEAD
    public enum foodType { Beaf, Fish, Vegetable }

    [SerializeField] private ItemData itemData;
    [SerializeField] foodType food;

    [SerializeField] Cook cook;
    [SerializeField] Image centerSlot;
    [SerializeField] Image myImage;
=======
    [SerializeField] ItemData itemData;
    [SerializeField] foodSlot[] slots;
>>>>>>> hori
    [SerializeField] TMP_Text countText;
    [SerializeField] Image iconImage;

    [SerializeField] SlotBef slotBef;
    [SerializeField] SlotFis slotFis;
    [SerializeField] SlotVeg slotVeg;

    [SerializeField] private Slider[] sliders = new Slider[5];

    Button button;

    void Start()
    {
        cook = FindAnyObjectByType<Cook>();
        button = GetComponent<Button>();
<<<<<<< HEAD
        button.onClick.AddListener(OnClickfoodButton);
=======
        button.onClick.AddListener(OnClickFoodButton);

        UpdateCountText();
    }
    public void Setup(ItemData item, foodSlot[] targetSlots)
    {
        itemData = item;
        slots = targetSlots;

        iconImage.sprite = item.icon;

>>>>>>> hori
        UpdateCountText();
    }

    void OnClickFoodButton()
    {
        if (GetCount() <= 0)
            return;

<<<<<<< HEAD
        button.interactable = false;

        centerSlot.sprite = myImage.sprite;
        centerSlot.color = Color.white;

        DecreaseCount();
        UpdateCountText();

        switch (food)
        {
            case foodType.Beaf: slotBef.BefCount(); break;
            case foodType.Fish: slotFis.FisCount(); break;
            case foodType.Vegetable: slotVeg.VegCount(); break;
=======
        // ìØÇ∂ëfçﬁÇ™ä˘Ç…ì¸Ç¡ÇƒÇ¢ÇÈÇ©ämîF
        foreach (foodSlot slot in slots)
        {
            if (slot.GetItem() == itemData)
            {
                Debug.Log("Ç±ÇÃëfçﬁÇÕä˘Ç…égópÇµÇƒÇ¢Ç‹Ç∑");
                return;
            }
        }

        // ãÛÇ¢ÇƒÇ¢ÇÈògÇíTÇ∑
        foreach (foodSlot slot in slots)
        {
            if (slot.IsEmpty())
            {
                slot.SetItem(itemData);

                Inventory.instance.RemoveItem(itemData, 1);

                RamenStatusManager.Instance.CalculateStatus();

                UpdateCountText();

                break;
            }
>>>>>>> hori
        }

        sliders[0].value += itemData.saltiness;
        sliders[1].value += itemData.umami;
        sliders[2].value += itemData.spiciness;
        sliders[3].value += itemData.fatness;
        sliders[4].value += itemData.mystery;

        // Åö ScriptableObject ÇÉäÉXÉgÇ…í«â¡
        Create.UsedItemDataList.Add(itemData);
    }

    void UpdateCountText()
    {
        countText.text = GetCount().ToString();
    }

    int GetCount()
    {
<<<<<<< HEAD
        return food switch
        {
            foodType.Beaf => cook.beaf,
            foodType.Fish => cook.fish,
            foodType.Vegetable => cook.Vegetable,
            _ => 0
        };
=======
        return Storage.instance.GetItemCount(itemData);
>>>>>>> hori
    }

    void DecreaseCount()
    {
        switch (food)
        {
            case foodType.Beaf: cook.beaf--; break;
            case foodType.Fish: cook.fish--; break;
            case foodType.Vegetable: cook.Vegetable--; break;
        }
    }

    public void ResetButton()
    {
        button.interactable = true;

        UpdateCountText();
        centerSlot.sprite = null;
        centerSlot.color = new Color(1, 1, 1, 0);

        for (int i = 0; i < sliders.Length; i++)
        {
            sliders[i].value = 0;
        }
        Create.UsedItemDataList.Clear();
    }
}
