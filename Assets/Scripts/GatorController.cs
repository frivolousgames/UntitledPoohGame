using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatorController : MonoBehaviour
{
    Rigidbody2D rb;
    public Animator anim;

    float speed;
    public float sMin;
    public float sMax;

    bool isBiting;
    float biteWait;

    int size = 0;
    public int maxSize;
    bool dead;
    public GameObject explosion;
    public Transform explosionSpawn;


    public static GameObject target;
    public GameObject sackBurst;
    public Transform sackBurstSpawn;
    GameObject sackBurstPrefab;

    public SpriteRenderer sr;
    Color32 original;
    public Color32 red;
    bool isBlinking;
    public float blinkSpeed;
    public GameObject blinkOn;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        isBiting = false;
        speed = Random.Range(sMin, sMax);

    }

    private void Start()
    {
        original = sr.color;
    }

    private void Update()
    {
        Die();
        if(blinkOn.activeSelf == true)
        {
            isBlinking = true;
            StartCoroutine("BlinkLoop");
        }
        Blink();
    }

    private void FixedUpdate()
    {
        if(isBiting == false)
        {
            rb.velocity = -Vector2.right * transform.localScale.x * speed;
        }
    }

    public void AttackTop()
    {
        if(isBiting == false)
        {
            anim.SetTrigger("BiteTop");
            isBiting = true;
            StartCoroutine("BiteReset");
        }
    }

    public void AttackFront()
    {
        if(isBiting == false)
        {
            anim.SetTrigger("BiteFront");
            isBiting = true;

            StartCoroutine("BiteReset");
        }
    }

    public void Deactivate()
    {
        gameObject.transform.localScale = new Vector2(1, 1);
        gameObject.SetActive(false);
    }
    IEnumerator BiteReset()
    {
        yield return new WaitForSeconds(.01f);
        if (sackBurstPrefab != null)
        {
            Destroy(sackBurstPrefab);
        }
        biteWait = anim.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        //Debug.Log("Anim Name: " + anim.GetCurrentAnimatorClipInfo(0)[0].clip.name);
        yield return new WaitForSeconds(biteWait);
        
        isBiting = false;
    }

    void Blink()
    {
        if(isBlinking == false)
        {
            if(size > maxSize - 1)
            {
                isBlinking = true;
                blinkOn.SetActive(true);
                StartCoroutine("BlinkLoop");
            }
        }
    }

    IEnumerator BlinkLoop()
    {
        while(isBlinking == true)
        {
            sr.color = Color32.Lerp(original, red, Mathf.PingPong(Time.time * blinkSpeed, 1));
            yield return null;
        }
    }
    void Die()
    {
        if(dead == false && size > maxSize)
        {
            dead = true;
            Instantiate(explosion, explosionSpawn.position, Quaternion.identity, null);
            GatorPooler.instance.pooledObjects.Remove(gameObject);
            GatorPooler.instance.amountToPool--;
            GatorSceneManager.die = true;
            Destroy(gameObject);//TEMP
        }
    }

    public void DestroyFood()
    {
        if(target != null)
        {
            size++;
            sackBurstPrefab = Instantiate(sackBurst, sackBurstSpawn.position, Quaternion.identity, sackBurstSpawn);
            Destroy(target);

        }
    }
}
