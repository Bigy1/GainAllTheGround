using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRight : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var rigidBody = GetComponent<Rigidbody2D>();
        if (Input.GetKey("left shift") && Input.GetKey("d"))
        {
            rigidBody.velocity = new Vector2(30, 0);
        }
    }
	
	// Update is called once per frame
	void Update () {
        var rigidBody = GetComponent<Rigidbody2D>();
        if (rigidBody.velocity.x != 30)
        {
            rigidBody.velocity = new Vector2(15, 0);
        }

    }
}
