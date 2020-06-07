using UnityEngine;

public class water_well : MonoBehaviour {
    
    public GameObject bucket;
    public GameObject player;
    public HUD_script hud;
    void Update() {

        
    }

    private void OnTriggerEnter(Collider other) {
        
        if (other.gameObject.tag == "Player") {
            
            checkCollided();
        }
    }
    void checkCollided() {

        if (player.GetComponent<PlayerCollision>().bucketEquipped) {
            
            hud.equipMessage("Press E to fill bucket", true); 
        }
    }
}
