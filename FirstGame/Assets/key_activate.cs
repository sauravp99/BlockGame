using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key_activate : MonoBehaviour {

    public GameObject key_trigger; 
    private Color change_color = new Color(1, 0.92f, 0.016f, 1); 
    MeshRenderer myRenderer;

    void Start() {

        myRenderer = GetComponent<MeshRenderer>();
 
    }

    void Update() {

        if (key_trigger.GetComponent<PlayerCollision>().allPlantsActive) {
            
            print("Color all keys!");
            myRenderer.material.color = change_color;    
        }

    }
}
