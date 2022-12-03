using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostController : MonoBehaviour
{
    GameObject[] sacks;
    float dir;
    public float bumpPower;
    int random;
    int randomScale;
    float scale;

    public Animator anim;
    public float postWait;
    private void OnEnable()
    {
        randomScale = Random.Range(0, 2);
        if(randomScale == 0)
        {
            scale = 1;
        }
        else
        {
            scale = -1;
        }
        transform.localScale = new Vector2(scale, transform.localScale.y);
        StartCoroutine("EndWait");
    }
    private void Update()
    {
        sacks = GameObject.FindGameObjectsWithTag("Sack");        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(sacks != null)
        {
            foreach(GameObject sack in sacks)
            {
                if(other.gameObject == sack)
                {
                    random = Random.Range(0, 2);
                    if (random == 0)
                    {
                        dir = Random.Range(-4, -2);
                    }
                    else
                    {
                        dir = Random.Range(2, 4);
                    }
                    Rigidbody2D sackRb = sack.GetComponent<Rigidbody2D>();
                    sackRb.AddForce(new Vector2(dir, 4 ) * bumpPower, ForceMode2D.Impulse);
                }
            }
        }
    }

    IEnumerator EndWait()
    {
        yield return new WaitForSeconds(postWait);
        anim.SetTrigger("End");
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
    
}
