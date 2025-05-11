using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float xSpeed;
    public float ySpeed;
    public ParticleSystem dustEmit;

    private string jumpVar = "IsJumping";
    private string hitVar = "IsHit";
    private string groundVar = "OnGround";

    private Rigidbody2D rigidBody;
    private Animator anim;

    private Vector3 endPosition = new Vector3();
    private Vector3 startPosition;

    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    // Add acceleration instead of setting velocity directly. verticalVelocity = instead of having speed you set, have some amount of acceleration. Take current velocity and add acceleration. So input goes up and down would lower/raise acceleration, then applied to (acceleration +5/-5 if pressing up/down). Gives a more wavey feel. Give a maximum. 
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

        rigidBody.velocity = new Vector3(xSpeed, Mathf.Min(rigidBody.velocity.y + verticalVelocity, 5), 0);

        // Testing out Lerp
        //transform.position = Vector3.Lerp(transform.position, endPosition, Time.deltaTime);

        if (rigidBody.velocity.y + verticalVelocity > 0)
        {
            anim.SetBool(jumpVar, true);
        } else
        {
            anim.SetBool(jumpVar, false);
        }
    }

    // Fixed Update - collider/rigidbody on Player. you can raycast, shoot a line to the ground and see if it hits a ground (programatic solution). Easier solution: 2nd collider that sits at the feet of the player. Rectangle under his feet. See if that rectangle collider is hitting the ground.
    // Have reference to FeetCollider, check if it's hitting the ground on Update.
    // if it's marked as "isTrigger" won't interact with physics - won't stop other objects. Will fire off "ontriggerenter". Won't stop anything or interact with physics engine. 

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            anim.SetBool(hitVar, true);
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            anim.SetBool(groundVar, true);
            dustEmit.Stop();
            dustEmit.Play();
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
        
        /*
        if (other.gameObject.CompareTag("Flag"))
        {
            GameManager.cleared = true;
        }
        */
    }
}
