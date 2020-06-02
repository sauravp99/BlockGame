using UnityEngine;

public class plant_trigger : MonoBehaviour {

    public HUD_script hud;
    bool waterReady = false;
    public GameObject bucket;
    GameObject col;
    bool readyToInteract;

    void Update() {

        checkKeyPress();
    }
    void OnTriggerEnter(Collider other) {

        col = other.gameObject;

        if(col.tag == "Player" && col.GetComponent<PlayerCollision>().bucketEquipped) {

            readyToInteract = true;
            hud.equipMessage("Press E to water plant", true);
                           
        }
    }

    void OnTriggerExit(Collider other) {
        
        readyToInteract = false;
    }

    void checkKeyPress() {

        if (readyToInteract && Input.GetKeyDown(KeyCode.E)) {

                print("Water plant");
                if (col.GetComponent<PlayerCollision>().colorPlant(tag)) {

                    bucket.GetComponent<interactPlants>().pourWater();
                }
            }    
    }

    void waterPlant() {
        
        if(waterReady) {

            hud.equipMessage("Press E to water plant", true);
        }

        hud.equipMessage("", false);
    }
}
