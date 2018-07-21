using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class AiGunHill : MonoBehaviour {

    public float fireRate = 3f;
    private Vector2 playerPos;
    private Vector2 originalPos;
    public GameObject NPCHighGroundBulletLeft;
    public GameObject NPCHighGroundBulletDown;
    Animator animator;
    public bool LookDown;
    public float raycastMaxDistance = 10f;

    //private float originOffset = 0.5f;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        animator.SetBool("LookDown", true);

    }
    
    private void FixedUpdate()
    {
        RaycastCheckUpdate();
    }

    // Update is called once per frame
    private RaycastHit2D CheckRaycast(Vector2 direction)
    {
        //float directionOriginOffset = originOffset * (direction.x > 0 ? 1 : -1);

        Vector2 startingPosition = new Vector2(transform.position.x, transform.position.y);

        Debug.DrawRay(startingPosition, direction, Color.red);
        return Physics2D.Raycast(startingPosition, direction, raycastMaxDistance, 10);
    }
    void Update() {
        GameObject player = GameObject.Find("Player");
        Transform playerTransform = player.transform;
        playerPos = GameObject.Find("Player").transform.position;

        if (playerTransform.position.y + 10 <= playerTransform.position.x)
        {
            animator.SetBool("LookDown", true);
        }
        if (playerTransform.position.y + 10 > playerTransform.position.x)
        {
            animator.SetBool("LookDown", false);
        }
    }
    private bool RaycastCheckUpdate() {
        GameObject player = GameObject.Find("Player");
        Transform playerTransform = player.transform;
        playerPos = GameObject.Find("Player").transform.position;
        if (fireRate > 0)
        {
            fireRate -= Time.deltaTime;
            if (fireRate <= 1)
            {
                fireRate = 3;
                if (playerTransform.position.y > -1.5)
                {
                    if (playerTransform.position.x > 6.5)
                    {
                        if (playerTransform.position.y + 10 <= playerTransform.position.x)
                        {
                            Debug.Log("PlayerInPosition");
                            Vector2 direction = new Vector2(0, -1);
                            RaycastHit2D hit = CheckRaycast(direction);
                            if (hit.collider)
                            {
                                Instantiate(NPCHighGroundBulletDown, transform.position, transform.rotation);
                                Debug.Log("Firing");
                                //                Debug.DrawRay(transform.position, hit.point, Color.black, 3f);
                                return true;
                            }

                        }
                        else if (playerTransform.position.y + 10 > playerTransform.position.x)
                        {
                            Debug.Log("PlayerInPosition");
                            Vector2 direction = new Vector2(-1, 0);
                            RaycastHit2D hit = CheckRaycast(direction);
                            if (hit.collider)
                            {
                                Instantiate(NPCHighGroundBulletLeft, transform.position, transform.rotation);
                                Debug.Log("Firing");
                                return true;
                                //                       Debug.DrawRay(transform.position, hit.point, Color.red, 3f);
                            }
                        }
                    }
                }
            }
        }
        return false;
    }
}

