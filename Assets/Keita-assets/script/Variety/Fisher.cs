using UnityEngine;

public class Fisher : MonoBehaviour
{
    [SerializeField] private GameObject Fishing;
    [SerializeField] private Ken_GFish fishSystem;

    private bool isFishing = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            if (!isFishing)
            {
                isFishing = true;
                Fishing.SetActive(true);
                Debug.Log("’Þ‚èŠJŽn");
            }
        }
    }
    public void EndFishingFlag()
    {
        isFishing = false;
    }
}