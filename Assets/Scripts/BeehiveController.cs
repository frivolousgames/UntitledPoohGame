using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeehiveController : MonoBehaviour
{
    GameObject[] bullets;
    public GameObject col;

    public Rigidbody2D rb;
    public float hitPower;

    bool beeSpawning;
    //GameObject[] bees;

    public GameObject bee;

    private void Awake()
    {

    }
    private void Start()
    {
        bullets = GameObject.FindGameObjectsWithTag("Bullet");
    }
    private void Update()
    {
        //bees = GameObject.FindGameObjectsWithTag("Bee");
        bullets = GameObject.FindGameObjectsWithTag("Bullet");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        foreach(GameObject bullet in bullets)
        {
            if(other.gameObject == bullet)
            {
                rb.AddForce(Vector2.right * bullet.transform.localScale.x * hitPower, ForceMode2D.Impulse);
                Debug.Log("HIT");
                if(beeSpawning == false)
                {
                    beeSpawning = true;
                    StartCoroutine("SpawnBees");
                }
         
            }
        }
    }

    IEnumerator SpawnBees()
    {
        int beeCount = 0;
        while(beeSpawning == true)
        {
            //if(bees.Length < 5)
            if(beeCount < 5)
            {
                Instantiate(bee, new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity, null);
                beeCount++;
                yield return new WaitForSeconds(1.4f);
            }
            yield return null;
        }
        yield break;
    }
}
