using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainGroundEnemy : MonoBehaviour {
    public Vector2 originalPos;
	// Use this for initialization
	void Start () {
        originalPos = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        var rigidBody = GetComponent<Rigidbody2D>();
        GameObject player = GameObject.Find("Player");
        if (player.transform.position.x == 0 && player.transform.position.y == 0)
        {
            transform.position = originalPos;
            rigidBody.velocity = new Vector2(0, 0);
        }
	}
    public void OnTriggerEnter2D(Collider2D other)
    {
        var rigidBody = GetComponent<Rigidbody2D>();
        if (other.name == "BulletLeft(Clone)")
        {
            transform.position = new Vector2(999, 999);
        }
        if (other.name == "BulletRight(Clone)")
        {
            transform.position = new Vector2(999, 999);
        }
        if (other.name == "BulletUp(Clone)")
        {
            transform.position = new Vector2(999, 999);
        }
        if (other.name == "BulletDown(Clone)")
        {
            transform.position = new Vector2(999, 999);
        }
        if (other.name == "BulletAlt(Clone)")
        {
            transform.position = new Vector2(999, 999);
        }
    }
}

