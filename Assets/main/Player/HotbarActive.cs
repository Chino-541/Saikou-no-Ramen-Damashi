using UnityEngine;

public class HotbarActive : MonoBehaviour
{
    [SerializeField] private GameObject Hotbar;

    void Start()
    {
        Hotbar.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Hotbar.SetActive(!Hotbar.activeSelf);
        }
    }
}
