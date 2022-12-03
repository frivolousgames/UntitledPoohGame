using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventInvoke : MonoBehaviour
{

    public UnityEvent uEvent;
    // Start is called before the first frame update
    public void InvokeEvent()
    {
        uEvent.Invoke();
    }
}
