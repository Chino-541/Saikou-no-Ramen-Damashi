using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class ItemSO : ScriptableObject
{
    // アイテムがスタック可能かどうか
    [field: SerializeField] public bool IsStackable { get; set; }

    // アイテムの固有ID
    public int ID => GetInstanceID();

    // 最大スタック数（初期値は1）
    [field: SerializeField] public int MaxStackSize { get; set; } = 1;

    // アイテムの名前
    [field: SerializeField] public string Name { get; set; }

    // アイテムの説明文
    [field: SerializeField]
    [field: TextArea]
    public string Description { get; set; }

    // アイテムのアイコン画像
    [field: SerializeField] public Sprite ItemImage { get; set; }
}