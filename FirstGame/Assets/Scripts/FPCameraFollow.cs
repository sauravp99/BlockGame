using UnityEngine;

public class FPCameraFollow : MonoBehaviour{
    
    public Transform player;
    
    public float moveSensitivity = 100f;
    
    public float mouseX;
    public float mouseY;

    private float rotX = 0f;
    private float rotY = 0f;
    void Start(){

            Vector3 rotation = transform.localRotation.eulerAngles; //Get the euler angles of the player
            rotX = rotation.x;
            rotY = rotation.y;

            Cursor.lockState = CursorLockMode.Locked;
    }
    void Update(){

        transform.position = player.position; //player var is mapped to P1 obj transform component

        mouseX = Input.GetAxis("Mouse X") * moveSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * moveSensitivity * Time.deltaTime;
    
        //We decrease the rotation so that camera isn't inverted
        rotX -= mouseY;
        rotY += mouseX;
       
        rotX = Mathf.Clamp(rotX,-90,90); //Prevent camera's X rotattion to exceed 90

        transform.rotation = Quaternion.Euler(rotX,rotY, 0f);
    }

}
 