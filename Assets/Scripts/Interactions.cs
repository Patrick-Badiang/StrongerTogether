using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    public DamageType damageType;                      //Drag in the Scriptable Object
    public Animator anim;                              //Animator is MidSpiritsGFX
    public DamageType[] vulnerableDamageTypes;         //Drag in the Scriptable Objects that have the correct name for vulnerability

    public int health;                                 //Health
    public float attackRange;

    
    public bool isKilled;                              //Allows scripts not to error when is destroyed
    public bool canAttack;

    public float deathDelay;                            //Gives time for Death Anims
    
    public HealthBar healthBar;
    public Transform attackPos;
    public LayerMask whatIsPlayer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    // Update is called once per frame
    public IEnumerator Die(float deathdelay, float attackRange){
        anim.SetBool("die", true);


                
        yield return new WaitForSeconds(deathDelay);

        if(gameObject != null){
        Destroy(gameObject);
        }

        Collider2D[] playerToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsPlayer);
                for(int i = 0; i < playerToDamage.Length; i++){
                    if(playerToDamage != null){
                    playerToDamage[i].GetComponent<PlayerController>().GiveElement(damageType);
                    }
                }

        
    }

    public IEnumerator DoDamage(float attackDelay, float damage, float startTimeBtwAttack){
        
        Collider2D[] playerToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsPlayer);
                for(int i = 0; i < playerToDamage.Length; i++){
                    if(playerToDamage != null){
                    playerToDamage[i].GetComponent<PlayerController>().TakeDamage((float)damage);
                    }
                }
                anim.SetBool("attack", true);

        yield return new WaitForSeconds(attackDelay);

        anim.SetBool("attack", false);

        yield return new WaitForSeconds(startTimeBtwAttack);

    }

}
