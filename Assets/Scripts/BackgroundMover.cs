using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    GameObject cam;
    public float x;
    public float y;
    float adjustedY;

    GameObject player;
    Transform pParent;
    Rigidbody2D rb;

    float startPosition;
    float length;
    float distance;

    Vector3 camPosition;
    bool isCamMoving;

    private void Awake()
    {
        name = name.Replace("(Clone)", "");
        
        startPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().sprite.bounds.size.x * transform.localScale.x;
        
        //Debug.Log("Length :" + length);
    }

    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        player = GameObject.FindGameObjectWithTag("Player");
        camPosition = cam.transform.localPosition;
        rb = player.GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        adjustedY = transform.parent.position.y * y;
        transform.position = new Vector2(transform.position.x, adjustedY);
        distance = cam.transform.position.x;
        MoveVine();
        IsCameraMoving();
        MoveBackground();
        if(PoohPlatformController.isVineHanging == true)
        {

        }
        ChangePosition();
        Debug.Log("Cam Moving: " + isCamMoving);
    }

    void MoveBackground()
    {
        if(isCamMoving != false)
        {
            if (rb.velocity.x > .1f)
            {
                transform.Translate(-Vector2.right * Time.deltaTime * x);
            }
            else if (rb.velocity.x < -.1f)
            {
                transform.Translate(Vector2.right * Time.deltaTime * x);
            }

            else
            {
                return;
            }
        }        
    }
    void MoveVine()
    {
        if (isCamMoving != false && PoohPlatformController.isVineHanging == true)
        {
            if (player.transform.parent.rotation.z > .1f)
            {
                transform.Translate(-Vector2.right * Time.deltaTime * x * .35f);
            }
            else if (player.transform.parent.rotation.z < -.1f)
            {
                transform.Translate(Vector2.right * Time.deltaTime * x * .35f);
            }

            else
            {
                return;
            }
        }
    }

    void ChangePosition()
    {   
        if (transform.position.x >= distance + length * 2)
        {
            transform.position -= new Vector3(Mathf.Floor(length * 3), adjustedY);
        }
        else if (transform.position.x <= distance - length * 2)
        {
            transform.position += new Vector3(Mathf.Floor(length * 3), adjustedY);
        }
    }
    void IsCameraMoving()
    {
        if (cam.transform.localPosition.x < camPosition.x - .001f || cam.transform.localPosition.x > camPosition.x + .001f)
        {
            isCamMoving = true;
            camPosition = cam.transform.position;
        }
        else
        {
            isCamMoving = false;
        }
    }
}
