using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateButton : MonoBehaviour
{
    [SerializeField] private string nextSceneName;
    public void OnClickCreate()
    {
        int makeCount = int.MaxValue;

        // 作れる量を計算
        foreach (foodSlot slot in RamenStatusManager.Instance.foodSlots)
        {
            ItemData item = slot.GetItem();

            if (item == null) 
                continue;

            int count = Storage.instance.GetItemCount(item);

            if (count < makeCount)
                makeCount = count;
        }

        // ラーメンのステータスを保持
        RamenData.Instance.salt = RamenStatusManager.Instance.salt;
        RamenData.Instance.umami = RamenStatusManager.Instance.umami;
        RamenData.Instance.spicy = RamenStatusManager.Instance.spicy;
        RamenData.Instance.fat = RamenStatusManager.Instance.fat;
        RamenData.Instance.mystery = RamenStatusManager.Instance.mystery;
        Debug.Log("ステータスを保存しました");

        // 作成したラーメンの数を保存
        RamenData.Instance.ramenCount = makeCount;

        foreach (foodSlot slot in RamenStatusManager.Instance.foodSlots)
        {
            ItemData item = slot.GetItem();

            if (item == null)
                continue;

            Storage.instance.RemoveItem(item, makeCount);
        }

        // スロットを空にする
        RamenStatusManager.Instance.ClearFoods();


        // シーンを移動
        SceneManager.LoadScene(nextSceneName);
    }

}
