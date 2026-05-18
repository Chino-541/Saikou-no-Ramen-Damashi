using UnityEngine;

public class Ra_men : MonoBehaviour
{
    int beaf = 0;
    int chicken = 0;
    int pork = 0;
    int Vegitable = 0;
    int fish = 0;
    [SerializeField] Cook cook;


    void Start()
    {
        cook = FindAnyObjectByType<Cook>();
    }
    void Update()
    {
       
    }
    void Noraml()
    {
        if (beaf == 1 && chicken == 1 && pork == 1 && Vegitable == 1 && fish == 1)
        {

        }
        else
        {

        }
    }
}
