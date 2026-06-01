using Unity.VisualScripting;
using UnityEngine;

public class RamenCooker : MonoBehaviour
{
    [SerializeField] GameObject Ramen;
    [SerializeField] float cooldownTime = 3f;
    float cooldown = 0f;
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
        // クールダウン
        if (cooldown > 0)
        {
            Debug.Log("クールダウン中");
            cooldown -= Time.deltaTime;
            return;
        }

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

            /*
            // 作ったら値を減らす
            veg--;
            beaf--;
            fish--;
            */

            // クールダウン
            cooldown = cooldownTime;
            Debug.Log("クールダウン3秒");
        }
    }
}
