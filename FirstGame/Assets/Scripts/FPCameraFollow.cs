using UnityEngine;

// public class FPCameraFollow : MonoBehaviour{
    
//     public Transform player;
    
//     public float moveSensitivity = 100f;
    
//     public float mouseX;
//     public float mouseY;

//     private float rotX = 0f;
//     private float rotY = 0f;
//     void Start(){

//             Vector3 rotation = transform.localRotation.eulerAngles; //Get the euler angles of the player
//             rotX = rotation.x;
//             rotY = rotation.y;

//             Cursor.lockState = CursorLockMode.Locked;
//     }
//     void Update(){

//         transform.position = player.position; //player var is mapped to P1 obj transform component

//         mouseX = Input.GetAxis("Mouse X") * moveSensitivity * Time.deltaTime;
//         mouseY = Input.GetAxis("Mouse Y") * moveSensitivity * Time.deltaTime;
    
//         //We decrease the rotation so that camera isn't inverted
//         rotX -= mouseY;
//         rotY += mouseX;
       
//         rotX = Mathf.Clamp(rotX,-90,90); //Prevent camera's X rotattion to exceed 90

//         transform.rotation = Quaternion.Euler(rotX,rotY, 0f);
//     }

// }

public class FPCameraFollow : MonoBehaviour {
    
    public Transform player;
    public float moveSensitivity = 100f;
    float rotX = 0f;
    void Start() {

            Cursor.lockState = CursorLockMode.Locked;
    }
    void Update() {

        float mouseX = Input.GetAxis("Mouse X") * moveSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * moveSensitivity * Time.deltaTime;
    	
        //We decrease the rotation so that camera isn't inverted
        rotX -= mouseY;
        rotX = Mathf.Clamp(rotX,-90f,90f); //Prevent camera's X rotattion to exceed 90
        
        transform.localRotation = Quaternion.Euler(rotX,0f, 0f);
		player.Rotate(Vector3.up * mouseX);
    }

}

// ﻿using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class FPCameraFollow : MonoBehaviour {

// 	public enum RotationAxis{
// 		MouseX = 1,
// 		MouseY = 2
// 	}

// 	public RotationAxis axes = RotationAxis.MouseX;

// 	public float minimumVert = -45.0f;
// 	public float maximumVert = 45.0f;

// 	public float sensHorizontal = 10.0f;
// 	public float sensVertical = 10.0f;

// 	public float _rotationX = 0;

// 	// Update is called once per frame
//      void Start(){

//             Cursor.lockState = CursorLockMode.Locked;
//     }
    
// 	void Update () {
// 		if (axes == RotationAxis.MouseX) {
// 			transform.Rotate (0, Input.GetAxis ("Mouse X") * sensHorizontal, 0);

// 		} else if (axes == RotationAxis.MouseY) {
// 			_rotationX -= Input.GetAxis ("Mouse Y") * sensVertical;
// 			_rotationX = Mathf.Clamp (_rotationX, minimumVert, maximumVert); //Clamps the vertical angle within the min and max limits (45 degrees)

// 			float rotationY = transform.localEulerAngles.y;

// 			transform.localEulerAngles = new Vector3 (_rotationX, rotationY, 0);
// 		}
// 	}
// }