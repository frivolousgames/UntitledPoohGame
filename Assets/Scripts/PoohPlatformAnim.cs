using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PoohPlatformAnim : MonoBehaviour
{
    public UnityEvent hitOver;
    public void HitOver()
    {
        hitOver.Invoke();
    }
}
