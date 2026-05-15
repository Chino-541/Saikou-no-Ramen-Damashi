using UnityEngine;


public class harvest : MonoBehaviour
{
    [SerializeField] Cook cook;
    private float timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // cookがアタッチされているオブジェクトを探す
        cook = FindAnyObjectByType<Cook>();
        timer = 0f;
    }

    // Update is called once per frame
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
                // 自分を削除
                Destroy(gameObject);
                // timerの初期化
                timer = 0f;
                Debug.Log("採取");
                // cookのbを増やす
                cook.b++;
                Debug.Log("野菜げっちゅ");
            }
            else
            {
                Debug.Log("早すぎ待ちなさい");
            }
        }

    }
    
}