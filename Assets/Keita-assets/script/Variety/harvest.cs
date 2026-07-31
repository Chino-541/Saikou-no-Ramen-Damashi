using UnityEngine;

public class harvest : MonoBehaviour
{
    public ItemData item;
    [SerializeField] Cook cook;
    private float timer = 0f;

    public AudioSource VAudio;

    void Start()
    {
        cook = FindAnyObjectByType<Cook>();
        timer = 0f;

        // 名前で AudioSource を探す（Hierarchy 内）
        GameObject audioObj = GameObject.Find("harvest");
        if (audioObj != null)
        {
            VAudio = audioObj.GetComponent<AudioSource>();
        }

        if (VAudio == null)
        {
            Debug.LogWarning("AudioSource 'harvest' が見つかりませんでした");
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

                    // 名前で取得した AudioSource を鳴らす
                    if (VAudio != null)
                        VAudio.Play();

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
