using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SkunkSprayTrigger : MonoBehaviour
{
    public UnityEvent spray;
    BoxCollider2D poohCol;

    private void Start()
    {
        poohCol = PoohPlatformController.poohCol;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other == poohCol)
        {
            spray.Invoke();
            gameObject.SetActive(false);
        }
    }
}
