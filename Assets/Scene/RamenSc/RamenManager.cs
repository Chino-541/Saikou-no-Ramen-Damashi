using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class RamenManager : MonoBehaviour
{
    // ステータスに応じて効果が出るもの
    [SerializeField] private Ken_PChar player;
    [SerializeField] private CustomerSpawner Customer;
    [SerializeField] private PlayerScore Score;
    [SerializeField] private TrackSpawn track;
    // [SerializeField] private 
    void Start()
    {
        int salt = RamenStatusData.salt;
        int umami = RamenStatusData.umami;
        int spicy = RamenStatusData.spicy;
        int fat = RamenStatusData.fat;
        int mystery = RamenStatusData.mystery;

        // 一番高いステータスを判定
        int max = Mathf.Max(salt, umami, spicy, fat, mystery);

        // 何もない場合
        if (max == 0)
        {
            Debug.Log("何もなし");
            return;
        }
        // 塩分が一番の場合スピードが上がる
        else if (max == salt)
        {
            player.SetMoveSpeed(7f);
            Debug.Log("playerのスピードが上がった");
        }

        // 旨味が一番の場合お客さんが画面に出る数が高まる
       else if (max == umami)
        {
            Customer.SetCustomerCount(10);
            Debug.Log("お客さんの出現数が増加した");
        }

        // 辛味が一番の場合一回のスコアが高まる
        else if(max == spicy)
        {
            // 1回のスコアが1.5倍になる
            Score.scoreMultiplier = 1.5f;
            Debug.Log("スコア倍率が1.5倍になった");
        }

        // 脂が一番の場合トラックの出現率が低くなる
        else if(max == fat)
        {
            track.SetTimer(15f);
            Debug.Log("トラックの頻度が低くなった");
        }

        // 謎が一番の場合
        else if(max == mystery) 
        {
            player.isMystery = true;
            Debug.Log("バリアが使えるようになった");
        }
    }
}
