using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droid_script : MonoBehaviour {
    
    public Transform player;

    void Update() {

        orbitPlayer();
    }

    void orbitPlayer() { // For oribiting around player
        
        Vector3 relativePos = (player.position + new Vector3(0, 1.5f, 0)) - transform.position;

        Quaternion rotation = Quaternion.LookRotation(relativePos);
        Quaternion current = transform.localRotation;
        
        // Uniform angular velocity around the player
        transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime); 
        transform.Translate(0, 0, 3 * Time.deltaTime);
    }
}
