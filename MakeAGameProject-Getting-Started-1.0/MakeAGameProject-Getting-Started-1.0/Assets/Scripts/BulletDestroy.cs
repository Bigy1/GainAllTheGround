using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour {
    public float lifeTime = 1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonUp("Fire2") && name == ("BulletAlt(Clone)"))
        {
            Destruction();
        }
        if (transform.position.x < 40 && transform.position.y < 30)
        {
            if (lifeTime > 0)
            {
                lifeTime -= Time.deltaTime;
                if (lifeTime <= 0)
                {
                    Destruction();
                }
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        var rigidBody = GetComponent<Rigidbody2D>();
        if (other.name == "EnemyDamage")
        {
            Destruction();
        }
        if (other.name == "GainGroundGround")
        {
            Destruction();
        }
    }
    void Destruction()
    {
        var rigidBody = GetComponent<Rigidbody2D>();
        if (transform.position.x < 20)
        {
            Destroy(this.gameObject);
        }
    }
}
