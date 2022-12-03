using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobWeapon : MonoBehaviour
{
    Rigidbody2D rb;
    public float throwPower;
    Transform pooh;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        pooh = GameObject.FindGameObjectWithTag("Player").transform;

        Vector3 norTar = (pooh.position - transform.position).normalized;
        float angle = Mathf.Atan2(norTar.y, norTar.x) * Mathf.Rad2Deg;
        // rotate to angle
        Quaternion rotation = new Quaternion();
        rotation.eulerAngles = new Vector3(0, 0, angle - 90);
        transform.rotation = rotation;
    }

    void Start()
    {
        pooh = GameObject.FindGameObjectWithTag("Player").transform;
        //rb.AddForce(Vector2.right * throwPower * transform.localScale.x, ForceMode2D.Impulse);
        rb.AddForce((transform.up * throwPower) + Vector3.up * (throwPower / 2), ForceMode2D.Impulse);

    }
}
