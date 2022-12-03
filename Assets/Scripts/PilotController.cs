using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilotController : MonoBehaviour
{
    public Rigidbody2D rb;

    public float ejectSpeed;
    public float dropSpeed;

    private void Awake()
    {

    }

    private void OnEnable()
    {
        
        Eject();
    }

    void Eject()
    {
        rb.AddForce(new Vector2(.5f, -.6f), ForceMode2D.Impulse);
    }

    public void Float()
    {
        rb.velocity = Vector2.down * dropSpeed;
    }
}
