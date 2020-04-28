﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    float rotationSpeed = 1;
    public Transform Target, Player;
    float mouseX, mouseY;
    public Transform Obstruction;
    // float zoomSpeed = 2f;
    
    void Start() {

        Obstruction = Target;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate() {
    
        CamControl();
    }
    

    void CamControl() {

        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        transform.LookAt(Target);

        if (Input.GetKey(KeyCode.LeftShift)) {

            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            
        } else {

            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            Player.rotation = Quaternion.Euler(0, mouseX, 0);
        }
    }
}
