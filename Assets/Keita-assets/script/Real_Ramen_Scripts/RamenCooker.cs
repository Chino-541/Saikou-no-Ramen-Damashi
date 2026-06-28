using UnityEngine;

public class RamenCooker : MonoBehaviour
{
    [SerializeField] GameObject Ramen;
    [SerializeField] float cooldownTime = 3f;

    float cooldown = 0f;

    int beaf;
    int fish;
    int veg;
    int salt;
    int noodle;

    void Start()
    {
        beaf = Create.UsedBeaf;
        fish = Create.UsedFish;
        veg = Create.UsedVeg;
        //salt = Create.UsedSalt;
        //noodle = Create.UsedNoodle;
    }

    void Update()
    {
        // ▼ Space を押していないなら何もしない
        if (!Input.GetKeyDown(KeyCode.Space))
            return;

        // ▼ クールダウン中なら何もしない
        if (cooldown > 0)
        {
            Debug.Log("クールダウン中です");
            return;
        }

        // ▼ 素材チェック
        int[] ingredients = { beaf, fish, veg, salt, noodle };

        int ingredientCount = 0;
        foreach (int amount in ingredients)
        {
            if (amount > 0) ingredientCount++;
        }

        if (ingredientCount < 3)
        {
            Debug.Log("5種類のうち3種類以上そろっていません！");
            return;
        }

        // ▼ 作成処理
        int totalSalt = 0;
        int totalUmami = 0;
        int totalSpicy = 0;
        int totalFat = 0;
        int totalMystery = 0;

        foreach (var item in Create.UsedItemDataList)
        {
            totalSalt += item.saltiness;
            totalUmami += item.umami;
            totalSpicy += item.spiciness;
            totalFat += item.fatness;
            totalMystery += item.mystery;
        }

        GameObject obj = Instantiate(Ramen, transform.position, Quaternion.identity);
        FoodData data = obj.GetComponent<FoodData>();

        data.SetData(
            beaf, fish, veg,
            totalSalt, totalUmami, totalSpicy, totalFat, totalMystery
        );

        Debug.Log($"合計味データ: 塩{totalSalt}, 旨味{totalUmami}, 辛さ{totalSpicy}, 脂{totalFat}, 神秘{totalMystery}");

        cooldown = cooldownTime;
    }
}
