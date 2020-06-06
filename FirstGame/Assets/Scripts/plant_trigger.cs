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


        if(other.gameObject.tag == "Player" && other.gameObject.GetComponent<PlayerCollision>().bucketEquipped) {
            
            col = other.gameObject;

            readyToInteract = true;
            hud.equipMessage("Press E to water plant", true);
                           
        }
    }

    void OnTriggerExit(Collider other) {
        
        readyToInteract = false;
    }

    void checkKeyPress() {

        if (readyToInteract && Input.GetKeyDown(KeyCode.E)) {

                if (bucket.GetComponent<interactPlants>().bucketEmpty == false) {
                    
                    print("Water plant");
                    col.GetComponent<PlayerCollision>().colorPlant(tag);
                    bucket.GetComponent<interactPlants>().pourWater();
                
                } else {
                    
                    print("Already watered");
                }
            }    
    }

    // void waterPlant() {
        
    //     if(waterReady) {

    //         hud.equipMessage("Press E to water plant", true);
    //     }

    //     hud.equipMessage("", false);
    // }
}
