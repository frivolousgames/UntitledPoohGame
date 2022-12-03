using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleController : MonoBehaviour
{
    Quaternion startPos;

    private void Awake()
    {
        startPos = Quaternion.identity;
    }

    private void Update()
    {
        //Debug.Log(transform.localEulerAngles);
        //transform.localRotation = Quaternion.Euler(0f, 0f, Mathf.Clamp(transform.localRotation.z, -30f, 65f));
    }

    public void PointAtTouch()
    {
        Vector3 dir = Input.mousePosition - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 21.5f;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void Drag()
    {
        {
            Vector3 dir = Input.mousePosition - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 21.5f;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    public void ReturnToStartAim()
    {

        transform.rotation = startPos;
    }
}
