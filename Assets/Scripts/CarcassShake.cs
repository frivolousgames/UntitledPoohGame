using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarcassShake : MonoBehaviour
{
    Animator anim;

    int shakeWait;

    private void Awake()
    {
        shakeWait = Random.Range(50, 200);
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        anim.SetInteger("shakeWait", shakeWait);
        //Debug.Log(shakeWait);
    }

    public void Shake()
    {
        shakeWait -= 1;
    }

    public void ResetShake()
    {
        shakeWait = Random.Range(50, 200);
    }
}
