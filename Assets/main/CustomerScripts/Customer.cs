using System;
using System.Collections;
using UnityEngine;


public class Customer : MonoBehaviour
{
    [SerializeField] private MiniGameManager miniGame;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("ミニゲーム始め");
            miniGame.MiniGame();
        }
    }
}
