using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Item/Create Item")]
public class ItemData : ScriptableObject
{
    [Header("基本情報")]
    public string itemName;

    public Sprite icon;

    [TextArea]
    public string description;

    public int maxStack = 99;

    [Header("味ステータス")]
    public int saltiness; // 塩分

    public int umami; // 旨味

    public int spiciness; // 辛さ

    public int fatness; // 肉脂

    public int mystery; // 神秘
}