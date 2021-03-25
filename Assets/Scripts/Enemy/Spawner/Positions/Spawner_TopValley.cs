using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_TopValley : Spawner
{
    void Start()
    {
        StartCoroutine(EnemySpawn(-25, 39, 9, 25));
    }


}
