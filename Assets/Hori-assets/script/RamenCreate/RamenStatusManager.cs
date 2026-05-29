using UnityEngine;
using UnityEngine.UI; // スライダーを操作するために必要です

public class RamenStatusManager : MonoBehaviour
{
    // どこからでもこのマネージャーを呼べるようにする仕組み（シングルトン）
    public static RamenStatusManager Instance { get; private set; }

    [Header("1: ホットバースロットの参照")]
    public foodSlot[] hotbarSlots;

    [Header("それぞれの食材のItemData（ScriptableObject）")]
    public ItemData beafData;
    public ItemData fishData;
    public ItemData vegetableData;

    [Header("2: ステータスUIの参照（Slider）")]
    public Slider saltSlider;      // 「salt」のバー
    public Slider umamiSlider;     // 「uma」のバー
    public Slider spicinessSlider; // 「kara」のバー
    public Slider fatnessSlider;   // 「gilty」のバー
    public Slider mysterySlider;   // 「sinpi」のバー

    [Header("メーターの最大値設定")]
    public float maxBarValue = 100f;

    private void Awake()
    {
        // インスタンスの登録
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // 起動時に一度初期化（すべて0にする）
        CalculateAndApplyStatus();
    }

    /// <summary>
    /// カウントが変わった時に自動で呼び出される計算・反映処理
    /// </summary>
    public void CalculateAndApplyStatus()
    {
        int totalSaltiness = 0;
        int totalUmami = 0;
        int totalSpiciness = 0;
        int totalFatness = 0;
        int totalMystery = 0;

        foreach (foodSlot slot in hotbarSlots)
        {
            if (slot == null) continue;

            ItemData targetData = GetItemDataBySlotType(slot.GetFoodType());
            int slotCount = slot.GetCount();

            if (targetData != null && slotCount > 0)
            {
                totalSaltiness += targetData.saltiness * slotCount;
                totalUmami += targetData.umami * slotCount;
                totalSpiciness += targetData.spiciness * slotCount;
                totalFatness += targetData.fatness * slotCount;
                totalMystery += targetData.mystery * slotCount;
            }
        }

        UpdateSliderValue(saltSlider, totalSaltiness);
        UpdateSliderValue(umamiSlider, totalUmami);
        UpdateSliderValue(spicinessSlider, totalSpiciness);
        UpdateSliderValue(fatnessSlider, totalFatness);
        UpdateSliderValue(mysterySlider, totalMystery);

        Debug.Log($"[UI反映完了] salt:{totalSaltiness}, uma:{totalUmami}, kara:{totalSpiciness}");
    }

    private void UpdateSliderValue(Slider slider, float value)
    {
        if (slider != null)
        {
            slider.maxValue = maxBarValue;
            slider.value = value;
        }
    }

    /// <summary>
    /// スロットの食材タイプに応じて、対応するItemDataを返す (⚠️ここを修正しました)
    /// </summary>
    private ItemData GetItemDataBySlotType(foodSlot.foodType type)
    {
        return type switch
        {
            foodSlot.foodType.Beaf => beafData,
            foodSlot.foodType.Fish => fishData,
            foodSlot.foodType.Vegetable => vegetableData,
            _ => null
        };
    }
}