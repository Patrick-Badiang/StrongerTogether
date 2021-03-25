using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner_Left : Spawner
{
    
    void Start()
    {
        StartCoroutine(EnemySpawn(-55, -27, -30, 4));
    }

}
