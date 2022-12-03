using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimalController : MonoBehaviour
{
    protected Rigidbody2D rb;

    public Animator anim;

    protected bool isGrounded;

    public float runSpeed;

    protected bool flipped;

    public LayerMask playerLayer;


    public virtual void FlipScale()
    {
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }

    public virtual void RaycastCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, Mathf.Infinity, playerLayer);
        Debug.DrawRay(transform.position, Vector2.right * 100 * transform.localScale.x, Color.green);

        if (hit.collider == null)
        {
            if (flipped == false)
            {
                flipped = true;
                StartCoroutine("TurnAround");
            }
        }
    }
}
