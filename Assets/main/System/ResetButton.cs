using UnityEngine;

public class ResetData : MonoBehaviour
{
    public PlayerScore playerScore;
    // 削除
    public void ResetDatas()
    {
       if(Storage.instance != null)
        {
            Storage.instance.Clearitems();
        }
        Debug.Log("アイテム削除");

        if(playerScore != null)
        {
            playerScore.ResetScore();
        }
            else
            {
                // シーン内に無いので直接リセット
                ScoreData.point = 0;
                ScoreData.score = 0;
                FoodScoreData.score = 0;
            }
        Debug.Log("スコア削除");
    }
}
