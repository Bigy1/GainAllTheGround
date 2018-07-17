using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
    public float range = 100f;
    public GameObject BulletUp;
    public GameObject BulletLeft;
    public GameObject BulletDown;
    public GameObject BulletRight;
    public GameObject BulletAlt;
    public float Direction;
	// Use this for initialization
	void Start () {
    
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("w") && !Input.GetKey("a") && !Input.GetKey("d") && !Input.GetKey("s"))
        {
            Direction = 2;
        }
		if (Input.GetButtonDown ("Fire1") && Direction == 2 && Direction != 1 && Direction != 3 && Direction != 4)
        {
            Instantiate(BulletUp, transform.position, transform.rotation);
        }
        if (Input.GetKey("a") && !Input.GetKey("s") && !Input.GetKey("d"))
        {
            Direction = 1;
        }
        if (Input.GetButtonDown("Fire1") && Direction == 1 && Direction != 4 && Direction != 3)
        {
            Instantiate(BulletLeft, transform.position, transform.rotation);
        }
        if (Input.GetKey("d") && !Input.GetKey("s"))
        {
            Direction = 3;
        }
        if (Input.GetButtonDown("Fire1") && Direction == 3 && Direction != 4)
        {
            Instantiate(BulletRight, transform.position, transform.rotation);
        }
        if (Input.GetKey("s"))
        {
            Direction = 4;
        }
        if (Input.GetButtonDown("Fire1") && Direction == 4)
        {
            Instantiate(BulletDown, transform.position, transform.rotation);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Instantiate(BulletAlt, transform.position, transform.rotation);
        }
    }    
}
