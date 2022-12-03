using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoohGatorController : MonoBehaviour
{
    Rigidbody2D rb;

    public Animator bodyAnim;
    public Animator armAnim;

    public float speed;

    public GameObject borderL;
    public GameObject borderR;

    bool movingRight;
    bool movingLeft;

    public static bool isDropping;
    bool ready;

    public GameObject sack;
    public Transform sackSpawn;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ready = false;
    }

    private void Start()
    {

    }

    private void Update()
    {
        bodyAnim.SetBool("isDropping", isDropping);
        armAnim.SetBool("isDropping", isDropping);
    }

    public void MoveRight()
    {
        movingRight = true;
        rb.velocity = Vector2.right * speed;
    }

    public void MoveLeft()
    {
        rb.velocity = -Vector2.right * speed;
        movingLeft = true;
    }

    public void StopLeft()
    {
        movingLeft = false;
        StopMoving();
    }
    public void StopRight()
    {
        movingRight = false;
        StopMoving();
    }

    void StopMoving()
    {
        if (movingRight == false && movingLeft == false)
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void Drop()
    {
        if(isDropping == false && ready == true)
        {
            Instantiate(sack, sackSpawn.position, Quaternion.identity, null);
            isDropping = true;
            ready = false;
            StartCoroutine("SackReset");
        }
    }

    IEnumerator SackReset()
    {
        yield return new WaitForSeconds(.5f);
        isDropping = false;
    }

    public void Ready()
    {
        ready = true;
    }
}
