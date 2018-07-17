using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class racket : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var rigidBody = GetComponent<Rigidbody2D>();
		if (Input.GetKeyDown("s"))
        {
            rigidBody.velocity = new Vector2 (0, -5);
        }
        if (Input.GetKeyDown("w"))
        {
            rigidBody.velocity = new Vector2(0, 5);
        }
    }
}
