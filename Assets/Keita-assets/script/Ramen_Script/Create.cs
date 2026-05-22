using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Create : MonoBehaviour
{
    // スロットの数
    [SerializeField] SlotBef Bef;
    [SerializeField] SlotVeg Veg;
    [SerializeField] SlotFis Fis;
    /*
    // それを表示させるUI
    [SerializeField] TMP_Text BefText;
    [SerializeField] TMP_Text VegText;
    [SerializeField] TMP_Text FisText;
    // 押すボタン
    */
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickButton);
    }
    void OnClickButton()
    {
        {
            Bef.Minus();
            Veg.Minus();
            Fis.Minus();
        }
        /*
        // ボタン押したら数が減るお肉
        if (Bef.BeCount > 0)
        {
            Bef.BeCount--;
            UpdateBefText();
        }
        // お肉ない場合
        else if (Bef.BeCount == 0)
        {
            Debug.Log("お肉");
        }
        // 野菜数ヘル
        if (Veg.VeCount > 0)
        {
            Veg.VeCount--;
            UpdateVegText();
        }
        // 野菜がない場合
        else if (Veg.VeCount == 0)
        {
            Debug.Log("野菜");
        }
        // 魚が減る
        if (Fis.FiCount > 0)
        {
            Fis.FiCount--;
            UpdateFisText();
        }
        // 魚がない
        else if (Fis.FiCount == 0)
        {
            Debug.Log("魚");
        }
    }
    void UpdateBefText()
    {
        // お肉の数UI
        BefText.text = Bef.BeCount.ToString();
    }
    void UpdateVegText()
    {
        // 野菜の数UI
        VegText.text = Veg.VeCount.ToString();
    }
    void UpdateFisText()
    {
        // 魚の数UI
        FisText.text = Fis.FiCount.ToString();
    }
        */
    }
}
