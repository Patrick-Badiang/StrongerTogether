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
    public Animator playerAnim;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   

        movement = new Vector2 (0, 0);

    }

    // Update is called once per frame
    void Update()
    { 

    
        move_x = Input.GetAxis("Horizontal");
        playerAnim.SetFloat("Speed", Mathf.Abs(move_x));
           
        move_y = Input.GetAxis("Vertical");

        movement = new Vector2 (move_x * mvmt_speed, move_y * mvmt_speed);


    }


    void FixedUpdate(){

        rb.MovePosition(rb.position + movement);

    }
    




   

}
 