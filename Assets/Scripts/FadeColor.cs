using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeColor : MonoBehaviour
{
    public float waitTime;

    SpriteRenderer sp;

    float clear;

    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        clear = 0f;
        StartCoroutine("FadeWait");
    }

    IEnumerator FadeWait()
    {
        yield return new WaitForSeconds(waitTime);
        while(sp.color.a != clear)
        {
            sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, sp.color.a - .005f);
            yield return null;
        }
    }
}
