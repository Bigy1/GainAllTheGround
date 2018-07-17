using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class racket2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var rigidBody = GetComponent<Rigidbody2D>();
        if (Input.GetKeyDown("up"))
        {
            rigidBody.velocity = new Vector2(0, 5);
        }
        if (Input.GetKeyDown("down"))
        {
            rigidBody.velocity = new Vector2(0, -5);
        }
        if (transform.position.y > 3.36)
        {
            rigidBody.velocity = new Vector2(0, 0);
        }
        if (transform.position.y < -3.36) 
        {
            rigidBody.velocity = new Vector2(0, 0);
        }
    }
}
