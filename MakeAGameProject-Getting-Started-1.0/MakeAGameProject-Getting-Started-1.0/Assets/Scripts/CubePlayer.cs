using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlayer : MonoBehaviour {
    public Vector3 originalPos;
	// Use this for initialization
	void Start () {
        var rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = new Vector3(rigidBody.velocity.x, 0, -15);
        originalPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        var rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = new Vector3(rigidBody.velocity.x, 0, -15);
        if (Input.GetKey("d"))
        {
            rigidBody.velocity = new Vector3(-5, 0, rigidBody.velocity.z);
        } 
        if (Input.GetKeyUp("d"))
            rigidBody.velocity = new Vector3(0, 0, rigidBody.velocity.z);

        if (Input.GetKey("a"))
        {
            rigidBody.velocity = new Vector3(5, 0, rigidBody.velocity.z);
        }
        if (Input.GetKeyUp("a"))
            rigidBody.velocity = new Vector3(0, 0, rigidBody.velocity.z);
        
    }
}
