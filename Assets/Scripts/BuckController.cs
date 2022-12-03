using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuckController : AnimalController
{
    public bool hitting;

    public float hitWait;

    Vector2 rbVelocity;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Run();
    }

    private void Update()
    {
        anim.SetBool("hitting", hitting);
    }
    private void FixedUpdate()
    {
        rb.velocity = rbVelocity;

        RaycastCheck();
    }

    
    IEnumerator TurnAround()
    {
        yield return new WaitForSeconds(2f);
        while(hitting == true)
        {
            yield return null;
        }
        FlipScale();
        Run();
        flipped = false;
    }

    void Run()
    {
        rbVelocity = new Vector2(runSpeed * transform.localScale.x, rb.velocity.y);
    }

    public void Hit()
    {
        hitting = true;
        rbVelocity = Vector2.zero;
        StartCoroutine("HitWait");
    }

    IEnumerator HitWait()
    {
        yield return new WaitForSeconds(hitWait);
        {
            hitting = false;
            Run(); 
        }
    }
}
