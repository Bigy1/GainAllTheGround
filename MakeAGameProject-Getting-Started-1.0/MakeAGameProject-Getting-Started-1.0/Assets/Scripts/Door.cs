using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class Door : MonoBehaviour
{
    public float triggerRadius = 1.5f;
    public Vector2 triggerOffset = Vector2.zero;
    public LayerMask triggerMask;

    public Vector3 triggerPosition
    {
        get { return transform.position + (Vector3)triggerOffset; }
    }

    BoxCollider2D boxCollider2D;

	void Start ()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
	}
	
	void Update ()
    {
	    if(Physics2D.OverlapCircleAll(triggerPosition, triggerRadius, triggerMask.value).Length > 0)
        {
            boxCollider2D.enabled = false;
        }
        else
        {
            boxCollider2D.enabled = true;
        }
	}
}
