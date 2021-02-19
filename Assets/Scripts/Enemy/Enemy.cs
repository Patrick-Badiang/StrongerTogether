using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health;
    
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        // anim.SetBool("isFollowing", true);
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0){

        }
        
    }

    public void TakeDamage(int damage){
        health -= damage;
        anim.SetTrigger("hit");
        Debug.Log("Taken " + damage + (" damage."));
    }

    public void Following(bool follow){
        anim.SetBool("following", follow);
    }

    public void Attack(){
        anim.SetTrigger("attack");
    }

}
