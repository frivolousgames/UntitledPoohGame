using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyController : AnimalController
{

    public bool isClimbing;
    bool climbUp;

    public BoxCollider2D climbStop;
    public BoxCollider2D dropStop;

    public float climbSpeed;

    bool throwReady;
    bool dropReady;

    public float climbAnimDir;

    public float throwWait;
    bool throwing;

    //POOP
    public GameObject poop;
    public Transform poopSpawnPos;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        dropReady = true;
    }

    private void Start()
    {
         
    }

    private void Update()
    {
        anim.SetBool("isClimbing", isClimbing);
        anim.SetFloat("speed", climbAnimDir);
        ThrowPoop();
    }

    private void FixedUpdate()
    {
        RaycastCheck();
    }

    IEnumerator TurnAround()
    {
        yield return new WaitForSeconds(.01f);
        FlipScale();
        flipped = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other == climbStop)
        {
            rb.velocity = Vector3.zero;
            dropReady = true;
            isClimbing = false;
        }
        if (other == dropStop)
        {
            rb.velocity = Vector3.zero;
            if(throwing == false)
            {
                throwReady = true;
            }
            isClimbing = false;
            Debug.Log("STOPPED");
        }
    }


    public void Drop()
    {
        if(throwing == false)
        {
            throwReady = false;

            DropMovement();
        }

    }

    void DropMovement()
    {
        climbAnimDir = 1f;
        isClimbing = true;
        rb.velocity = Vector2.down * climbSpeed;
    }

    public void Climb()
    {
        StopCoroutine("ThrowReset");
        throwReady = false;
        throwing = false;

        ClimbMovement();
    }

    void ClimbMovement()
    {
        isClimbing = true;
        climbAnimDir = -1f;
        rb.velocity = -Vector2.down * climbSpeed;
    }

    public void ThrowPoop()
    {
        if(throwReady == true && throwing == false)
        {
            throwing = true;
            isClimbing = false;
            rb.velocity = Vector3.zero;
            anim.SetTrigger("throw");
            
            throwReady = false;
            StartCoroutine("ThrowReset");
        } 
    }

    public void SpawnPoop()
    {
        GameObject poo = Instantiate(poop, poopSpawnPos.position, Quaternion.identity, null);
        poo.transform.localScale = new Vector2(transform.localScale.x, 1);
    }

    IEnumerator ThrowReset()
    {
        yield return new WaitForSeconds(.1f);
        AnimatorClipInfo[] animInfo = anim.GetCurrentAnimatorClipInfo(0);
        yield return new WaitForSeconds(animInfo[0].clip.length + throwWait);
        ClimbMovement();
        yield return new WaitForSeconds(.4f);
        DropMovement();
        while(isClimbing == true)
        {
            yield return null;
        }
        throwReady = true;
        throwing = false;
    }

    void FastUpDown()
    {

    }
}
