using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFlame : MonoBehaviour
{
    private void Awake()
    {
        //StartCoroutine("FlameWait");
    }

    IEnumerator FlameWait()
    {
        yield return new WaitForSeconds(.05f);
        gameObject.SetActive(false);
    }
}
