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

        Debug.Log($"【RamenStatus】salt={salt}, umami={umami}, spicy={spicy}, fat={fat}, mystery={mystery}");

        int max = Mathf.Max(salt, umami, spicy, fat, mystery);

        Debug.Log($"【RamenStatus】max={max}");

        if (max == 0)
        {
            Debug.Log("何もなし");
        }
        else if (max == salt)
        {
            player.SetMoveSpeed(7f);
            Debug.Log("playerのスピードが上がった");
        }
        else if (max == umami)
        {
            Customer.SetCustomerCount(10);
            Debug.Log("お客さんの出現数が増加した");
        }
        else if (max == spicy)
        {
            Score.scoreMultiplier = 1.5f;
            Debug.Log("スコア倍率が1.5倍になった");
        }
        else if (max == fat)
        {
            track.SetTimer(15f);
            Debug.Log("トラックの頻度が低くなった");
        }
        else if (max == mystery)
        {
            player.isMystery = true;
            Debug.Log("バリアが使えるようになった");
        }
    }
}
