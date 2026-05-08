using UnityEngine;
using UnityEngine.Tilemaps;

public class harvest : MonoBehaviour
{
    [SerializeField] private GameObject Vegetable;
    [SerializeField] private AnimatedTile animatedTile;
    [SerializeField] private Tilemap tilemap;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
       if(collision.gameObject.CompareTag("Player") && Input.GetKey(KeyCode. F))
        {
            Destroy(gameObject);
            Vector3Int cellPos = tilemap.WorldToCell(transform.position);
            tilemap.SetTile(cellPos, animatedTile);
            Debug.Log("byebye");
        }
    }
}
