using UnityEngine;

public class water_well : MonoBehaviour {
    
    public GameObject bucket;
    public GameObject player;
    public HUD_script hud;
    bool contact = false;
    public bool fillBucket = false;
    void Update() {

        checkCollided();
        
    }

    void OnTriggerEnter(Collider other) {
        
        if (other.gameObject.tag == "Player") {
            
            print("player");
            contact = true;
        }
    }
    void OnTriggerExit(Collider other) {

        if (other.gameObject.tag == "Player") {
            
            print("player out");
            contact = false;
        }    
    }
    void checkCollided() {

        hud.equipMessage("Press E to fill bucket", true); 

        if (contact && player.GetComponent<PlayerCollision>().bucketEquipped) {
            
            print("display message");
            hud.equipMessage("Press E to fill bucket", true); 
            fillBucket = true;
            bucket.GetComponent<interactPlants>().fillWater();
        }
    }
}
