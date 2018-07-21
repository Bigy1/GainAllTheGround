using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollect : MonoBehaviour {

    public Transform target;
    public bool follow;
    public float speed;
    public float offsetx = 0;
    public float offsety;
    public 
	// Use this for initialization
	void Start () {
        GameObject player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	public void OnTriggerEnter2D() {
        follow = true;
	}

    void Update()
    { 
        if (follow)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }
}
