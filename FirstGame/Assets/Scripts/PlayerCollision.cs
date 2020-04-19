using UnityEngine;

public class PlayerCollision : MonoBehaviour{

    
    public Rigidbody self;
    public PlayerMovement movement;
    public Vector3 obstSize; //Stores x, y, z values for obstacle
    public float pivotDistance;
    public Vector3 pivot;

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
            hud.equipMessage(false);
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
