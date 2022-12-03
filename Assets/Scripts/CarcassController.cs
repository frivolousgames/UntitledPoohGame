using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarcassController : MonoBehaviour
{
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb.AddForce(Vector2.up * 15, ForceMode2D.Impulse);
    }
}
