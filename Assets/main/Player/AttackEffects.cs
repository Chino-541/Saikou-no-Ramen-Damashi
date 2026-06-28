using UnityEngine;

public class AttackEffect : MonoBehaviour
{
    [SerializeField] private AudioSource hitsounds;
    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Animal"))
        {
            hitsounds.Play();
            Debug.Log("‚ ‚½‚½");
        }
    }

}
