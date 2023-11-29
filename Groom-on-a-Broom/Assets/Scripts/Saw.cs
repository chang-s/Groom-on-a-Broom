using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public float changeIncrement;

    private float ySpeed;
    private bool hitWall;
    private Direction dir;

    public enum Direction
    {
        UP,
        DOWN
    }

    // Start is called before the first frame update
    void Start()
    {
        hitWall = false;
        dir = Direction.UP;
        ySpeed = 0.1f;
    }
    void Awake()
    {
        // Make Collider2D as trigger 
        // GetComponent<Collider2D>().isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (dir == Direction.UP)
        {
            ySpeed += changeIncrement;
        } else
        {
            ySpeed -= changeIncrement;
        }

        transform.position = new Vector3(transform.position.x, ySpeed, 0);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.totalLife--;
        }

        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Sky"))
        {
            switch (dir) {
                case Direction.UP:
                    dir = Direction.DOWN;
                    break;
                case Direction.DOWN:
                    dir = Direction.UP;
                    break;
            }
        }
    }
}
