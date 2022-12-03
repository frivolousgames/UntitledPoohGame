using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    public float waitTime;

    private void Awake()
    {
        StartCoroutine("DestroyWait");
    }

    IEnumerator DestroyWait()
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }
}
