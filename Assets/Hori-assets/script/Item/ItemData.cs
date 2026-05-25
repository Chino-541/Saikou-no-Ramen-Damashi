using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Item/Create Item")]
public class ItemData : ScriptableObject
{
    [Header("基本情報")]
    // アイテムの名前
    public string itemName;
    // アイテムのアイコン
    public Sprite icon;

    [TextArea]
    public string description;
    // 最大所持数
    public int maxStack = 99;

    [Header("味ステータス")]
    [Range(0f,100f)]
    public int saltiness ; // 塩分
    [Range(0f, 100f)]
    public int umami; // 旨味
    [Range(0f, 100f)]
    public int spiciness; // 辛さ
    [Range(0f, 100f)]
    public int fatness; // 肉脂
    [Range(0f, 100f)]
    public int mystery; // 神秘
}