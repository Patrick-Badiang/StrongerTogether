using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_BotValley : Spawner
{

    void Start()
    {
        StartCoroutine(EnemySpawn(-23, 39, -50, -34));
    }


}
