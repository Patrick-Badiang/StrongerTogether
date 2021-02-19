using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    
    public Transform playerPF;

    public Enemy anims;

    public float timeBtwAttack = 1f;
    public float startTimeBtwAttack = 3f;
    public int damage;
    public Transform attackPos;
    public LayerMask whatIsPlayer;

    public float speed= 200f;
    public float nextWaypointDistance = 3f;
    public float range = 2f;
    public float attackRange = 1f;

    public Transform enemyGFX;
    public Animator enemyAnim;


    Path path;
    int currentWaypoint = 0;
    // bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    void Start(){
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        
        InvokeRepeating("UpdatePath", 0f, 2f);

    }

    void Update(){
    
    }

    void UpdatePath(){

        float targetDistance = Vector2.Distance(playerPF.position, rb.position);
        if (targetDistance <=range){
        if(seeker.IsDone())
        anims.Following(true);

        float withinRange = Vector2.Distance(playerPF.position, rb.position);
        if (withinRange <= attackRange){
            anims.Attack();
            Collider2D[] playerToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsPlayer);
            timeBtwAttack = startTimeBtwAttack;
                for(int i = 0; i < playerToDamage.Length; i++){
                    Debug.Log("attack - enemy");
                    playerToDamage[i].GetComponent<Enemy>().TakeDamage(damage);

                }
        }
        seeker.StartPath(rb.position, playerPF.position, OnPathComplete);

        }else{
            anims.Following(false);
        }
    }

    void OnPathComplete(Path p){
        if (!p.error){
            path = p;
            currentWaypoint = 0;
        }
    }

    void FixedUpdate(){
        if(path == null) return;

        if(currentWaypoint >= path.vectorPath.Count){
            // reachedEndOfPath = true;
            return;
        } else{
            // reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        
        if(distance < nextWaypointDistance){
            currentWaypoint++;
        }

        if(force.x >= 0.01f){
            enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
        }else if (force.x <= -0.01f){
            enemyGFX.localScale = new Vector3 (1f, 1f, 1f);
        }

    }

    

}

