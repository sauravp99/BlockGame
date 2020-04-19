using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD_script : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject msgPanel;
    
    private int keyPieces = 4;
    // public bool showMsg = true;

    // Update is called once per frame
    void Update()
    {

    }

    private void colorKeyParts(){

        if(keyPieces == 1){
            //Color slot 1
        }else if(keyPieces == 2){
            
        }else if(keyPieces == 3){

        }else{
            //Color slot 4
            // EnableDialog("Well well well...looks like you got the key")
            //Disable keyslots
        }

    }

    public void equipMessage(bool status){
        if(status){

            msgPanel.SetActive(true);
        }else{

            msgPanel.SetActive(false);
        }
    }
    public void addItem(){
            keyPieces++;
            colorKeyParts();
    }
}
