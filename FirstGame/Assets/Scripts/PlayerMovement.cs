// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    
    public Rigidbody rb;
    public float sidewaysForce = 200f;
    public float jumpForce = 3f;
    public bool touchingFloor = false;
    public float rotateSpeed = 2000f;

    void Update(){
        stopRotation();
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
        float speed = 5f; 
        transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * rotateSpeed, 0);

        transform.Translate(0, 0, Input.GetAxis("Vertical") * Time.deltaTime * speed);

        if(Input.GetKey("space") && touchingFloor){ //If the obj is touching the floor, then jump
            rb.AddForce(0,jumpForce,0, ForceMode.Impulse);
            touchingFloor = false; //After jump, obj is not touchingFloor hence false
        }
    }
}
