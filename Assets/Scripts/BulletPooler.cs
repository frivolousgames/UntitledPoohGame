using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPooler : ObjectPool
{
    public static BulletPooler instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        CreatePool();
    }
}
