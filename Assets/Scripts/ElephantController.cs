using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElephantController : AnimalController
{

    public static float currentFrame;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        currentFrame = anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
        //cycleOffset = anim.GetNextAnimatorClipInfo(0)[0].clip
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(runSpeed * transform.localScale.x, rb.velocity.y);
    }

    
}
