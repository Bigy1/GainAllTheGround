using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightClickShoot : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        var rigidBody = GetComponent<Rigidbody2D>();
        if (Input.GetKey("left shift") && Input.GetKey("w"))
        {
            rigidBody.velocity = new Vector2(0, 30);
        }
    }

    // Update is called once per frame
    void Update () {
        var rigidBody = GetComponent<Rigidbody2D>();
        var Transform = GetComponent<Transform>();
        if (rigidBody.velocity.y != 30)
        {
            rigidBody.velocity = new Vector2(0, 15);
        }
    }
}
