using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner_Left : MonoBehaviour
{
     
    [SerializeField]
    int enemyCount;

    public GameObject[] enemyPF;
    int xPos;
    int yPos;
    
    
    void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {
        while(enemyCount < 5){
            int randEnemy = Random.Range(0, enemyPF.Length);

            xPos= Random.Range(-55, -27);
            yPos= Random.Range(-30, 4);
            Instantiate(enemyPF[randEnemy], new Vector2(xPos, yPos), transform.rotation);
            yield return new WaitForSeconds(2f);
            enemyCount += 1;

        }
    }
}
