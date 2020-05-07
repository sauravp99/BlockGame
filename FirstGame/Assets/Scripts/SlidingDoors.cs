// using UnityEngine;

// public class SlidingDoors : MonoBehaviour {
    
//     [SerializeField] private Animator animControllerR, animControllerL;
    
//         // private void
//     private void OnTriggerEnter(Collider other) {
        
//         if (other.GetComponent<Collider>().tag == "Player") {
//             animControllerL.SetBool("openDoor", true);
//             animControllerR.SetBool("openDoor", true);
//             // animControllerL.Play("lDoorOpen"); 
//         }
//     }
//     private void OnTriggerExit(Collider other) {

//         if (other.GetComponent<Collider>().tag == "Player") {
//             animControllerL.SetBool("openDoor", false);
//             animControllerR.SetBool("openDoor", false);
//         }
//     }
// }
