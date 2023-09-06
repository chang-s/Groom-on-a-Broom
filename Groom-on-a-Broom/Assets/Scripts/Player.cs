using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float xSpeed;
    public float ySpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical"); // -1 to 1

        float verticalVelocity = verticalInput * ySpeed; // dictates how quickly you move up or down and negative numbers go opposite of input

        transform.Translate(xSpeed, verticalVelocity, 0); // moves by an amount; bypasses physics system
    }
}
