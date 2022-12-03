using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateInvisible : MonoBehaviour
{
    public GameObject m_object;
    private void OnBecameInvisible()
    {
        m_object.SetActive(false);
    }
}
