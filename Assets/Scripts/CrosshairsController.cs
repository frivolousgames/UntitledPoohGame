using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CrosshairsController : MonoBehaviour
{
    Rigidbody2D rb;

    public SpriteRenderer sr;
    Color32 original;
    public Color32 red;

    bool isBlinking;
    public float blinkSpeed;
    float blinkStart;

    GameObject player;

    public float moveSpeed;

    Vector3 newPosition;
    Vector3 searchPos;
    Vector3 distance;

    float targetedTime = 0;
    bool shot;
    public UnityEvent shoot;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        newPosition = Vector3.zero;
        blinkStart = blinkSpeed;
    }
    private void Start()
    {
        original = sr.color;
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine("PositionChange");
    }

    private void Update()
    {
        Shoot();
        
        //Debug.Log("Shot " + shot);
        if(shot != true)
        {
            if(targetedTime > 1f)
            {
                blinkSpeed = blinkStart * 4;
            }
            else
            {
                blinkSpeed = blinkStart;
            }
        }
    }
    private void FixedUpdate()
    {
        if (transform.position != player.transform.position)
        {
            Search();   
        }
        else
        {
            targetedTime += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            Blink();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player && gameObject.activeSelf)
        {
            isBlinking = false;
            sr.color = original;
            targetedTime = 0;
            StartCoroutine("PositionChange");
        }
    }
    void Blink()
    {
        if (isBlinking == false)
        {
            {
                isBlinking = true;
                StartCoroutine("BlinkLoop");
            }
        }
    }
    IEnumerator BlinkLoop()
    {
        while (isBlinking == true)
        {
            sr.color = Color32.Lerp(original, red, Mathf.PingPong(Time.time * blinkSpeed, 1));
            yield return null;
        }
    }

    void Search()
    {
        rb.MovePosition(Vector2.MoveTowards(transform.position, newPosition, moveSpeed * Time.fixedDeltaTime));
    }

    IEnumerator PositionChange()
    {
        while (isBlinking != true)
        {
            if (newPosition == player.transform.position)
            {
                newPosition = searchPos;
            }
            else
            {
                newPosition = player.transform.position;
            }
            distance = player.transform.position - transform.position;
            searchPos = new Vector3(Random.Range(distance.x - 2, distance.x + 2), Random.Range(distance.y - 2, distance.y + 2), 0);
            yield return new WaitForSeconds(1.5f);
        }
        newPosition = player.transform.position;
    }

    void Shoot()
    {
        if(shot == false && targetedTime > 2f)
        {
            shot = true;
            shoot.Invoke();
            isBlinking = false;
            sr.color = red;
            GatorSceneManager.die = true;
        }
    }
}
