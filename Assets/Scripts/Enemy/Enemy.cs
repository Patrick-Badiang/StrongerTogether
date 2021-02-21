using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{

    public EnemyAI enemyAI;                            //Reference to script
    public DamageType damageType;                      //Drag in the Scriptable Object
    public Animator anim;                              //Animator is MidSpiritsGFX
    public DamageType[] vulnerableDamageTypes;         //Drag in the Scriptable Objects that have the correct name for vulnerability
    public Transform attackPos;                        //Drag in Children
    public LayerMask whatIsPlayer;                     //Layer of Player

    public int health;                                 //Health
    public int damage;                                 //Amount of damage you want enemy to do
    
    public bool isKilled;                              //Allows scripts not to error when is destroyed
    public bool canAttack;

    public float deathDelay;                            //Gives time for Death Anims
    public float attackDelay;                           //Gives time for Attack Anim

    public float attackRange = 1f;                      //Affects the Gizmos
    private float timeBtwAttack;                     
    public float startTimeBtwAttack = 3f;               //Makes it so the enemy can only attack every set amount of time 
                                                        // "startTimeBtwAttack = 3f" Allows the enemy attack ever 3 seconds

    void Start()
    {
        isKilled = false;
    }

    void Update()
    {
        
        if((health <= 0) && !isKilled)
        {
            enemyAI.Kill();
            StartCoroutine(Die(deathDelay));
            isKilled = true;
        }else 
            if((timeBtwAttack <= 0) && canAttack)
                {
                    timeBtwAttack = startTimeBtwAttack;

                    StartCoroutine(DoDamage(attackDelay));
                }else{
                    timeBtwAttack -= Time.deltaTime;
                }
        
    }

    public void TakeDamage(int damage, DamageType damageType){

        if(damageType != null){
        
            for (int i = 0; i < vulnerableDamageTypes.Length; i++){
                damage *= 2;
            }
        }
                
        health -= damage;
        
        anim.SetTrigger("hit");


    }

    public void CanAttack(bool passedValue){
        canAttack = passedValue;
    }

    public void Attack(){
        
            //then you can atack            
               StartCoroutine(DoDamage(attackDelay));
               Debug.Log("Attacking");
        
    }
    public void Following(bool follow){
        anim.SetBool("following", follow);
    }

    IEnumerator Die(float deathdelay){
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

    public IEnumerator DoDamage(float attackDelay){
        
        Collider2D[] playerToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsPlayer);
                for(int i = 0; i < playerToDamage.Length; i++){
                    if(playerToDamage != null){
                    playerToDamage[i].GetComponent<Player>().TakeDamage(damage);
                    }
                }
                anim.SetBool("attack", true);

        yield return new WaitForSeconds(attackDelay);

        anim.SetBool("attack", false);

        yield return new WaitForSeconds(startTimeBtwAttack);

    }

}
