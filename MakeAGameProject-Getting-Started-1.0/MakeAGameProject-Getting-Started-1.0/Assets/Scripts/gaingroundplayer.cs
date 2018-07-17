using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gaingroundplayer : MonoBehaviour
{

    Animator animator;
    public Vector2 originalPos;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("facingDown", false);
        animator.SetBool("facingRight", false);
        animator.SetBool("facingLeft", false);
        animator.SetBool("facingUp", false);
        originalPos = transform.position;
    }
    public bool facingDown = false;
    public bool facingLeft = false;
    public bool facingRight = false;
    public bool facingUp = false;
    // Update is called once per frame
    void Update()
    {
        var rigidBody = GetComponent<Rigidbody2D>();
        var transform = GetComponent<Transform>();
        if (Input.GetKey("w"))
        {
            rigidBody.velocity = new Vector2(0, 5);
            animator.SetBool("facingUp", true);
        }
        if (Input.GetKeyUp("w"))
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);
            animator.SetBool("facingUp", false);
        }
        if (Input.GetKey("a"))
        {
            rigidBody.velocity = new Vector2(-5, 0);
            animator.SetBool("facingLeft", true);
        }
        if (Input.GetKeyUp("a"))
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
            animator.SetBool("facingLeft", false);
        }
        if (Input.GetKey("d"))
        {
            rigidBody.velocity = new Vector2(5, 0);
            animator.SetBool("facingRight", true);
        }
        if (Input.GetKeyUp("d"))
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
            animator.SetBool("facingRight", false);
        }
        if (Input.GetKey("s"))
        {
            rigidBody.velocity = new Vector2(0, -5);
            animator.SetBool("facingDown", true);
        }
        if (Input.GetKeyUp("s"))
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);
            animator.SetBool("facingDown", false);
        }
        if (Input.GetKey("left shift"))
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x * 2, rigidBody.velocity.y * 2);
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
