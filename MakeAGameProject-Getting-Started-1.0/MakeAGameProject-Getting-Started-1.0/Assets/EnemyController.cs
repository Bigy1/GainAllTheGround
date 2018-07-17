using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public bool moveLeft;
    public LayerMask groundLayer;
    public Transform wallCheck;
    public float wallCheckRadius;
    private bool wallCollision;
    private Vector3 originalPos;

    void Start()
    {
        moveLeft = true;
        originalPos = transform.position;
    }

    void FixedUpdate()
    {
        wallCollision = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, groundLayer);
    }

    void Update()
    {
        var rigidBody = GetComponent<Rigidbody2D>();
        GameObject player = GameObject.Find("Player");
        Transform playerTransform = player.transform;
        if (wallCollision)
        {
            moveLeft = !moveLeft;
        }

        if (moveLeft)
        {
            transform.localScale = new Vector2(1, 1);
            rigidBody.velocity = new Vector2(-5, rigidBody.velocity.y);
        }
        else
        {
            transform.localScale = new Vector2(-1, 1);
            rigidBody.velocity = new Vector2(5, rigidBody.velocity.y);
        }
        if (Input.GetKeyDown("r"))
        {
            transform.position = originalPos;
        }
        if (playerTransform.position.y < -10)
        {
            transform.position = originalPos;
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        var rigidBody = GetComponent<Rigidbody2D>();
        if (other.name == "Player")
        {
            transform.position = new Vector2(108, 0);
            rigidBody.velocity = new Vector2(0, 0);
        }
    }
}
