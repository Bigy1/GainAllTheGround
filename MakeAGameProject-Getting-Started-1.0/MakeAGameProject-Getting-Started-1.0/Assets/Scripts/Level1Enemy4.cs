using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Enemy4 : MonoBehaviour
{
    public float topCollision = 0f;
    public float bottomCollision = 0f;
    public float rightCollision = 0f;
    public float leftCollision = 0f;

    public void OnTriggerEnter2D(Collider2D other)
    {
        var rigidBody = GetComponent<Rigidbody2D>();
        if (other.name == "TopGround")
        {
            float topCollision = 1;
            Debug.Log(other.name);

        }
        if (other.name == "LeftGround")
        {
            float leftCollision = 1;
            Debug.Log(other.name);
        }
        if (other.name == "RightGround")
        {
            float rightCollision = 1;
            Debug.Log(other.name);
        }
        if (other.name == "BottomGround")
        {
            float bottomCollision = 1;
            Debug.Log(other.name);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        float topCollision = 0f;
        float leftCollision = 0f;
        float rightCollision = 0f;
        float bottomCollision = 0f;
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var rigidBody = GetComponent<Rigidbody2D>();
        GameObject player = GameObject.Find("Player");
        Transform playerTransform = player.transform;
        //Start movement
        if (playerTransform.position.y > -12)
        {

            BeginMovement();
        }
    }
    void BeginMovement()
    {
        var rigidBody = GetComponent<Rigidbody2D>();
        GameObject player = GameObject.Find("Player");
        Transform playerTransform = player.transform;
        bool linedUp = false;

        if (playerTransform.position.x + 1 > transform.position.x && playerTransform.position.x - 1 < transform.position.x)
        {
            if (playerTransform.position.y > transform.position.y && bottomCollision == 0)
            {
                rigidBody.velocity = new Vector2(0, 3);
                linedUp = true;
            }
            if (playerTransform.position.y > transform.position.y && bottomCollision == 1)
            {
                rigidBody.velocity = new Vector2(-3, 0);
                linedUp = true;
            }
            if (playerTransform.position.y < transform.position.y && topCollision == 0)
            {
                rigidBody.velocity = new Vector2(0, -3);
                linedUp = true;
            }
            if (playerTransform.position.y < transform.position.y && topCollision == 1)
            {
                rigidBody.velocity = new Vector2(3, 0);
                linedUp = true;
            }
        }
        if (playerTransform.position.x > transform.position.x && linedUp == false && leftCollision == 0)
        {
            rigidBody.velocity = new Vector2(3, 0);
        }
        if (playerTransform.position.x > transform.position.x && linedUp == false && leftCollision == 1)
        {
            rigidBody.velocity = new Vector2(0, -3);
        }
        if (playerTransform.position.x < transform.position.x && linedUp == false && rightCollision == 0)
        {
            rigidBody.velocity = new Vector2(-3, 0);
        }
        if (playerTransform.position.x < transform.position.x && linedUp == false && rightCollision == 1)
        {
            rigidBody.velocity = new Vector2(0, 3);
        }
    }

}
    
    




