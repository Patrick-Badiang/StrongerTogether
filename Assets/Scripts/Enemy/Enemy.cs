using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : Interactions
{
    public int damage;

    public float timeBtwAttack = 5f;
    public float startTimeBtwAttack = 3f;
    public float attackDelay;  
    public bool isAlive = true;
     
    
    void Start()
    {
        healthBar.SetMaxHealth(health);
        isKilled = false;
    }

    void Update()
    {
        
        if((health <= 0) && !isKilled)
        {
            Kill();
            StartCoroutine(Die(deathDelay, 1f));
            isKilled = true;
        }else 
            if((timeBtwAttack <= 0) && canAttack)
                {
                    timeBtwAttack = startTimeBtwAttack;

                    StartCoroutine(DoDamage(attackDelay, damage, startTimeBtwAttack));
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
        healthBar.SetHealth(health);
        anim.SetTrigger("hit");


    }

    public void CanAttack(bool passedValue){
        canAttack = passedValue;
    }

    public void Attack(){
        
            //then you can atack            
               StartCoroutine(DoDamage(attackDelay, damage, startTimeBtwAttack));
               Debug.Log("Attacking");
        
    }
    public void Following(bool follow){
        anim.SetBool("following", follow);
    }

    public void Kill(){
        isAlive = false;
    }
}
