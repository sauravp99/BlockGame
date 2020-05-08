using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

    public HUD_script hud;
    public MatPropertyBlock pBlock;
    private bool interactWithObj = false;
    private bool picked = false;
    public bool bucketEquipped = false;
    private GameObject collidedItem;    
 
    public Transform pickDes;

    public string heyDickHead() {

        return "Fix this shit bro";

    }
    void Update() {

        checkKeyPress();   
        moveObjPicked();
    }
    void OnTriggerEnter(Collider other) {

        if (other.gameObject.layer == 10) {

            if (other.gameObject.tag != "plants") {

                interactWithObj = true;                
                collidedItem = other.gameObject;
                hud.equipMessage("Press E to pick up", true);
            }

            }
        }

        // if (collidedItem.tag == "spring" && bucketEquipped) {
            
        //     hud.equipMessage("Press E pour water", true); 
        // }
 
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
                
                print(bucketEquipped);
                picked = true;
                bucketEquipped = true;
            }
            
            interactWithObj = false;
        }
    }

    public void colorPlant() {

        pBlock.colorChange = true;

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