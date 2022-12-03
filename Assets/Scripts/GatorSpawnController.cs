using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatorSpawnController : MonoBehaviour
{
    public Transform spawnRight;
    public Transform spawnLeft;

    int selectedPos;
    float dir;
    Vector2 spawnPos;

    public static bool isSpawning;
    float spawnWait;

    public static float sMin;
    public static float sMax;

    int objectNum = 0;

    private void Awake()
    {
        isSpawning = true;
        
    }

    private void Start()
    {
        StartCoroutine("SpawnGators");
    }

    private void Update()
    {

    }
    IEnumerator SpawnGators()
    {
        while(isSpawning == true)
        {
            GameObject gator = GatorPooler.instance.GetPooledObject();
            //Debug.Log("Gator Ready");
            SetPosition();
            if (gator != null)
            {
                gator.transform.position = spawnPos;
                gator.transform.localScale = new Vector2(gator.transform.localScale.x * dir, gator.transform.localScale.y);
                gator.SetActive(true);
            }
            else
            {
                
                //GatorPooler.objectNum = 
                //isSpawning = false;
            }
            //GatorPooler.objectNum++;
            spawnWait = Random.Range(sMin, sMax); 
            yield return new WaitForSeconds(spawnWait);
        }
    }
    void SetPosition()
    {
        selectedPos = Random.Range(0, 2);

        if (selectedPos == 0)
        {
            spawnPos = spawnRight.position;
            dir = 1;
        }
        else
        {
            spawnPos = spawnLeft.position;
            dir = -1;
        }
    }
}
