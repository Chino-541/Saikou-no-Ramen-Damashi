using UnityEngine;

public class Cook : MonoBehaviour
{

    public int beaf;
    public int Vegetable;
    public int fish;

   // [SerializeField] private GameObject ramen;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Update is called once per frame
    /*
    void Update()
    {
        Ramen();
    }


    void Ramen()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (beaf > 0 && Vegetable > 0)
            {
                Instantiate(ramen, transform.position, Quaternion.identity);
                beaf--;
                Vegetable--;
            }
            else if (beaf <= 0 || Vegetable <= 0)
            {
                Debug.Log("‘fÞ‚ª‘«‚è‚Ü‚¹‚ñ");
            }

        }
    }
    */
}
