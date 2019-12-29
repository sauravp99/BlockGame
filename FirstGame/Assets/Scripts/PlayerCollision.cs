using UnityEngine;

public class PlayerCollision : MonoBehaviour{

    public Rigidbody self;
    public PlayerMovement movement;
    public Vector3 obstSize; //Stores x, y, z values for obstacle
    public float pivotDistance;
    public Vector3 pivot;
    // public float pieceL;
    // public float pieceW;
    // public float pieceH;

    void OnCollisionEnter(Collision obstacle) {

        if(obstacle.collider.tag == "Obstacle"){
            print(obstacle.collider.tag); //Displays wall
            self.AddForce(0,0,-500); //When hit: pushes Player obj back 
            movement.forwardForce = 0;
            movement.sidewaysForce = 0;
        }
    }
}
