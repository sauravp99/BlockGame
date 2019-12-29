using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedboost : MonoBehaviour{
    public PlayerMovement movement;
    // Start is called before the first frame update
    
    private void OnTriggerEnter(Collider other) {
            
            if(other.GetComponent<Collider>().tag == "Player"){
                movement.forwardForce = 3000f;
                movement.jumpForce = 4f;
            }
    }
}
