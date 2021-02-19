using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private float timeBtwAttack; 
    public float startTimeBtwAttack;
    public Animator playerAnim;

    public Transform attackPos;
    public float attackRange;
    public int damage;

    public LayerMask whatIsEnemy;

    void Start()
    {

    }

    void Update()
    {
        if(timeBtwAttack <= 0){
            //then you can atack
            if(Input.GetButtonDown("Fire1")){
            playerAnim.SetTrigger("attack");
            Debug.Log("attacking");
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
            timeBtwAttack = startTimeBtwAttack;
                for(int i = 0; i < enemiesToDamage.Length; i++){
                    Debug.Log("attack");
                    Debug.Log (enemiesToDamage);
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);

                }
            }
        }else{
            timeBtwAttack -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
