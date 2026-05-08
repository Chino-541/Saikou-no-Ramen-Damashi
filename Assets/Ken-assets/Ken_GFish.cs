using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ken_GFish : MonoBehaviour
{
    [SerializeField] private GameObject Bar;
    [SerializeField] private GameObject Block;
    [SerializeField] private GameObject Player;

    private void Start()
    {
        Block.transform.position = Bar.transform.position;

        

    }
    //void fishing ()
   
}

