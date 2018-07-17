using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighGroundLeft : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        var rigidBody = GetComponent<Rigidbody>();
        if (Input.GetKey("left shift") && Input.GetKey("a"))
        {
            rigidBody.velocity = new Vector2(-30, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        var rigidBody = GetComponent<Rigidbody>();
        if (rigidBody.velocity.x != -30)
        {
            rigidBody.velocity = new Vector3(-15, 0, 5);
        }
    }
}
