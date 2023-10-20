using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    private Animator anim;
    private string hitName = "IsHit";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Destroy the coin if Object tagged Player comes in contact with it
        if (collision.CompareTag("Player"))
        {
            anim.SetBool(hitName, true);
        }
    }
}
