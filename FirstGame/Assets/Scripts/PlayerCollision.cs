using UnityEngine;

public class PlayerCollision : MonoBehaviour{

    public HUD_script hud;

    private bool equipObj = false;
    private GameObject key;
    // public float pieceL;
    // public float pieceW;
    // public float pieceH;

    void Update()
    {
        if(equipObj && Input.GetKeyDown(KeyCode.E)){
            
            Debug.Log("E Key pressed ");
            Destroy(key);
            hud.addItem();
            equipObj = false;
            hud.equipMessage(equipObj);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "key_piece"){

            Debug.Log("Key touched");
            equipObj = true;
            key = other.gameObject;
            hud.equipMessage(equipObj); 
        }
    }
 
    void OnTriggerExit(Collider other)
    {
         if(other.tag == "key_piece"){
                equipObj = false;
                hud.equipMessage(equipObj);
            }
    }
}
