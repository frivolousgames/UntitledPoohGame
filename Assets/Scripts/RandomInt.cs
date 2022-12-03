using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomInt : MonoBehaviour
{
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        
        
    }
    private void Start()
    {
        anim.SetFloat("offset", Random.Range(0.0f, 1.0f));
    }

}
