using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JumpTrigger : MonoBehaviour
{

    public UnityEvent jumpCheck;
    public void Jump()
    {
        jumpCheck.Invoke();
    }
}
