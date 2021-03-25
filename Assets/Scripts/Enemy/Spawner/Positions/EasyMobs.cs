using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyMobs : Spawner
{
    
    
    void Start()
    {
        StartCoroutine(EnemySpawn(-25, 40, -32, 5));
    }

}
