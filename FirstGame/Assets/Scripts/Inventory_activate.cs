using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Should rename to access canvas
public class Inventory_activate : MonoBehaviour {
    // Start is called before the first frame update
    public GameObject canvasObj;
    void Start() {

        canvasObj = GameObject.Find("Canvas");
    }

    void openMenu(){
        //TODO: Open menu on ESC button press
    }
}
