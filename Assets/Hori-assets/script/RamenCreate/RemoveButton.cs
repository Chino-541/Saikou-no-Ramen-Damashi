using UnityEngine;

public class RemoveButton : MonoBehaviour
{
    public foodSlot[] foodSlots;

    public void OnClickRemove()
    {
        foreach (foodSlot slot in foodSlots)
        {
            ItemData item = slot.GetItem();

            if (item == null)
                continue;

            // スロットを空にする
            slot.Clear();
        }

        // ステータスを再計算
        RamenStatusManager.Instance.CalculateStatus();
    }
}