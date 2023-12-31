using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /* 
    // Old Code that detects collision rather than trigger
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Coin - CollisionEnter");
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Nothing happened");
        }
    }
    */

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Destroy the coin if Object tagged Player comes in contact with it
        if (collision.CompareTag("Player"))
        {
            GameManager.totalCoins++;
            Destroy(gameObject);
        }
    }
}
