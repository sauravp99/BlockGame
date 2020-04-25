using UnityEngine;

public class PlayerCollision : MonoBehaviour{

    public HUD_script hud;

    private bool pickUpObj = false;
    private bool picked = false;
    private GameObject lastItem;

    public Transform pickDes;


    void Update()
    {
        checkKeyPress();   
        moveObjPicked();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 10){

            // Debug.Log("Key touched");
            lastItem = other.gameObject;
            pickUpObj = true;
            hud.equipMessage(1,true); 
        }
    }
 
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer == 10){

            // Debug.Log("Key touched");
            pickUpObj = false;
            hud.equipMessage(1,false); 
        }

    }

    void checkKeyPress(){

        if(pickUpObj && Input.GetKeyDown(KeyCode.E)){

           if(lastItem.tag == "key_piece"){

                // Debug.Log("E Key pressed ");
                Destroy(lastItem);
                hud.addItem();
                hud.equipMessage(1,false);
           }
           if(lastItem.tag == "chair_pick"){

                picked = true;
                
            }
        }
    }
    void moveObjPicked(){
        if(picked){
            
            lastItem.transform.position = pickDes.position; 
            hud.equipMessage(2,true);
            if(Input.GetKeyDown(KeyCode.F)){
                picked = false;
                hud.equipMessage(2,false);
            }
        }
    }
}
