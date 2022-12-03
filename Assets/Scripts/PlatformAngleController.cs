using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAngleController : MonoBehaviour
{
    Quaternion startPos;

    public GameObject pooh;

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
        
        if(pooh.transform.localScale.x == 1)
        {
            Vector3 dir = Input.mousePosition - transform.position;
            float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) / .9f;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        else
        {
            Vector3 dir = (Input.mousePosition - transform.position);
            float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) / .9f;
            transform.rotation = Quaternion.AngleAxis(angle, -Vector3.forward);
            //Debug.Log(dir);
        }
    }

    public void Drag()
    {
        {
            if (pooh.transform.localScale.x == 1)
            {
                Vector3 dir = Input.mousePosition - transform.position;
                float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) / .9f;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
            else
            {
                Vector3 dir = Input.mousePosition - transform.position;
                float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) / .9f;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
    }

    public void ReturnToStartAim()
    {

        transform.rotation = startPos;
    }
}
