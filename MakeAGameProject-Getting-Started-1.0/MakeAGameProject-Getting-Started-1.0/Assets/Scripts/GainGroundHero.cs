using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainGroundHero : MonoBehaviour
{


    Animator animator;
    public Vector2 originalPos;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetFloat("Direction", 0);
        animator.SetBool("Moving", false);
        originalPos = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        var rigidBody = GetComponent<Rigidbody2D>();
        var transform = GetComponent<Transform>();
        if (Input.GetKey("w"))
        {
            rigidBody.velocity = new Vector2(0, 5);
        }
        if (Input.GetKeyUp("w"))
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);
        }
        if (Input.GetKey("a"))
        {
            rigidBody.velocity = new Vector2(-5, 0);
        }
        if (Input.GetKeyUp("a"))
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }
        if (Input.GetKey("d"))
        {
            rigidBody.velocity = new Vector2(5, 0);
        }
        if (Input.GetKeyUp("d"))
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }
        if (Input.GetKey("s"))
        {
            rigidBody.velocity = new Vector2(0, -5);
        }
        if (Input.GetKeyUp("s"))
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);
        }
        if (Input.GetKey("left shift"))
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x * 2, rigidBody.velocity.y * 2);
        }
        if (rigidBody.velocity.y > 4)
        {
            animator.SetFloat("Direction", 1);
        }
        if (rigidBody.velocity.x < -4)
        {
            animator.SetFloat("Direction", 0);
        }
        if (rigidBody.velocity.x > 4)
        {
            animator.SetFloat("Direction", 2);
        }
        if (rigidBody.velocity.y < -4)
        {
            animator.SetFloat("Direction", 3);
        }
        if (rigidBody.velocity.x == 0 && rigidBody.velocity.y == 0)
        {
            animator.SetBool("moving", false);
        }
        if (rigidBody.velocity.x != 0 && rigidBody.velocity.y != 0)
        {
            animator.SetBool("moving", true);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        var rigidBody = GetComponent<Rigidbody2D>();
        if (other.name == "EnemyDamage")
        {
            transform.position = originalPos;
        }
    }
}
