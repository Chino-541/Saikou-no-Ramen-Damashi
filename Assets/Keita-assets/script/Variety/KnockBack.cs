using UnityEngine;

public class KnockBack : MonoBehaviour
{
    [SerializeField] private Transform Animal;
    [SerializeField] private Transform Player;
    public float knockbackForce = 5.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
