using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public HUD_script hud;
    public MatPropertyBlock pBlock;
    private bool pickUpObj = false;
    private bool picked = false;
    private bool bucketEquipped = false;
    private GameObject collidedItem;    
    public Material leafMat;
    public Shader leafShad;
    public Transform pickDes;

    void Update() {

        checkKeyPress();   
        moveObjPicked();
    }
    void OnTriggerEnter(Collider other) {

            // :)
        if (other.gameObject.layer == 10) {

            collidedItem = other.gameObject;
            pickUpObj = true;
            hud.equipMessage("Press E to pick up", true); 
        }

        if (collidedItem.tag == "plants") {

            
        }
        
    }
 
    void OnTriggerExit(Collider other) {

        if (other.gameObject.layer == 10 || other.gameObject.tag == "plants") {

            pickUpObj = false;
            hud.equipMessage("", false); 
        }
    }

    void checkKeyPress() {

        if (pickUpObj && Input.GetKeyDown(KeyCode.E)) {

           if (collidedItem.tag == "key_piece") {

                Destroy(collidedItem);
                hud.addItem();
                hud.equipMessage("", false);
           }
           
           if (collidedItem.tag == "chair_pick") {

                picked = true;
                
            }
            if (collidedItem.tag == "plants") {

                pBlock.colorChange = true;
            }
        }
    }
    void moveObjPicked() {
        if (picked) {

            collidedItem.transform.position = pickDes.position; 
            collidedItem.GetComponent<Rigidbody>().freezeRotation = true;
            hud.equipMessage("Press F to drop",2,true);

            if (Input.GetKeyDown(KeyCode.F)) {

                picked = false;
                hud.equipMessage(2,false);
            }
        }
    }
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