﻿using UnityEngine;

public class plant_trigger : MonoBehaviour {

    public HUD_script hud;
    private bool waterReady = false;
    public GameObject bucket;

    void Update() {
    
        
    }
    private void OnTriggerEnter(Collider other) {

        GameObject col = other.gameObject;

        if(col.tag == "Player" && col.GetComponent<PlayerCollision>().bucketEquipped) {

            hud.equipMessage("Press E to water plant", true);

            // if(Input.GetKeyDown(KeyCode.E)) {

                print("Water plant");
                bucket.GetComponent<interactPlants>().pourWater();
                col.GetComponent<PlayerCollision>().colorPlant(tag);
            // }                
        }
    }
    private void waterPlant() {
        
        if(waterReady) {

            hud.equipMessage("Press E to water plant", true);
        }

        hud.equipMessage("", false);
    }
}
