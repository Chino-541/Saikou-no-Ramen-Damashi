using UnityEngine;

public class RamenData : MonoBehaviour
{
    public static RamenData Instance;

    public int salt;
    public int umami;
    public int spicy;
    public int fat;
    public int mystery;

    public int ramenCount;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        
    }
}
