using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkunkController : AnimalController
{
    BoxCollider2D groundCollider;
    public LayerMask ground;

    bool isWalking;
    bool isSpraying;

    public GameObject sprayTrigger;

    public GameObject sprayPS;
    //public GameObject sprayCol;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCollider = GetComponent<BoxCollider2D>();
        isWalking = true;
    }

    private void Update()
    {
        sprayPS.transform.localScale = new Vector2(transform.localScale.x, sprayPS.transform.localScale.y);
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.IsTouchingLayers(groundCollider, ground);
        Walk();
        if(isSpraying == false)
        {
            RaycastCheck();
        }
    }

    IEnumerator TurnAround()
    {
        yield return new WaitForSeconds(2f);
        while (isSpraying == true)
        {
            yield return null;
        }
        FlipScale();
        flipped = false;
    }

    void Walk()
    {
        if(isWalking == true)
        {
            rb.velocity = Vector2.right * runSpeed * transform.localScale.x;
        }
    }
    public void Spray()
    {
        if(isSpraying == false)
        {
            isSpraying = true;
            anim.SetTrigger("Spray");
            rb.velocity = Vector2.zero;
            isWalking = false;
            FlipScale();
        }

    }

    public void EndSpray()
    {
        isSpraying = false;
        isWalking = true;
        FlipScale();
        //sprayTrigger.SetActive(false);
        //sprayCol.SetActive(false);
        StartCoroutine("ResetSprayTrigger");
    }

    IEnumerator ResetSprayTrigger()
    {
        yield return new WaitForSeconds(1.2f);
        sprayTrigger.SetActive(true);
    }
}
