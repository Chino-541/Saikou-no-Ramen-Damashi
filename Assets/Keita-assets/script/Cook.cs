using UnityEngine;

public class Cook : MonoBehaviour
{

    public int a = 10;
    public int b = 5;
    [SerializeField] private GameObject ramen;

    // Update is called once per frame
    void Update()
    {
        Ramen();
    }


    void Ramen()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (a > 0 && b > 0)
            {
                Instantiate(ramen, transform.position, Quaternion.identity);
                a--;
                b--;
            }
            else if (a <= 0 || b <= 0)
            {
                Debug.Log("‘fÞ‚ª‘«‚è‚Ü‚¹‚ñ");
            }

        }
    }
}
