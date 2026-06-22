using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class jamming : MonoBehaviour

{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().DisableInput(2f);
            Destroy(gameObject);
        }
    }


}
