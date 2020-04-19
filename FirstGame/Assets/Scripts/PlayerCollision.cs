using UnityEngine;

public class PlayerCollision : MonoBehaviour{

    
    public Rigidbody self;
    public PlayerMovement movement;
    public Vector3 obstSize; //Stores x, y, z values for obstacle
    public float pivotDistance;
    public Vector3 pivot;

    public HUD_script hud;

    // public float pieceL;
    // public float pieceW;
    // public float pieceH;

    void Start(){
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Collider>().tag == "key_piece"){
            Debug.Log("Key touched");
            hud.showMsg = true; 
        }
    }
    void OnTriggerExit(Collider other)
    {
         if(other.GetComponent<Collider>().tag == "key_piece"){
                hud.showMsg = false; 
            }
    }
}
