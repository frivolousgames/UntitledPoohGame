using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSquash : MonoBehaviour
{
    GameObject ground;
    Transform parent;

    BoxCollider2D col;
    public Animator anim;
    //public Rigidbody2D rb;

    private void Awake()
    {
        col = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        ground = GameObject.FindGameObjectWithTag("Ground");
        parent = transform.parent;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("HIt");
        if (other.gameObject == ground)
        {
            Debug.Log("HItGround");
            //StartCoroutine("Squash");
            col.isTrigger = false;
            anim.SetTrigger("Squash");
        }
    }

    IEnumerator Squash()
    {
        while(parent.localScale.y > .8f)
        {
            parent.localScale = new Vector2(parent.localScale.x + .03f, parent.localScale.y - .03f);
            yield return null; 
        }
        while (parent.localScale.y < .999f)
        {
            parent.localScale = new Vector2(parent.localScale.x - .03f, parent.localScale.y + .03f);
            yield return null;
        }
    }
}
