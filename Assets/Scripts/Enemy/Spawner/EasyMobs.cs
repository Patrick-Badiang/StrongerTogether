using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyMobs : MonoBehaviour
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

            xPos= Random.Range(-25, 40);
            yPos= Random.Range(-32, 5);
            Instantiate(enemyPF[randEnemy], new Vector2(xPos, yPos), transform.rotation);
            yield return new WaitForSeconds(2f);
            enemyCount += 1;

        }
    }
}
