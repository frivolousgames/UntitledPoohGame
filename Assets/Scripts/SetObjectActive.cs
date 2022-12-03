using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObjectActive : MonoBehaviour
{
    public GameObject _object;

    public void ActivateObject()
    {
        _object.SetActive(true); 
    }
}
