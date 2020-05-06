using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public HUD_script hud;
    public MatPropertyBlock pBlock;
    private bool pickUpObj = false;
    private bool picked = false;
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
            Debug.Log("Key touched");
            // collidedItem = collidedItem;
            pickUpObj = true;
            hud.equipMessage(1,true); 
            
            if (collidedItem.tag == "plants") {
                
                pickUpObj = true;
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
            if (collidedItem.tag == "plants") {

                pBlock.colorChange = true;
            }
        }
    }
    void moveObjPicked() {
        if (picked) {

            collidedItem.transform.position = pickDes.position; 
            collidedItem.GetComponent<Rigidbody>().freezeRotation = true;
            hud.equipMessage(2,true);

            if (Input.GetKeyDown(KeyCode.F)) {

                picked = false;
                hud.equipMessage(2,false);
            }
        }
    }
}
