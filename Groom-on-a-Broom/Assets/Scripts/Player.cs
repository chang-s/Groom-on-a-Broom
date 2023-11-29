using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float xSpeed;
    public float ySpeed;

    private Rigidbody2D rigidBody;
    private Animator anim;
    private string jumpVar = "IsJumping";
    private string hitVar = "IsHit";
    private string groundVar = "OnGround";

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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

        rigidBody.velocity = new Vector3(xSpeed, rigidBody.velocity.y + verticalVelocity, 0);

        if (rigidBody.velocity.y + verticalVelocity > 0)
        {
            anim.SetBool(jumpVar, true);
        } else
        {
            anim.SetBool(jumpVar, false);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            anim.SetBool(hitVar, true);
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            anim.SetBool(groundVar, true);
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            anim.SetBool(hitVar, false);
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            anim.SetBool(groundVar, false);
        }
    }
}
