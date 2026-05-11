using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class harvest : MonoBehaviour
{
    //[SerializeField] private GameObject Vegetable;
    // [SerializeField] private AnimatedTile animatedTile;
    // [SerializeField] private Tilemap tilemap;
    // [SerializeField] private GameObject Prefab;

    private float timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

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
                // ¶¬ˆÊ’u‚ğ•Û‘¶
                //Vector3 spawnPos = transform.position;

                // ©•ª‚ğíœ
                Destroy(gameObject);

                // •Û‘¶‚µ‚½ˆÊ’u‚É¶¬
                //Instantiate(Vegetable, spawnPos, Quaternion.identity);
                timer = 0f;
                Debug.Log("Ìæ");
            }
            else
            {
                Debug.Log("‘‚·‚¬‘Ò‚¿‚È‚³‚¢");
            }
        }

    }
    
}