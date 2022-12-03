using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeController : MonoBehaviour
{
    public Animator wingAnim;
    Animator anim;
    Rigidbody2D rb;

    bool hit;

    public GameObject smile;
    public GameObject frown;

    public float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void Hit()
    {
        if(hit == false)
        {
            hit = true;
            wingAnim.speed += 1;
            smile.SetActive(false);
            frown.SetActive(true);
            anim.SetTrigger("flee");
            Scatter();
        }
    }

    private void FixedUpdate()
    {
        //Debug.Log("Vel: " + rb.velocity);
    }

    void Scatter()
    {
        float rand = Random.Range(-.5f, 1f);
        float x = 1 + rand;
        float y = 1 - rand;

        Vector2 direction = new Vector2(x, y);
        rb.velocity = direction * speed;
    }
}
