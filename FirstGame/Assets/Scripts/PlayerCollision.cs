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
            //movement.Speed = 0;
            //self.AddForce(0,0,-70); //When hit: pushes Player obj back 
            //movement.Speed = 10;
            // movement.Speed = 10;
            // movement.forwardForce = 0;
            //movement.sidewaysForce = 0;
        }
        // while(obstacle.collider.tag == "Obstacle"){
        //     movement.Speed = 0;
        //     self.AddForce(0,0,-100);
        // }
    }
}
