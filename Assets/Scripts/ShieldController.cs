using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShieldController : MonoBehaviour
{
    BoxCollider2D shield;

    GameObject[] bullets;

    public GameObject shieldBursts;

    GameObject player;

    public UnityEvent hit;

    private void Awake()
    {
        shield = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("PhysicalCollider");
    }
    private void Update()
    {
        bullets = GameObject.FindGameObjectsWithTag("Bullet");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(bullets != null)
        {
            foreach (var bullet in bullets)
            {
                if (other.gameObject == bullet)
                {
                    Instantiate(shieldBursts, bullet.transform.position, Quaternion.identity, null);
                    bullet.SetActive(false);
                    //make *ting* sound
                }
            }
        }
       
        if(player != null)
        {
            if(other.gameObject == player)
            {
                hit.Invoke();
                Debug.Log("Hit");
            }
        }
    }
}
