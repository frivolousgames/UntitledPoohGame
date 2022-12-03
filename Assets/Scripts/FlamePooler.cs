using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamePooler : ObjectPool
{
    public static FlamePooler instance;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        CreatePool();
    }
}
