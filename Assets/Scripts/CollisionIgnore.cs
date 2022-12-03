using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionIgnore : MonoBehaviour
{
    BoxCollider2D boxCollider;

    BoxCollider2D poohCollider;

    BoxCollider2D poohGroundCol;

    GameObject[] animalCols;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        //Debug.Log(boxCollider.GetType());
    }
    private void Start()
    {
        poohCollider = PoohPlatformController.poohCol;
        poohGroundCol = GameObject.FindGameObjectWithTag("GroundCollider").GetComponent<BoxCollider2D>();
        animalCols = GameObject.FindGameObjectsWithTag("AnimalCollider");
    }

    private void Update()
    {

    }
    private void FixedUpdate()
    {
        animalCols = GameObject.FindGameObjectsWithTag("AnimalCollider");
        if (animalCols != null)
        {
            foreach (GameObject a in animalCols)
            {
                if(a != boxCollider)
                {
                    Physics2D.IgnoreCollision(boxCollider, a.GetComponent<BoxCollider2D>());
                }
            }
        }
        if (poohCollider.isActiveAndEnabled)
        {
            Physics2D.IgnoreCollision(boxCollider, poohCollider);
        }
        if (poohGroundCol.isActiveAndEnabled)
        {
            Physics2D.IgnoreCollision(boxCollider, poohGroundCol);
        }
    }
}
