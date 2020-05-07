using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    
    public Rigidbody rb;
    public float jumpForce = 1f;
    public float Speed = 0.5f;
    public float gravity = -9.81f;
    public bool touchingFloor = false;
    public CharacterController controller;
    public Transform groundObj;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public LayerMask itemMask;
    Vector3 velocity;

    void Update() {

        // stopRotation();
        movement();
        fallVelocity();
        groundCheck();
    }

    // void OnCollisionStay(Collision obstacle) { //Takes in arg if we need to check which obj it is colliding to
        
    //     if (obstacle.gameObject.layer == 9 && obstacle.gameObject.layer == 10) {
            
    //         Debug.Log("Touching floor");
    //         touchingFloor = true;
    //     }
    // }

    // void stopRotation() {

    //     if(touchingFloor == true) {

    //         rb.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;
    //     }
    // }

    void movement() {
        
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        
        Vector3 move = transform.right * hor + transform.forward * ver;

        controller.Move(move * Speed * Time.deltaTime);

        if (Input.GetKey("space") && touchingFloor) { //If the obj is touching the floor, then jump
           
           velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            // rb.AddForce(0,jumpForce,0, ForceMode.Impulse);
            // touchingFloor = false; //After jump, obj is not touchingFloor hence false
        }
    }

    void fallVelocity() {

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
    
    void groundCheck() {
        
        if (Physics.CheckSphere(groundObj.position,groundDistance,groundMask) || Physics.CheckSphere(groundObj.position,groundDistance,itemMask)) {

            touchingFloor = true;
            
            if (touchingFloor && velocity.y < 0) {

                velocity.y = -2f;
            }

        } else {

            touchingFloor = false;
        }
        
    }
}
