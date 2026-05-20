using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Item/Create Item")]
public class ItemData : ScriptableObject
{
    public string itemName;

    public Sprite icon;

    [TextArea]
    public string description;

    public int maxStack = 99;
}