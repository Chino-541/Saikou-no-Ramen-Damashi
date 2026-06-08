using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Create : MonoBehaviour
{
    // 次のシーンに渡すデータ
    public static int UsedBeaf;
    public static int UsedFish;
    public static int UsedVeg;

    public static List<ItemData> UsedItemDataList = new List<ItemData>();

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
        // スロットの Minus() で消費量を取得
        UsedBeaf = Bef.Minus();
        UsedFish = Fis.Minus();
        UsedVeg = Veg.Minus();

        // 次のシーンへ移動
        SceneManager.LoadScene("Map02");
    }
}

/*
Debug.Log("今回消費したお肉: " + befUsed);
        Debug.Log("今回消費した野菜: " + vegUsed);
        Debug.Log("今回消費した魚: " + fisUsed);

        // 合計
        int total = befUsed + vegUsed + fisUsed;
        Debug.Log("消費合計: " +  total);

        Total += total;
        Debug.Log("累計消費量: " + Total);

        // 消費量別の処理
        if (befUsed == vegUsed && vegUsed == fisUsed)
        {
            Debug.Log("OK");
        }
        else if(total >= 1)
        {
            Debug.Log("Okよ");
        }
        else if(total <= 0)
        {
            Debug.Log("無し");
        }
        Total = total;
    }
   

}*/
