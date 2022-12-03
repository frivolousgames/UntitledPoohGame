using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SkunkSprayController : MonoBehaviour
{
    public UnityEvent spray;

    public void StopSpray()
    {
        spray.Invoke();
    }
}
