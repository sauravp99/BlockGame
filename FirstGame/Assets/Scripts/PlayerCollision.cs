using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

    public HUD_script hud;
    public MatPropertyBlock pBlock;
    private bool interactWithObj = false;
    private bool picked = false;
    private bool bucketEquipped = false;
    private GameObject collidedItem;    
 
    public Transform pickDes;


    void Update() {

        checkKeyPress();   
        moveObjPicked();
    }
    void OnTriggerEnter(Collider other) {

        if (other.gameObject.layer == 10) {

            interactWithObj = true;

            if (other.gameObject.tag == "plants") {
                
                if (bucketEquipped) {

                    hud.equipMessage("Press E to water plants", true); 
                }
            
            } else {

                collidedItem = other.gameObject;
                hud.equipMessage("Press E to pick up", true); 
            }
        }

        // if (collidedItem.tag == "spring" && bucketEquipped) {
            
        //     hud.equipMessage("Press E pour water", true); 
        // }
        
    }
 
    void OnTriggerExit(Collider other) {

        if (other.gameObject.layer == 10) {

            interactWithObj = false;
            hud.equipMessage("", false); 
        }
    }

    void checkKeyPress() {

        if (interactWithObj && Input.GetKeyDown(KeyCode.E)) {

            if (collidedItem.tag == "key_piece") {

                Destroy(collidedItem);
                hud.addItem();
                // hud.equipMessage("Key found!", true);
                // StartCoroutine(waiter());
                hud.equipMessage("", false);
            }

            if (collidedItem.tag == "chair_pick") {

                picked = true;

            }
            
            if (collidedItem.tag == "bucket") {
                
                picked = true;
                bucketEquipped = true;
            }

            if (collidedItem.tag == "plants") {
                
                if (bucketEquipped) {
                    
                    pBlock.colorChange = true;
                }
            }
            interactWithObj = false;
        }
    }
    void moveObjPicked() {
        
        if (picked) {
            
            collidedItem.transform.position = pickDes.position; 
            collidedItem.GetComponent<Rigidbody>().freezeRotation = true;
            hud.equipMessage("Press F to drop", true);

            if (Input.GetKeyDown(KeyCode.F)) {

                bucketEquipped = false;
                picked = false;
                hud.equipMessage("",false);
            }
        }
    }
    // private IEnumerator waiter() {

    //     yield return new WaitForSeconds(15);
    // }
}


// print("Change color");
                // // SetColor("nature_leaves",Color.red);
                // Material copiedMat = new Material(leafShad);
                // // Material.Instantiate(leafMat);
                // copiedMat.SetColor("_Color",Color.blue);

                // int leng = collidedItem.GetComponent<Renderer>().materials.Length;
                // Material[] matArr = new Material[leng];
 
                // for (int i = 0; i < leng; i++) {
                    
                //     Material temp = collidedItem.GetComponent<Renderer>().materials[i]; 

                //     if (i == 2) {
                        
                //         matArr[i] = copiedMat;

                //     } else {

                //         matArr[i] = temp; 
                //     }
                //     print(matArr[i]);
                // }

                // collidedItem.GetComponent<Renderer>().material.shader.Find("nature_leaves");