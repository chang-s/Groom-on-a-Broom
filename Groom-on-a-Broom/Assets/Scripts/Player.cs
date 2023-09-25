using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float xSpeed;
    public float ySpeed;

    private Rigidbody2D rigidBody; 

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Code Update: 9-6-23
        float verticalInput = Input.GetAxis("Vertical"); // -1 to 1
        float verticalVelocity = verticalInput * ySpeed; // dictates how quickly you move up or down and negative numbers go opposite of input
        // transform.Translate(xSpeed, verticalVelocity, 0); // moves by an amount; bypasses physics system (teleport)
        
        // Code Update: 9-25-23
        if (rigidBody == null)
        {
            Debug.LogError("No Rigidbody2D on player");
            return;
        }

        // Check if the specified key is being held down
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("Holding W");
        }
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("Holding S");
        }

        rigidBody.velocity = new Vector3(xSpeed, rigidBody.velocity.y + verticalVelocity, 0);
    }
}
