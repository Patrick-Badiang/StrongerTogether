using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner_Right : Spawner
{
        void Start()
    {
        StartCoroutine(EnemySpawn(42, 71, -30, 4));
    }
}
