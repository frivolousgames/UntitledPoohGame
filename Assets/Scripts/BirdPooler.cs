using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPooler : ObjectPool
{
    public static BirdPooler instance;


    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        CreatePool();
    }
}
