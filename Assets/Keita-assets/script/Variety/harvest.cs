using UnityEngine;

public class harvest : MonoBehaviour
{
    public ItemData item;   // scriptableObj
    [SerializeField] Cook cook;
    private float timer = 0f;

    private AudioSource VAudio;   // ← Inspector でセットしない

    void Start()
    {
        cook = FindAnyObjectByType<Cook>();
        timer = 0f;

        // AudioSource を自動取得（Prefabでも確実に拾える）
        VAudio = GetComponent<AudioSource>();
        if (VAudio == null)
        {
            Debug.LogWarning("AudioSource が見つかりませんでした");
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            if (timer >= 8f)
            {
                bool success = Inventory.instance.AddItem(item, 1);

                if (success)
                {
                    cook.Vegetable++;

                    // 音を鳴らす（Prefabでも確実に鳴る）
                    if (VAudio != null)
                        VAudio.Play();

                    // VegetableのHarvestを呼ぶ
                    GetComponent<Vegetable>()?.Harvest();

                    timer = 0f;
                    Debug.Log("採取して Inventory に追加しました");
                }
            }
            else
            {
                Debug.Log("早すぎ待ちなさい");
            }
        }
    }
}
