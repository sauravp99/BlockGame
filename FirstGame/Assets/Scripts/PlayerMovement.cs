// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    public Rigidbody rb;
    public float forwardForce = 1600f; //'f' to symbolize float value, prevent compiling errors
    public float sidewaysForce = 25f;
    public float jumpForce = 3f;
    public bool touchingFloor = false;

    void Update(){
        stopRotation();
    }
    void FixedUpdate(){
        movement();

    }
    void OnCollisionStay(Collision obstacle) { //Takes in arg if we need to check which obj it is colliding to
        if(obstacle.collider.tag == "Platform"){
            touchingFloor = true;
        }
    }

    void stopRotation(){
        if(touchingFloor == true){
            rb.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;
        }
    }
    
    void movement(){
        
        rb.AddForce(0,0,forwardForce * Time.deltaTime); 
        
        if(Input.GetKey("left")){
            rb.AddForce(-sidewaysForce *  Time.deltaTime,0,0, ForceMode.VelocityChange); //Add fourth parameter
            //Negative value on x axis
        }
        if(Input.GetKey("right")){
            rb.AddForce(sidewaysForce *  Time.deltaTime,0,0, ForceMode.VelocityChange); //Velocitychange ignores mass 
        }
        if(Input.GetKey("space") && touchingFloor){ //If the obj is touching the floor, then jump
                rb.AddForce(0,jumpForce,0, ForceMode.Impulse);
                touchingFloor = false; //After jump, obj is not touchingFloor hence false
        }
    }

   
}
