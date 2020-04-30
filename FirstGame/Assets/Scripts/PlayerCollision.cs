using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public HUD_script hud;
    private bool pickUpObj = false;
    private bool picked = false;
    private GameObject collidedItem;    
    public Material leafMat;
    public Transform pickDes;

    void Update() {

        checkKeyPress();   
        moveObjPicked();
    }
    void OnTriggerEnter(Collider other) {

            // :)

        if (other.gameObject.layer == 10) {

            collidedItem = other.gameObject;
            Debug.Log("Key touched");
            // collidedItem = collidedItem;
            pickUpObj = true;
            hud.equipMessage(1,true); 
            
            if (collidedItem.tag == "plants") {

                print("Change color");
                // SetColor("nature_leaves",Color.red);
                Material copiedMat = new Material(leafMat);
                copiedMat.SetColor("_Color",Color.blue);
                collidedItem.GetComponent<Renderer>().materials[2] = null;
                print(collidedItem.GetComponent<Renderer>().materials[2]);
                // collidedItem.GetComponent<Renderer>().material.shader.Find("nature_leaves");
            }
        }
        
    }
 
    void OnTriggerExit(Collider other) {

        if (other.gameObject.layer == 10) {

            // Debug.Log("Key touched");
            pickUpObj = false;
            hud.equipMessage(1,false); 
        }

    }

    void checkKeyPress() {

        if (pickUpObj && Input.GetKeyDown(KeyCode.E)) {

           if (collidedItem.tag == "key_piece") {

                // Debug.Log("E Key pressed ");
                Destroy(collidedItem);
                hud.addItem();
                hud.equipMessage(1,false);
           }
           if (collidedItem.tag == "chair_pick") {

                picked = true;
                
            }
        }
    }
    void moveObjPicked() {
        if (picked) {

            collidedItem.transform.position = pickDes.position; 
            hud.equipMessage(2,true);

            if (Input.GetKeyDown(KeyCode.F)) {

                picked = false;
                hud.equipMessage(2,false);
            }
        }
    }
}
