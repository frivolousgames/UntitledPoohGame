using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwingingVineController : MonoBehaviour
{
    public Animator anim;

    public BoxCollider2D[] cols;

    Rigidbody2D rb;

    public bool movingLeft;
    public bool idle;

    public float swingSpeed;
    float startSpeed;
    float direction;
    public float maxAngle;
    float z;

    public UnityEvent poohHit;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        movingLeft = true;
        direction = -1;
    }

    private void Start()
    {
        startSpeed = swingSpeed;
        StartCoroutine("PendulumSwing");
    }

    private void Update()
    {
        anim.SetBool("movingLeft", movingLeft);
        anim.SetBool("idle", idle);
    }

    private void FixedUpdate()
    {
        //rb.rotation = z;
        rb.MoveRotation(z);
        //Debug.Log("Velocity: " + rb.rotation);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        foreach (var col in cols)
        {
            if (other == col)
            {
                if(movingLeft == true)
                {
                    movingLeft = false;
                }
                else
                {
                    movingLeft = true;
                }
            }
        }
        if(other == PoohPlatformController.poohCol)
        {
            PoohPlatformController.vine = transform;
            poohHit.Invoke();
            Debug.Log("Pooh");
        }
    }

    //void PendulumSwing()
    //{
    //    if (idle == false)
    //    {

    //        float z = Mathf.Lerp(-maxAngle, maxAngle, Time.deltaTime * swingSpeed);
    //        transform.rotation = Quaternion.Euler(0, 0, z * direction);
    //    }
    //}

    IEnumerator PendulumSwing()
    {
        float i = .5f;
        while (idle == false)
        {
            while (i < 1)
            {
                i += .01f;
                z = Mathf.SmoothStep(-maxAngle, maxAngle, i);

                yield return new WaitForSeconds(swingSpeed);
            }
            while (i >= 0)
            {
                i -= .01f;
                z = Mathf.SmoothStep(-maxAngle, maxAngle, i);

                yield return new WaitForSeconds(swingSpeed);
            }
        }
    }
}
