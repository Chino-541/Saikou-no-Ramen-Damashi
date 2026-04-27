using UnityEngine;

public class fishing : MonoBehaviour
{
    bool isfishing =  false;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Lake"))
            {
            if (Input.GetKey(KeyCode.C))
            {
                isfishing = true;
                
            }
        }
    }
}
