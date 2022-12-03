using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SackController : MonoBehaviour
{
    Rigidbody2D rb;

    public Animator anim;

    GameObject waterCol;

    bool hitWater;

    Vector2 velocity;
    public float speed;
    public float minHeight;
    public float maxHeight;
    float heightSpeed;
    float oSpeed;

    public float heightClamp;

    GameObject[] sacks;
    public float nudgeForce;
    float dir;
    bool touching;
    bool floating;

    GameObject[] border;

    public GameObject splash;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        waterCol = GameObject.FindGameObjectWithTag("Ground");
        oSpeed = Random.Range(1.2f, 1.5f);
        if (gameObject.transform.position.x >= 0f)
        {
            dir = -1;
        }
        else
        {
            dir = 1;
        }

        border = GameObject.FindGameObjectsWithTag("Border");
        // minHeight = -1f;
        // maxHeight = 1f; 
    }

    private void Update()
    {
        
        sacks = GameObject.FindGameObjectsWithTag("Sack");
        
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, 10f);
        if(hitWater == true && transform.position.y > heightClamp)
        {
            hitWater = false;
            rb.gravityScale = 3f;
        }
        SackFloat();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == waterCol && hitWater == false)
        {
            anim.SetTrigger("waterHit");
            hitWater = true;
        }
        if(sacks != null && hitWater == false)
        {
            foreach (GameObject s in sacks)
            {
                if (other.gameObject == s)
                {
                    anim.SetTrigger("waterHit");
                    rb.AddForce(Vector2.right * nudgeForce * dir, ForceMode2D.Impulse);
                    rb.mass = 4f;
                    touching = true;
                    //Debug.Log("Coming Thru");
                }
            }
        }
        foreach(GameObject b in border)
        {
            if (other.gameObject == b)
            {
                dir = -dir;
            }
        }
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (sacks != null && hitWater == false)
        {
            foreach (GameObject s in sacks)
            {
                if (other.gameObject == s)
                {
                    rb.AddForce(new Vector2(1f * dir * (nudgeForce / 2), -1f * nudgeForce), ForceMode2D.Force);
                    
                    //Debug.Log("Coming Thru");
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (sacks != null && hitWater == false)
        {
            foreach (GameObject s in sacks)
            {
                if (other.gameObject == s)
                {
                    touching = false;
                    rb.mass = 1f;
                    //Debug.Log("Coming Thru");
                }
            }
        }
    }

    void SackFloat()
    {
        if(floating == false)
        {
            if (hitWater == true)
            {
                floating = true;
                StartCoroutine("FloatWait");
            }
        } 
    }

    IEnumerator FloatWait()
    {
       
        while (touching == true && transform.position.y > heightClamp)
        {
            yield return null;
        }    
        Instantiate(splash, new Vector2(transform.position.x, transform.position.y - .5f), Quaternion.identity, null);
        while(floating == true)
        {
            rb.gravityScale = 0f;
            heightSpeed = Mathf.PingPong(Time.time * oSpeed, 1);
            velocity = new Vector2(speed, Mathf.SmoothStep(minHeight, maxHeight, heightSpeed)); 
            rb.velocity = velocity;
            rb.mass = 1f;
            yield return null;
        }  
    }
}
