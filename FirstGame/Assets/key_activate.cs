using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key_activate : MonoBehaviour {

    private Color change_color = new Color(1, 0.92f, 0.016f, 1); 
    MeshRenderer myRenderer;

    void Start() {

        myRenderer = GetComponent<MeshRenderer>();
        myRenderer.material.color = change_color;    
    }
}
