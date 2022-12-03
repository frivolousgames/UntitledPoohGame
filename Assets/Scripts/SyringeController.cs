using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SyringeController : MonoBehaviour
{
    GameObject[] bullets;

    bool empty = false;

    float startY;
    float endY;

    public float lerpSpeed;

    public GameObject squirt;

    public UnityEvent bloodHit;

    int hits = 0;

    private void Awake()
    {
        startY = transform.localPosition.y;
        endY = .18f;
    }

    private void Start()
    {
        AppleShooterController.syringes++;
    }

    private void Update()
    {
        bullets = GameObject.FindGameObjectsWithTag("Bullet");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (empty == false)
        {
            foreach (GameObject b in bullets)
            {
                if (other.gameObject == b)
                {
                    Debug.Log("Hit");
                    //Depress plunger
                    empty = true;
                    squirt.SetActive(true);
                    StartCoroutine("DepressPlunger");
                }
            }
        } 
    }

    IEnumerator DepressPlunger()
    {
        //.6f
        //1.1f

        float lerpY = startY;
        while(transform.localPosition.y > endY)
        {
            lerpY -= .015f;
            transform.localPosition = new Vector2(transform.localPosition.x, lerpY);
            yield return null;
        }
        bloodHit.Invoke();
        hits++;
        Debug.Log("hits " + hits + " syringes " + AppleShooterController.syringes);
        if(hits == AppleShooterController.syringes)
        {
            AppleShooterController.roundWon = true;
            Debug.Log("WON");
        }
    }
}
