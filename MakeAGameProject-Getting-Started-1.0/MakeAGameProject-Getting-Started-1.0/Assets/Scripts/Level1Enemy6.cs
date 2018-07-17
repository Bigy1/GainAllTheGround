using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Enemy6 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var rigidBody = GetComponent<Rigidbody2D>();
        GameObject player = GameObject.Find("Player");
        Transform playerTransform = player.transform;

        if (playerTransform.position.y > 2)
        {
            rigidBody.velocity = new Vector2(3, rigidBody.velocity.y);
        }
	}
}
