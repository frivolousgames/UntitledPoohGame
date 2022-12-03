using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    GameObject fish;

    public Transform spawnL;
    public Transform spawnR;

    public static bool isSpawning;
    public float spawnWait;

    private void Start()
    {
        isSpawning = true;
        StartCoroutine("SpawnFish");
    }

    IEnumerator SpawnFish()
    {
        yield return new WaitForSeconds(.1f);
        while (isSpawning == true)
        {
            fish = FishPooler.instance.GetPooledObject();
            if(fish != null)
            {
                Vector2 spawnPos = new Vector2(Random.Range(spawnL.position.x, spawnR.position.x), spawnR.position.y);
                fish.transform.position = spawnPos;
                fish.transform.rotation = Quaternion.identity;
                if (spawnPos.x > 0)
                {
                    fish.transform.localScale = new Vector2(-1f, 1f);
                }
                else
                {
                    fish.transform.localScale = new Vector2(1f, 1f);
                }
                fish.SetActive(true);
            }

            yield return new WaitForSeconds(spawnWait);
        }
    }
    
}
