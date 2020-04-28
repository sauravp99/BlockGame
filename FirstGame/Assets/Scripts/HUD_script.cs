using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_script : MonoBehaviour {
    // Start is called before the first frame update

    public GameObject msgPanel;
    public Image slot1;
    public Image slot2;
    public Image slot3;
    public Image slot4;
    public Sprite check;
    private int keyPieces = 0;
    // public bool showMsg = true;

    // Update is called once per frame

    void Start() {

        msgPanel.SetActive(false);
    }
    private void colorKeyParts() {

        if (keyPieces == 1) {

            slot1.sprite = check;
            //Color slot 1
        } else if (keyPieces == 2) {

            slot2.sprite = check;

        } else if (keyPieces == 3) {

            slot3.sprite = check;
        
        } else {

            slot4.sprite = check;
            //Color slot 4
            // EnableDialog("Well well well...looks like you got the key")
            //Disable keyslots
        }
    }
    public void equipMessage(int choice,bool status) {

        if (status) {

            if (choice == 1) {

                msgPanel.GetComponentInChildren<Text>().text = "Press E to equip";
            
            } else if (choice == 2) {

                msgPanel.GetComponentInChildren<Text>().text = "Press F to drop";                 
            }

            msgPanel.SetActive(true);

        } else {

            msgPanel.SetActive(false);
        }
    }
    public void addItem() {
        
            keyPieces++;
            colorKeyParts();
    }
}
