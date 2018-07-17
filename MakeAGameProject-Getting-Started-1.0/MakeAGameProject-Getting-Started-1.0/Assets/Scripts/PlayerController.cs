using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SpriteRenderer sprite;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius;
    private bool groundCollision;
    public bool doubleJump;
    public Vector3 originalPos;

    void Start()
    {
        originalPos = transform.position;
    }

    void FixedUpdate()
    {
        groundCollision = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    void Update()
    {

        var rigidBody = GetComponent<Rigidbody2D>();
        var transform = GetComponent<Transform>();
        if (groundCollision == true)
        {
            doubleJump = true;
        }
        if (Input.GetKey("right"))
        {
            rigidBody.velocity = new Vector2(5, rigidBody.velocity.y);
            sprite.flipX = false;
            //transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetKey("d"))
        {
            rigidBody.velocity = new Vector2(5, rigidBody.velocity.y);
            sprite.flipX = false;
            //transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetKey("left"))
        {
            rigidBody.velocity = new Vector2(-5, rigidBody.velocity.y);
            sprite.flipX = true;
            //transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetKey("a"))
        {
            rigidBody.velocity = new Vector2(-5, rigidBody.velocity.y);
            sprite.flipX = true;
            //transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetKeyDown("space"))
        {
            if (groundCollision == true)
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, 13);
                doubleJump = true;
            }
            else if (groundCollision == false && doubleJump == true)
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, 13);
                doubleJump = false;
            }
        }
        if (Input.GetKeyDown("up"))
        {
            if (groundCollision == true)
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, 13);
                doubleJump = true;
            }
            else if (groundCollision == false && doubleJump == true)
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, 13);
                doubleJump = false;
            }
        }
        if (Input.GetKeyDown("w"))
        {
            if (groundCollision == true)
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, 13);
                doubleJump = true;
            }
            else if (groundCollision == false && doubleJump == true)
            {
                    rigidBody.velocity = new Vector2(rigidBody.velocity.x, 13);
                    doubleJump = false;
            }
            }
        if (transform.position.y < -11)
        {

            transform.position = originalPos;
            rigidBody.velocity = new Vector2(0, 0);
        }
        if (Input.GetKeyDown("r"))
        {

            transform.position = originalPos;
            rigidBody.velocity = new Vector2(0, 0);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        var rigidBody = GetComponent<Rigidbody2D>();
        if (other.name == "EnemyDamage")
        {
            transform.position = new Vector2(2, 1);
        }
        else if (other.name == "EnemyHead")
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 13);
        }
    }
}