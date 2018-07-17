using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller2D), typeof(HealthManager), typeof(AudioSource))]
public class Enemy : MonoBehaviour
{
    public float moveSpeed = 4f;

    [SerializeField]
    AttackType attackType = AttackType.Melee;
    
    public LayerMask targetMask;
    public float viewDistance = 4f;
    [Range(0, 180)]
    public float FOV = 90f;
    [Range(5, 20)]
    public int targetCheckRayCount = 5;
    public float memoryTime = 8f;
    public float patrolRange = 8f;

    public float damage = 10f;
    public float attackRange = 4f;
    public float attackInterval = 0.25f;

    float memoryTimer = 0f;
    float attackTimer = 0f;
    
    [System.Serializable]
    enum AttackType
    {
        Melee,
        Ranged
    }
    Vector3 velocity = Vector3.zero;
    Vector2? targetLastPosition;
    Vector2 originalPosition;

    Controller2D controller;
    AudioSource audioSource;

    void Start()
    {
        controller = GetComponent<Controller2D>();
        audioSource = GetComponent<AudioSource>();
        originalPosition = transform.position;
    }

    void Update()
    {
        attackTimer += Time.deltaTime;

        velocity += (Vector3)Physics2D.gravity * Time.deltaTime;

        Ray2D[] rays = new Ray2D[targetCheckRayCount];
        Quaternion lowestAngle = Quaternion.Euler(0, 0, -FOV / 2f);
        float angleIncrement = FOV / (rays.Length - 1);

        for (int i = 0; i < rays.Length; i++)
        {
            rays[i] = new Ray2D(transform.position, (lowestAngle * Quaternion.Euler(0, 0, i * angleIncrement) * Vector2.right) * controller.collisions.faceDir);

            Debug.DrawRay(rays[i].origin, rays[i].direction * viewDistance, Color.yellow);
        }

        if (memoryTimer < memoryTime)
        {
            memoryTimer += Time.deltaTime;
        }

        if (memoryTimer >= memoryTime)
        {
            targetLastPosition = null;
        }

        Transform targetSeen = null;

        foreach (Ray2D ray in rays)
        {
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, viewDistance, targetMask.value);

            if (hit && !Physics2D.Raycast(ray.origin, ray.direction, viewDistance, controller.collisionMask.value))
            {
                targetLastPosition = hit.transform.position;
                memoryTimer = 0f;
                targetSeen = hit.transform;

                break;
            }
        }
        
        if (targetLastPosition != null)
        {
            if (!targetSeen)
            {
                if (targetLastPosition.Value.x - transform.position.x <= -4f || targetLastPosition.Value.x - transform.position.x >= 4f)
                {
                    velocity.x = moveSpeed * Mathf.Sign(targetLastPosition.Value.x - transform.position.x);
                }

                else
                {
                    velocity.x = moveSpeed * controller.collisions.faceDir;
                }
            }

            else if (Vector2.Distance(targetLastPosition.Value, transform.position) <= attackRange)
            {
                velocity.x = 0f;

                HealthManager targetHM = targetSeen.GetComponent<HealthManager>();

                if (targetHM && attackTimer >= attackInterval)
                {
                    targetHM.ModifyHP(-damage);
                    attackTimer = 0f;
                }
            }

            else
            {
                velocity.x = Mathf.Sign(targetLastPosition.Value.x - transform.position.x) * moveSpeed;
            }
        }

        else
        {
            velocity.x = controller.collisions.faceDir * moveSpeed;
        }
        
        Ray2D groundCheckRay = new Ray2D((controller.collisions.faceDir == -1) ? controller.raycastOrigins.bottomLeft : controller.raycastOrigins.bottomRight, Vector2.down);
        RaycastHit2D edge = Physics2D.Raycast(groundCheckRay.origin, groundCheckRay.direction, 1, controller.collisionMask.value);

        Debug.DrawRay(groundCheckRay.origin, groundCheckRay.direction * 1);

        if (!edge || controller.collisions.left || controller.collisions.right || Vector2.Distance(transform.position, originalPosition) > patrolRange)
        {
            targetLastPosition = null;
            velocity.x *= -1f;
        }

        controller.Move(velocity * Time.deltaTime, false);

        if (controller.collisions.below || controller.collisions.above)
        {
            velocity.y = 0f;
        }
    }
}
