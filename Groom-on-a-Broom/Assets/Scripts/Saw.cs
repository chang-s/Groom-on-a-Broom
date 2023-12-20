using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public float changeIncrement;

    private float yPos;
    private float startingX;
    private Direction dir;

    public enum Direction
    {
        UP,
        DOWN
    }

    // Start is called before the first frame update
    void Start()
    {
        dir = Direction.UP;
        yPos = 0.1f;
        startingX = transform.position.x;
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
            yPos += changeIncrement;
        } else
        {
            yPos -= changeIncrement;
        }

        transform.position = new Vector3(startingX, yPos + changeIncrement, 0);
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
