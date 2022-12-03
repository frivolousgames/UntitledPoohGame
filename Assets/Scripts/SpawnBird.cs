using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBird : MonoBehaviour
{
    public Transform[] spawnPos;
    bool isSpawning = true;

    int previousSpawn;
    private void Start()
    {
        StartCoroutine("StartSpawn");
    }
    IEnumerator StartSpawn()
    {
        while(isSpawning == true)
        {
            int birdWait = Random.Range(2, 8);
            yield return new WaitForSeconds(birdWait);
            GameObject bird = BirdPooler.instance.GetPooledObject();
            int selectedSpawn = Random.Range(0, spawnPos.Length);
            while (selectedSpawn == previousSpawn)
            {
                selectedSpawn = Random.Range(0, spawnPos.Length);
                yield return null;
            }
            previousSpawn = selectedSpawn;
            Vector2 pos = spawnPos[selectedSpawn].position;
            bird.transform.position = pos;
            if (selectedSpawn < 2)
            {
                bird.transform.localScale = new Vector2(-1, bird.transform.localScale.y);
            }
            else
            {
                bird.transform.localScale = new Vector2(1, bird.transform.localScale.y);
            }
            //bird.transform.rotation = new Quaternion(0f, 0f, Random.Range(0f, -12f), 1);
            bird.SetActive(true);
            yield return null;
        }
    }
}
