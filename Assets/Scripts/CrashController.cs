using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashController : MonoBehaviour
{
    public GameObject pilot;
    public GameObject explosion;
    public GameObject smoke;
    public GameObject fire;

    public BoxCollider2D crashCol;
    public BoxCollider2D explosionCol;

    Rigidbody2D rb;

    public float flySpeed;
    float crashSpeed = 1;

    //PROPELLER
    public Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = transform.localScale.x * transform.right * flySpeed * crashSpeed;
        //Debug.Log("CrashSpeed: " + crashSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other == crashCol)
        {
            StartCoroutine("SlowDown");
            anim.SetTrigger("stop");
        }

        if (other == explosionCol)
        {
            StopAllCoroutines();
            flySpeed = 0f;
            transform.localRotation = Quaternion.identity;
            smoke.SetActive(true);
            explosion.SetActive(true);
            fire.SetActive(false);

        }
    }

    IEnumerator SlowDown()
    {
        StartCoroutine("Turn");
        while(flySpeed > 1f)
        {
            flySpeed -= .01f;
            Debug.Log("Flyspeed: " + flySpeed);
            yield return null;
        }

        StartCoroutine("Decline");
        StartCoroutine("Eject");   
    }

    IEnumerator Turn()
    {
        yield return new WaitForSeconds(1.2f);
        float newZ = 0f;
        while (transform.localRotation.z < .38f)
        {

            newZ = Mathf.Lerp(newZ, 45f, Time.deltaTime);
            transform.localRotation = Quaternion.Euler(0, 0, newZ);
            //Debug.Log("Turning :" + transform.localRotation.z);
            yield return null;
        }
    }

    IEnumerator Decline()
    {
        yield return new WaitForSeconds(.8f);
        while (crashSpeed < 5f)
        {
            crashSpeed += .01f;
            yield return null;
        }
    }

    IEnumerator Eject()
    {
        yield return new WaitForSeconds(1.5f);
        pilot.SetActive(true);
    }
}
