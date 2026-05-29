using UnityEngine;

public class RamenCooker : MonoBehaviour
{
    [SerializeField] GameObject Ramen;

    // Start で読み込んだ値を保持する
    int beaf;
    int fish;
    int veg;

    void Start()
    {
        // Create で保存されたデータを取得
        beaf = Create.UsedBeaf;
        fish = Create.UsedFish;
        veg = Create.UsedVeg;
    }

    void Update()
    {
        if (beaf == 0 || fish == 0 || veg == 0)
        {
            Debug.Log("材料が足りません！生成できません");
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ラーメンを生成
            GameObject obj = Instantiate(Ramen, transform.position, Quaternion.identity);

            // FoodData をセット
            FoodData data = obj.GetComponent<FoodData>();
            data.SetData(beaf, fish, veg);

            Debug.Log($"生成された Ramen: 肉{data.beaf}, 魚{data.fish}, 野菜{data.vegetable}");
            // 作ったら値を減らす
            veg--;
            beaf--;
            fish--;
        }
    }
}
