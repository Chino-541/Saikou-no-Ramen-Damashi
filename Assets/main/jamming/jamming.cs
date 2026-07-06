using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class jamming : MonoBehaviour

{
    [SerializeField] private AudioSource Slip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Slip.Play();
            collision.GetComponent<Player>().DisableInput(2f);
            Destroy(gameObject);
        }
    }
}
