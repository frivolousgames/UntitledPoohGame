using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowController : MonoBehaviour
{
    float startY;
    float startX;
    public float offset;

    private void Awake()
    {
        startY = -4.03f;
        startX = transform.localPosition.x;
    }

    private void Update()
    {
        transform.position = new Vector2(transform.position.x, startY + offset);
        transform.localRotation = Quaternion.identity;
        //dif = transform.parent.position.y - startY;
        //transform.localScale = Vector2.Lerp(transform.localScale, new Vector2(transform.localScale.x - dif, transform.localScale.y - dif), Time.deltaTime);
    }
}
