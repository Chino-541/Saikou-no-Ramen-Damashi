using UnityEngine;

public class FoodData : MonoBehaviour
{
    public int beaf;
    public int fish;
    public int vegetable;

    public int salt;
    public int umami;
    public int spicy;
    public int fat;
    public int mystery;

    public void SetData(int b, int f, int v, int s, int u, int sp, int fa, int m)
    {
        beaf = b;
        fish = f;
        vegetable = v;

        salt = s;
        umami = u;
        spicy = sp;
        fat = fa;
        mystery = m;
    }
}