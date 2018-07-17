using UnityEngine;
using System.Collections;

public class HealthPack : MonoBehaviour {

    public float health = 25f;
    public AudioClip pickup;

    void OnTriggerEnter2D(Collider2D coll)
    {
        HealthManager healthManager = coll.gameObject.GetComponent<HealthManager>();

        if (healthManager)
        {
            if (healthManager.hitpoints < healthManager.maxHitpoints)
            {
                AudioSource.PlayClipAtPoint(pickup, transform.position);
                healthManager.ModifyHP(health);
                Destroy(gameObject);
            }
        }
    }
}
