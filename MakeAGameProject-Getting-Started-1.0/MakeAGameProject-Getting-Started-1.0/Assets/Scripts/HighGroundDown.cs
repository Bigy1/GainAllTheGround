﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighGroundDown : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        var rigidBody = GetComponent<Rigidbody>();
        if (Input.GetKey("left shift") && Input.GetKey("s"))
        {
            rigidBody.velocity = new Vector2(0, -30);
        }
    }

    // Update is called once per frame
    void Update()
    {
        var rigidBody = GetComponent<Rigidbody>();
        var Transform = GetComponent<Transform>();
        if (rigidBody.velocity.y != -30)
        {
            rigidBody.velocity = new Vector2(0, -15);
        }
    }
}
