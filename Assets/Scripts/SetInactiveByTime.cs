using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInactiveByTime : MonoBehaviour
{
    public float waitTime;
    private void OnEnable()
    {
        StartCoroutine("InactiveWait");
    }

    IEnumerator InactiveWait()
    {
        yield return new WaitForSeconds(waitTime);
        gameObject.SetActive(false);
    }
}
