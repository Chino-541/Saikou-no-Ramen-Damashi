using UnityEngine;

public class Track : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Ken_PChar Ken;
    public AudioSource hitSound;

    private void Start()
    {
        hitSound = GetComponent<AudioSource>();
    }
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Ken_PChar>().DisableInput(3f);
            hitSound.Play();
        }
    }
}
