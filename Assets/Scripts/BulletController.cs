using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    float power;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine("Stretch");
    }

    
    private void Start()
    {
        power = ShootController.shotPower;
        Shoot();
    }

    IEnumerator Stretch()
    {
        float i = 1.5f;
        float j = .5f;
        while (transform.localScale.x > 1f)
        {
            i -= .1f;
            j += .1f;
            transform.localScale = new Vector3(i, j, transform.localScale.z);
            yield return null;
        }
    }

    void Shoot()
    {
        rb.AddForce(speed * power * transform.right, ForceMode2D.Impulse);
    }
}
