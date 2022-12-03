using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonkeyTrigger : MonoBehaviour
{
    public UnityEvent drop;
    public UnityEvent climb;
    BoxCollider2D poohCol;

    private void Start()
    {
        poohCol = PoohPlatformController.poohCol;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == poohCol)
        {
            drop.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other == poohCol)
        {
            climb.Invoke();
        }
    }
}
