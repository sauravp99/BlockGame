using UnityEngine;
public class TPCameraFollow : MonoBehaviour{

    public Transform player;
    public float distanceFromObject = 8f;
    public Vector3 offset;

    void Update(){

        Vector3 lookOnObject = player.position - transform.position;

        transform.forward = lookOnObject.normalized;
        
        Vector3 playerLastPosition = player.position - lookOnObject.normalized * distanceFromObject;
        
        playerLastPosition.y = player.position.y + distanceFromObject/4;
        
        transform.position = playerLastPosition;    
    }
}