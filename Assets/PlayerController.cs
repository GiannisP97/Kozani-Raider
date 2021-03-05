using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;   
    public float jumpHeight;
    public characterController2D characterController2D;

    private Rigidbody2D rb2d;  
    private bool jump = false;



    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("Space Pressed");
            jump = true;
        }

        

    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        //Store the current horizontal input in the float moveHorizontal.
        Input.GetButtonDown("Jump");


        float Horizontal_movement = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;

        rb2d.velocity = new Vector2(Horizontal_movement,0f);
        
        if(jump){
            rb2d.AddForce(new Vector2(0f,jumpHeight));
            jump = false;
        }
       
    }


}

