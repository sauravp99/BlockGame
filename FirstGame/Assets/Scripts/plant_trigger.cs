using UnityEngine;

public class plant_trigger : MonoBehaviour {


    void Update() {
    
        
    }
    private void OnTriggerEnter(Collider other) {
        
        if (other.gameObject.tag == "Player" ) {

            Debug.Log("Collided with player");

            PlayerCollision col = other.gameObject.GetComponent<PlayerCollision>();

            if (col.bucketEquipped) {

                Debug.Log("Color plant");

                col.colorPlant();
                
            }
            
            
        }
        
    }
}
