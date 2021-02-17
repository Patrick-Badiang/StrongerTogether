using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float mvmt_speed;
    public float move_x;
    public float move_y;

    private Rigidbody2D rb;
    private Vector2 movement;
    private float someScale;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
        someScale = transform.localScale.x; // assuming this is facing right
        movement = new Vector2 (0, 0);

    }

    // Update is called once per frame
    void Update()
    { 

        move_x = Input.GetAxis("Horizontal");        
        move_y = Input.GetAxis("Vertical");
        movement = new Vector2 (move_x * mvmt_speed, move_y * mvmt_speed);
    }


    void FixedUpdate(){

        rb.MovePosition(rb.position + movement);
        FlipPlayer();
        
    }
    
    /*
    Flip Player on Y-axis dependant on x move_x value
    */
    void FlipPlayer(){

        
        if(move_x < 0){
            transform.localScale = new Vector2(-someScale, transform.localScale.y);
        } else if(move_x > 0){
            transform.localScale = new Vector2(someScale, transform.localScale.y);
        }
      
    }




   

}
 