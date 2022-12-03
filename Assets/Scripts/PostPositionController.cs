using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostPositionController : MonoBehaviour
{
    public GameObject[] posts;
    bool isWorking;
    public float spawnDelay;
    public float offset;

    List<float> postPosX;

    private void Awake()
    {
        postPosX = new List<float>();
        isWorking = true;
        foreach (GameObject post in posts)
        {
            postPosX.Add(post.transform.position.x);
        }
    }

    private void Start()
    {
        StartCoroutine("PostRoutine");
    }

    IEnumerator SetPosition()
    {
        int i = 0;
        foreach(GameObject post in posts)
        {
            post.transform.position = new Vector2(Random.Range(postPosX[i] - 1.75f, postPosX[i] + 1.75f), Random.Range(-2f, 3f));
            post.SetActive(true);
            i++;
            yield return new WaitForSeconds(offset);
        }
    }

    IEnumerator PostRoutine()
    {
        yield return new WaitForSeconds(.5f);
        while (isWorking == true)
        {
            StartCoroutine("SetPosition");
            yield return new WaitForSeconds(spawnDelay);
        }   
    }
}
