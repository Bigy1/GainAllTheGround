using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour {
    private Vector2 originalPos;
    private Vector2 playerPos;
    private Vector2 playerx;
    // Use this for initialization
    void Start () {
        originalPos = transform.position;
    }

    // Update is called once per frame
    void Update() {
        GameObject player = GameObject.Find("Player");
        Transform playerTransform = player.transform;

        var rigidBody = GetComponent<Rigidbody2D>();
        playerPos = GameObject.Find("Player").transform.position;

        if (transform.position.y < -15)
        {
            transform.position = originalPos;
            rigidBody.velocity = new Vector2(0, 0);
        }
        if (transform.position.y > 0)
        {
            transform.position = originalPos;
            rigidBody.velocity = new Vector2(0, 0);
        }
        if (playerTransform.position.y < (-10)) {         
            transform.position = originalPos;
            rigidBody.velocity = new Vector2(0, 0);
        }
        if (Input.GetKeyDown("r")) {
            transform.position = originalPos;
            rigidBody.velocity = new Vector2(0, 0);
        }
	}
}
