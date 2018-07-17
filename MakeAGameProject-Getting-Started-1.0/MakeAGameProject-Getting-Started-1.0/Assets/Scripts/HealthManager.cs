using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class HealthManager : MonoBehaviour
{
    public float maxHitpoints = 100f;

    float _hitpoints = 100f;
    public float hitpoints
    {
        get
        {
            return _hitpoints;
        }

        set
        {
            if (invulnerable || externalInvulnerable)
            {
                _hitpoints = Mathf.Clamp(value, _hitpoints, maxHitpoints);
            }

            else
            {
                _hitpoints = Mathf.Clamp(value, 0, maxHitpoints);

                if (_hitpoints == 0)
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }

    public bool invulnerable = false;
    public AudioClip hurtSound;

    AudioSource audioSource;
    public bool externalInvulnerable;

    void Start()
    {
        externalInvulnerable = false;
        audioSource = GetComponent<AudioSource>();
    }

    public void ModifyHP(float modifier)
    {
        float prevHitpoints = hitpoints;
        hitpoints += modifier;

        if (hitpoints < prevHitpoints)
            audioSource.PlayOneShot(hurtSound);
    }
}
