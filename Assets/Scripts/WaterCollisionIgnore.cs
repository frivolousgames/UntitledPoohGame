using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollisionIgnore : MonoBehaviour
{
    GameObject[] waterCols;
    Collider2D thisCol;

    private void Awake()
    {
        thisCol = GetComponent<Collider2D>();
    }
    private void Start()
    {
        waterCols = GameObject.FindGameObjectsWithTag("WaterPhysCol");
    }

    private void Update()
    {

    }
    private void FixedUpdate()
    {
        waterCols = GameObject.FindGameObjectsWithTag("WaterPhysCol");
        if (waterCols != null)
        {
            foreach (GameObject w in waterCols)
            {
                if(w != thisCol)
                {
                    Physics2D.IgnoreCollision(thisCol, w.GetComponent<BoxCollider2D>());
                }
            }
        }
    }
}
