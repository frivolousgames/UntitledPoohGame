using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPropeller : MonoBehaviour
{
    GameObject crashCol;

    Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        Debug.Log("Awake");
    }

    private void Start()
    {
        crashCol = GameObject.FindGameObjectWithTag("CrashTrigger");
        Debug.Log("Start");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == crashCol)
        {
            anim.SetTrigger("stop");
            Debug.Log("Staopped");
        }
    }
}
