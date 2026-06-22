using UnityEngine;

public class Doubutu　: MonoBehaviour
{
    public int hp = 10;
    public GameObject itemPrefab; // ドロップさせたいアイテムのPrefab
    [Range(0, 100)]
    public float dropChance = 50f; // ドロップ率（0〜100%）

    // ダメージ
    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // 確率判定
        float randomValue = Random.Range(0f, 100f);
        if (randomValue <= dropChance)
        {
            // アイテムを生成
            Instantiate(itemPrefab, transform.position, Quaternion.identity);
        }

        // 敵自身を消去
        Destroy(gameObject);
    }
}
