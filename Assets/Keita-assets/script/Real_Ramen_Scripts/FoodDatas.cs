using UnityEngine;

public class FoodData : MonoBehaviour
{
    public int beaf;
    public int fish;
    public int vegetable;

    public void SetData(int b, int f, int v)
    {
        beaf = b;
        fish = f;
        vegetable = v;
    }
}
