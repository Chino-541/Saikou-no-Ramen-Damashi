using System.Collections;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    [SerializeField] private GameObject miniGameUI;
    void Start()
    {
        miniGameUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MiniGame()
    {
        miniGameUI.SetActive(true);
        
    }
}
