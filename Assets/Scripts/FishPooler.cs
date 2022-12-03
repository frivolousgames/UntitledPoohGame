using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishPooler : ObjectPool
{
    public static FishPooler instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        CreatePool();
    }
}
