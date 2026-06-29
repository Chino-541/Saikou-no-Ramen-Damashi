using UnityEngine;
using TMPro;

public class foodSlot : MonoBehaviour
{
<<<<<<< HEAD
    public enum foodType
    {
        Beaf,
        Fish,
        Vegetable
=======
    [SerializeField] Image iconImage;

    ItemData currentItem;


    public bool IsEmpty()
    {
        return currentItem == null;
    }

    public void SetItem(ItemData item)
    {
        currentItem = item;

        iconImage.sprite = item.icon;
        iconImage.color = Color.white;
>>>>>>> hori
    }

    [SerializeField] foodType food;
    [SerializeField] TMP_Text countText;

    int count = 0;

    public void AddCount()
    {
        count++;
        countText.text = count.ToString();
    }

<<<<<<< HEAD
    public int Minus()
    {
        if (count <= 0)
        {
            Debug.Log(GetNoItemMessage());
            return 0;
        }

        int used = count;
        count = 0;
        countText.text = "0";

        return used;
    }

    string GetNoItemMessage()
    {
        return food switch
        {
            foodType.Beaf => "お肉がありません",
            foodType.Fish => "魚がありません",
            foodType.Vegetable => "野菜がありません",
            _ => "アイテムがありません"
        };
    }
    public int GetCount()
    {
        return count;
    }

    // Reset 用
    public void ResetCount()
    {
        count = 0;
        countText.text = "0";
    }
}
=======
    public void Clear()
    {
        currentItem = null;

        iconImage.sprite = null;
        iconImage.color = new Color(1, 1, 1, 0);
    }

}
>>>>>>> hori
