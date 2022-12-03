using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBeeController : AnimalController
{
    Vector2 rbVelocity;

    BoxCollider2D poohCollider;

    BoxCollider2D col;
    public GameObject jabCollider;

    public float backSpeed;
    public float jabSpeed;
    public float idleSpeed;

    bool isAttacking;

    Transform pooh;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        col = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        poohCollider = PoohPlatformController.poohCol;
        pooh = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (isAttacking == false)
        {
            if (pooh.position.x > transform.position.x)
            {
                transform.localScale = new Vector2(-1, transform.localScale.y);
            }
            else
            {
                transform.localScale = new Vector2(1, transform.localScale.y);
            }
        }
        
    }

    private void FixedUpdate()
    {
        //rb.velocity = rbVelocity;
        if(isAttacking == false)
        {
            Idle();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other == poohCollider)
        {
            if(isAttacking == false)
            {
                anim.SetTrigger("Attack");
                isAttacking = true;
                col.enabled = false;
                StartCoroutine(AttackSequence());
            }
        }
    }

    IEnumerator AttackSequence()
    {
        rb.velocity = new Vector2(1 * transform.localScale.x, 1) * backSpeed;
        yield return new WaitForSeconds(.2f);
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(.4f);
        jabCollider.SetActive(true);
        rb.velocity = new Vector2(-1 * transform.localScale.x, -1) * jabSpeed;
        yield return new WaitForSeconds(.16f);
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(.4f);
        rb.velocity = new Vector2(1 * transform.localScale.x, 1) * backSpeed;
        anim.SetTrigger("AttackReset");
        yield return new WaitForSeconds(.4f);
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(.2f);
        col.enabled = true;
        jabCollider.SetActive(false);
        isAttacking = false;
    }

    void Idle()
    {
        rb.MovePosition(Vector2.MoveTowards(transform.position, new Vector2(pooh.position.x, pooh.position.y + 2), idleSpeed * Time.fixedDeltaTime));
    }
}
