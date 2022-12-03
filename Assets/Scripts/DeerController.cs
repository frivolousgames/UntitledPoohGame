using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerController : AnimalController
{
    float jumpPower;

    BoxCollider2D groundCollider;
    public LayerMask ground;

    int jumpWait;
    public float rotSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCollider = GetComponent<BoxCollider2D>();
        JumpWait();

    }

    private void Update()
    {
        anim.SetBool("isGrounded", isGrounded);
        runSpeed = Random.Range(9, 12);
        jumpPower = Random.Range(1100, 1400);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(runSpeed, rb.velocity.y);
        isGrounded = Physics2D.IsTouchingLayers(groundCollider, ground);
        //Constraints();
        //Debug.Log(isGrounded);
    }

    public void Jump()
    {
        jumpWait -= 1;
            if(jumpWait == 0)
            {
                anim.SetTrigger("jump");
                rb.AddForce(Vector2.up * jumpPower);
                //transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, Mathf.Lerp(5, -10, Time.deltaTime * rotSpeed), 1f);
                JumpWait();
            }  
    }

    void JumpWait()
    {
        jumpWait = Random.Range(2, 4);
    }

    void Constraints()
    {
        if (isGrounded == true)
        {
            rb.constraints = RigidbodyConstraints2D.None;
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
