using UnityEngine;

public class RamenCooker : MonoBehaviour
{
    [SerializeField] GameObject Ramen;
    [SerializeField] float cooldownTime = 3f;

    float cooldown = 0f;

    int beaf;
    int fish;
    int veg;

    void Start()
    {
        beaf = Create.UsedBeaf;
        fish = Create.UsedFish;
        veg = Create.UsedVeg;
    }

    void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
            return;
        }

        if (beaf == 0 || fish == 0 || veg == 0)
        {
            Debug.Log("材料が足りません！");
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //  味の合計を計算
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
}
