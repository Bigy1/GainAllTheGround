using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour {

    public float damage;
    public float destroyTime = 4f;
    float destroyTimer = 0f;

    Vector2 currentVelocity = Vector2.zero;
    Vector2 perviousVelocity = Vector2.zero;

    void Update()
    {
        destroyTimer += Time.deltaTime;
        if (destroyTimer > destroyTime)
            Destroy(gameObject);
        perviousVelocity = currentVelocity;
        currentVelocity = GetComponent<Rigidbody2D>().velocity;
    }

	void OnCollisionEnter2D(Collision2D collision)
    {
        HealthManager healthManager = collision.transform.GetComponent<HealthManager>();
        if (healthManager)
        {
            healthManager.ModifyHP(damage);
            if (!healthManager.invulnerable)
                Destroy(gameObject);
            else
            {
                Physics2D.IgnoreCollision(healthManager.GetComponent<Collider2D>(), GetComponent<Collider2D>());
                GetComponent<Rigidbody2D>().velocity = perviousVelocity;
            }
        }
        else
            Destroy(gameObject);
    }
}
