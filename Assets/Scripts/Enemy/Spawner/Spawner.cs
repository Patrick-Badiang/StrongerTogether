using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    int enemyCount;

    public GameObject[] enemyPF;
    int xPos;
    int yPos;

   public IEnumerator EnemySpawn(int x1, int y1,int x2, int y2)
    {
        while(enemyCount < 5){
            int randEnemy = Random.Range(0, enemyPF.Length);

            xPos= Random.Range(x1, y1);
            yPos= Random.Range(x2 , y2);
            Instantiate(enemyPF[randEnemy], new Vector2(xPos, yPos), transform.rotation);
            yield return new WaitForSeconds(2f);
            enemyCount += 1;

        }
    }
}
