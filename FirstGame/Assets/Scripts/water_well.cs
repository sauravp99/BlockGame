using UnityEngine;

public class water_well : MonoBehaviour {
    
    public GameObject bucket;
    public GameObject player;
    public HUD_script hud;

    void OnTriggerEnter(Collider other) {
        
        if (other.gameObject.tag == "Player") {
            
            if (player.GetComponent<PlayerCollision>().bucketEquipped) {

                print("Display message");
                bucket.GetComponent<interactPlants>().fillWater();
            }
        }
    }
}
