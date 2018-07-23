using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollect : MonoBehaviour {

    public Transform target;
    public bool follow;
    public float speed;
    public float offsetx;
    public float offsety;
    public float xthing;
    public float ything;
    public GameObject player = GameObject.Find("Player");
    Vector2 goThere;
    Animator animator;
    // Use this for initialization
    void Start () {
        animator = player.GetComponent<Animator>();

    }
	
	// Update is called once per frame
	public void OnTriggerEnter2D() {
        follow = true;
	}

    void Update()
    {
        var playerRigidBody = player.GetComponent<Rigidbody2D>();
        if (follow)
        {
            if (playerRigidBody.velocity.x < -1)
            {
                offsetx = 1;
                offsety = 0;
            }
            if (playerRigidBody.velocity.y > 1)
            {
                offsety = -1;
                offsetx = 0;
            }
            if (playerRigidBody.velocity.x > 1)
            {
                offsetx = -1;
                offsety = 0;
            }
            if (playerRigidBody.velocity.y < -1)
            {
                offsety = 1;
                offsetx = 0;
            }
            xthing = offsetx + target.position.x;
            ything = offsety + target.position.y;
            goThere = new Vector2(xthing, ything);
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, goThere, step);
        }
    }
}
