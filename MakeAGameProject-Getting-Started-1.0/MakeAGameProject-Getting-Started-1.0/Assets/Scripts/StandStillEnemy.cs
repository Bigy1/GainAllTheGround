using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandStillEnemy : MonoBehaviour
{
    public float fireRate = 3f;
    public float range = 5f;
    public GameObject BulletUp;
    public GameObject BulletLeft;
    public GameObject BulletDown;
    public GameObject BulletRight;
    public float Direction;
    public Transform target;
    Animator animator;
    public float raycastMaxDistance = 15f;
    public Vector2 raycastDirection;
    public float directionLooking;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

 //   private void FixedUpdate()
  //  {
   //     RaycastCheckUpdate();
  //  }

    // Update is called once per frame
    void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget < 5)
        {
            Vector3 targetDir = target.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg + 180f;
       //     Debug.Log(angle);
            RaycastCheckUpdate();
            if (angle > 135 & angle < 225)
            {
                Direction = 3;
                raycastDirection = new Vector2(10, 0);
                animator.SetFloat("Direction", 3);
            }
            if (angle > 225 & angle < 315)
            {
                Direction = 2;
                raycastDirection = new Vector2(0, 10);
                animator.SetFloat("Direction", 2);
            }
            if (angle > 315)
            {
                Direction = 1;
                raycastDirection = new Vector2(-10, 0);
                animator.SetFloat("Direction", 1);
            }
            if (angle < 45)
            {
                Direction = 1;
                raycastDirection = new Vector2(-10, 0);
                animator.SetFloat("Direction", 1);
            }
            if (angle > 45 & angle < 135)
            {
                Direction = 4;
                raycastDirection = new Vector2(0, -10);
                animator.SetFloat("Direction", 4);
            }
        }
        else
        {
            Direction = 4;
            raycastDirection = new Vector2(0, -10);
            animator.SetFloat("Direction", 4);
        }
    }
    public bool RaycastCheckUpdate()
    {
        if (fireRate > 0)
        {
            fireRate -= Time.deltaTime;
            if (fireRate <= 0.25)
            {
                fireRate = 3;
                RaycastHit2D hit = CheckRaycast(raycastDirection);
                if (hit.collider)
                {
                    if (Direction == 1)
                    {
                        Instantiate(BulletLeft, transform.position, transform.rotation);
                    }
                    if (Direction == 2)
                    {
                        Instantiate(BulletUp, transform.position, transform.rotation);
                    }
                    if (Direction == 3)
                    {
                        Instantiate(BulletRight, transform.position, transform.rotation);
                    }
                    if (Direction == 4)
                    {
                        Instantiate(BulletDown, transform.position, transform.rotation);
                    }
                    Debug.Log(hit.collider.name);
                    Debug.DrawRay(transform.position, hit.point, Color.black, 30f);
                    return true;
                }
            }
        }
        return false;
    }
    public RaycastHit2D CheckRaycast(Vector2 raycastDirection)
    {
        Vector2 startingPosition = new Vector2(transform.position.x, transform.position.y);
        
        Debug.DrawRay(startingPosition, raycastDirection, Color.red);
        return Physics2D.Raycast(startingPosition, raycastDirection, raycastMaxDistance, 1 << 10);
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