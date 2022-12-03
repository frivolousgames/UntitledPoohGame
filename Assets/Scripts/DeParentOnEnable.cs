using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeParentOnEnable : MonoBehaviour
{
    private void OnEnable()
    {
        transform.parent = null;
        transform.rotation = Quaternion.identity;
    }
}
