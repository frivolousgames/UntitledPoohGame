using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ColliderTriggerEvent : MonoBehaviour
{
    GameObject player;

    public UnityEvent hit;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("PhysicalCollider");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (player != null)
        {
            if (other.gameObject == player)
            {
                hit.Invoke();
                Debug.Log("Hit");
            }
        }
    }
}
