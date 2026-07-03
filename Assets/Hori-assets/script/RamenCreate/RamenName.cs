using UnityEngine;
using UnityEngine.UI; 
using TMPro; 

public class RamenName : MonoBehaviour
{
    // ステータスの種類を識別するための列挙型
    public enum StatType
    {
        Salt,   // 塩分
        Umami,  // 旨味
        Spicy,  // 辛さ
        Fat,    // 肉脂
        Mystery // 神秘
    }

    // ソート処理用の構造体
    private struct StatValue
    {
        public StatType Type;
        public int Value;

        public StatValue(StatType type, int value)
        {
            Type = type;
            Value = value;
        }
    }

    private readonly string[,] primaryNames = new string[5, 4] {
        { "潮", "淡雪", "濃月", "破雷" },          // 塩分 ①
        { "極み", "奥義", "深淵", "至高" },        // 旨味 ①
        { "紅蓮", "爆炎", "灼熱", "爆激辛" },      // 辛さ ①
        { "背脂", "濃厚", "重厚", "まろみ" },      // 肉脂 ①
        { "天啓", "幻影", "秘境", "神撃" }         // 神秘 ①
    };

    private readonly string[,] secondaryNames = new string[5, 4] {
        { "塩華", "破風", "海王", "熟韻" },        // 塩分 ②
        { "ごく旨", "旨雫", "琥珀", "味極" },      // 旨味 ②
        { "烈火", "赤牙", "雷辛", "暴辛" },        // 辛さ ②
        { "背徳", "こってり", "濃密", "超マシマシ" },// 肉脂 ②
        { "黒龍", "深淵", "星詠み", "異界" }       // 神秘 ②
    };

    [Header("名前を表示するUIテキスト（任意設定）")]
    // TextMeshProを使用する場合は下記を使用してください
    public TMP_Text resultText;

    /// <summary>
    /// 保存されているRamenStatusDataから名前を生成し、UIを更新して文字列を返します。
    /// </summary>
    public void UpdateRamenName()
    {
        // 各ステータスを配列にまとめる
        StatValue[] stats = new StatValue[]
        {
            new StatValue(StatType.Salt, RamenStatusData.salt),
            new StatValue(StatType.Umami, RamenStatusData.umami),
            new StatValue(StatType.Spicy, RamenStatusData.spicy),
            new StatValue(StatType.Fat, RamenStatusData.fat),
            new StatValue(StatType.Mystery, RamenStatusData.mystery)
        };

        //  単純なバブルソートで降順（大きい順）に並び替え

        for (int i = 0; i < stats.Length - 1; i++)
        {
            for (int j = i + 1; j < stats.Length; j++)
            {
                if (stats[j].Value > stats[i].Value)
                {
                    StatValue temp = stats[i];
                    stats[i] = stats[j];
                    stats[j] = temp;
                }
            }
        }

        //  1位（①）と2位（②）のデータを取得
        StatValue topStat = stats[0];
        StatValue secondStat = stats[1];

        //  数値から段階インデックス（0〜3）を取得
        int topTier = GetTierIndex(topStat.Value);
        int secondTier = GetTierIndex(secondStat.Value);

        // 文字列を組み立てる
        string part1 = primaryNames[(int)topStat.Type, topTier];
        string part2 = secondaryNames[(int)secondStat.Type, secondTier];
        string finalName = $"{part1}{part2}ラーメン";

        //  UIテキストがインスペクターで設定されていれば反映
        if (resultText != null)
        {
            resultText.text = finalName;
        }

     
    }

    private int GetTierIndex(int value)
    {
        if (value <= 10) return 0;  // 1: 0~10
        if (value <= 40) return 1;  // 2: 11~40
        if (value <= 70) return 2;  // 3: 41~70
        return 3;                   // 4: 71~100
    }
}
