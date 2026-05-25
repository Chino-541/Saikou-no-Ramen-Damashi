using UnityEngine;
using UnityEngine.UI;

public class Create : MonoBehaviour
{
    static int Total;
    [SerializeField] SlotBef Bef;
    [SerializeField] SlotVeg Veg;
    [SerializeField] SlotFis Fis;

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickButton);
    }

    void OnClickButton()
    {
        // それぞれのMinusから値をとる
        int befUsed = Bef.Minus();
        int vegUsed = Veg.Minus();
        int fisUsed = Fis.Minus();

        Debug.Log("今回消費したお肉: " + befUsed);
        Debug.Log("今回消費した野菜: " + vegUsed);
        Debug.Log("今回消費した魚: " + fisUsed);

        // 合計
        int total = befUsed + vegUsed + fisUsed;
        Debug.Log("消費合計: " +  total);


        // 消費量別の処理
        if (befUsed == vegUsed && vegUsed == fisUsed)
        {
            Debug.Log("程よいバランス");
        }
        else if (total >= 15)
        {
            Debug.Log("めっちゃ集めたね");
        }
        else if(total >= 3)
        {
            Debug.Log("並み");
        }
        else if(total <= 0)
        {
            Debug.Log("無し");
        }
        Total = total;
    }
   

}
