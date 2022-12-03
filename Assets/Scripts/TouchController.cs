using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public static bool isTouching;
    
    public void Touching()
    {
        isTouching = true;
    }

    public void NotTouching()
    {
        isTouching = false;
    }
}
