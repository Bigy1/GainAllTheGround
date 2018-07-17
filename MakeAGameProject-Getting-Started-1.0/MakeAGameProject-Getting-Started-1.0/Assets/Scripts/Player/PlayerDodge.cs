using UnityEngine;
using System.Collections;

public class PlayerDodge : MonoBehaviour
{
    public float duration = 0.25f;
    public float speed = 16f;
    public float cooldown = 2f;
    
    float durationTimer = 0f;
    float cooldownTimer;
    bool dodging = false;

    Vector2 velocity;

    Player player;
    Controller2D controller;
    PlayerSpecificAbility playerAbility;

	void Awake ()
    {
        player = GetComponent<Player>();
        controller = GetComponent<Controller2D>();
        playerAbility = GetComponent<PlayerSpecificAbility>();

        cooldownTimer = cooldown;
	}
	
	void Update ()
    {
        cooldownTimer += Time.deltaTime;

	    if(Input.GetButtonDown("Fire2") && !dodging && cooldownTimer >= cooldown && controller.collisions.below && controller.enabled)
        {
            player.enabled = false;
            dodging = true;
            velocity = new Vector2(speed * controller.collisions.faceDir, player.velocity.y);

            HealthManager healthManager = GetComponent<HealthManager>();

            if (healthManager)
                healthManager.externalInvulnerable = true;

            if (playerAbility)
                playerAbility.enabled = false;
        }

        if (dodging)
        {
            velocity.y += player.gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime, new Vector2(controller.collisions.faceDir, 0));

            if (controller.collisions.below || controller.collisions.above)
                velocity.y = 0f;

            durationTimer += Time.deltaTime;

            if (durationTimer >= duration || !controller.collisions.below)
            {
                if (playerAbility)
                    playerAbility.enabled = true;

                dodging = false;
                player.enabled = true;

                HealthManager healthManager = GetComponent<HealthManager>();

                if (healthManager)
                    healthManager.externalInvulnerable = false;

                durationTimer = cooldownTimer = 0f;
                controller.collisions.faceDir = 0;

                player.velocity = velocity;
                velocity = Vector2.zero;
            }
        }
	}
}
