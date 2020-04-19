using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD_script : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject inventory;

    public bool showMsg = true;

    // Update is called once per frame
    void Update()
    {
        equipMessage();
    }

    public void equipMessage(){
        if(showMsg){

            inventory.SetActive(true);
        }else{

            inventory.SetActive(false);
        }
    }
}
