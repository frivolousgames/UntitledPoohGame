using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkController : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject ground;
    public float upForce;
    public float sideForce;

    Vector2 velocity;
    public float minHeight;
    public float maxHeight;
    public float oSpeed;
    public float speed;
    float heightSpeed;

    bool landed;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.localScale = new Vector2(Random.Range(.1f, .2f), Random.Range(.1f, .25f));
        //transform.localRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
    }

    private void Start()
    {
        rb.AddForce(new Vector2(Random.Range(-1f, 1f) * sideForce, Random.Range(.25f, 1f) * upForce), ForceMode2D.Impulse);
        ground = GameObject.FindGameObjectWithTag("Ground");
    }

    private void FixedUpdate()
    {
        if(landed == true)
        {
            rb.gravityScale = 0f;
            velocity = new Vector2(speed, Mathf.SmoothStep(minHeight, maxHeight, heightSpeed));
            heightSpeed = Mathf.PingPong(Time.time * oSpeed, 1);
            rb.velocity = velocity;
            rb.mass = 1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == ground && landed == false)
        {
            landed = true;
        }
    }
}
