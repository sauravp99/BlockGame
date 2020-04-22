using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    
    public Rigidbody rb;
        public float jumpForce = 1f;
    public float Speed = 0.5f;

    public float gravity = -9.81f;
    public bool touchingFloor = false;
    public CharacterController controller;

    public Transform groundObj;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;

    void Update(){
        // stopRotation();
        movement();
        fallVelocity();
        groundCheck();
    }

    void OnCollisionStay(Collision obstacle) { //Takes in arg if we need to check which obj it is colliding to
        if(obstacle.collider.tag == "Platform"){
            Debug.Log("Touching floor");
            touchingFloor = true;
        }
    }
    void stopRotation(){
        if(touchingFloor == true){
            rb.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;
        }
    }

    void movement(){
        
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        
        Vector3 move = transform.right * hor + transform.forward * ver;

        controller.Move(move * Speed * Time.deltaTime);

        if(Input.GetKey("space") && touchingFloor){ //If the obj is touching the floor, then jump
           velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            // rb.AddForce(0,jumpForce,0, ForceMode.Impulse);
            // touchingFloor = false; //After jump, obj is not touchingFloor hence false
        }
    }

    void fallVelocity(){
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
    
    void groundCheck(){
        touchingFloor = Physics.CheckSphere(groundObj.position,groundDistance,groundMask);
        
        if(touchingFloor && velocity.y < 0){
            velocity.y = -2f;
        }
    }
}

// ﻿using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerMovement : MonoBehaviour {

//     public Rigidbody rb;
// //     public float sidewaysForce = 200f;
// //     public float Speed;
//     public bool touchingFloor = false;
// //     public float rotateSpeed = 2000f;

// 	public float speed = 4.0f;
// 	public float gravity = -9.8f;

//     public float jumpForce = 3f;

// 	private CharacterController _charCont;

// 	// Use this for initialization
// 	void Start () {
// 		_charCont = GetComponent<CharacterController> ();
// 	}
	

//     void OnCollisionStay(Collision obstacle) { //Takes in arg if we need to check which obj it is colliding to
//         if(obstacle.collider.tag == "Platform"){
//             touchingFloor = true;
//     }
//     }
//     void stopRotation(){
//         if(touchingFloor == true){
//             rb.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;
            
//         }
//     }

// 	// Update is called once per frame
// 	void Update () {
//         stopRotation();
// 		float deltaX = Input.GetAxis ("Horizontal") * speed;
// 		float deltaZ = Input.GetAxis ("Vertical") * speed;
// 		Vector3 movement = new Vector3 (deltaX, 0, deltaZ);
// 		movement = Vector3.ClampMagnitude (movement, speed); //Limits the max speed of the player

//         // movement.y = gravity;

// 		movement *= Time.deltaTime;		//Ensures the speed the player moves does not change based on frame rate
// 		movement = transform.TransformDirection(movement);
// 		_charCont.Move (movement);

//         if(Input.GetKey("space") && touchingFloor){ //If the obj is touching the floor, then jump
//              rb.AddForce(0,jumpForce,0, ForceMode.Impulse);
//              touchingFloor = false; //After jump, obj is not touchingFloor hence false
//          }
// 	}
// }