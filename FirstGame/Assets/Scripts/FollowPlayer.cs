using UnityEngine;

public class FollowPlayer : MonoBehaviour{

    public Transform player; //Transform component 
    public Vector3 offset; //Stores x , y and z value

    void Update(){
       // transform.position = player.position; //player var is mapped to Cube obj transform component
            transform.position = player.position + offset; 
            //camera pos x + player pos x, camera pos y + player pos y, camera pos z + player pos z 

    }
}
 