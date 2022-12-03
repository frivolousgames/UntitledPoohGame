using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    Rigidbody2D rb;

    float upForce;
    float sideForce;

    public float uMin;
    public float uMax;

    public float sMin;
    public float sMax;

    public float lerpSpeed;

    GameObject splashCol;
    public GameObject splash;

    public float deactivateTime;

    GameObject[] sacks;
    public float bumpPower;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        //transform.rotation = Quaternion.Euler(Vector3.zero);

        upForce = Random.Range(uMin, uMax);
        sideForce = Random.Range(sMin, sMax);
        
        rb.AddForce(new Vector2(sideForce * transform.localScale.x, upForce), ForceMode2D.Impulse);
        StartCoroutine("LerpRot");
        StartCoroutine("DeactivateTimer");
    }

    private void OnDisable()
    {
        //transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    private void Start()
    {
        splashCol = GameObject.FindGameObjectWithTag("SplashCol");
    }

    private void Update()
    {
        sacks = GameObject.FindGameObjectsWithTag("Sack");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == splashCol)
        {
            Instantiate(splash, new Vector2(transform.position.x, splashCol.transform.position.y), Quaternion.identity, null);
        }
        if (sacks != null)
        {
            foreach (GameObject s in sacks)
            {
                if (other.gameObject == s)
                {
                    Rigidbody2D sackRb = s.GetComponent<Rigidbody2D>();
                    sackRb.AddForce(new Vector2(rb.velocity.x, Mathf.Abs(rb.velocity.y)) * bumpPower, ForceMode2D.Impulse);
                }
            }
            
        }
        
    }

    IEnumerator LerpRot()
    {
        float lerpMulti = 0;
        while(gameObject.activeInHierarchy == true)
        {
            transform.rotation = Quaternion.Lerp(Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 180 * transform.localScale.x), lerpSpeed * lerpMulti);
            lerpMulti = lerpMulti + Time.deltaTime;
            yield return null;
        }
    }
    IEnumerator DeactivateTimer()
    {
        yield return new WaitForSeconds(deactivateTime);
        gameObject.SetActive(false);
    }
}
