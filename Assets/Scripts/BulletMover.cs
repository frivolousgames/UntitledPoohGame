using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    Rigidbody2D rb;
    public float bulletSpeed;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        //rb.AddForce(speed * power * transform.right, ForceMode2D.Impulse);
        //rb.velocity = new Vector2(transform.parent.localScale.x * bulletSpeed, rb.velocity.y) * transform.right;
        rb.velocity = transform.localScale.x * transform.right * bulletSpeed;
        //transform.parent = null;
    }
}
