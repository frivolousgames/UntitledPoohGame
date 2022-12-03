using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatorPooler : ObjectPool
{
    public static GatorPooler instance;
    public static int objectNum;
    private void Awake()
    {
        instance = this;
        objectNum = 0;
    }
    void Start()
    {
        CreatePool();
    }

    private void Update()
    {
        //Debug.Log("ObjectNum: " + objectNum);
    }

    public override GameObject GetPooledObject()
    {
        objectNum = Random.Range(0, amountToPool);
        for (int i = Random.Range(0, amountToPool); i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
