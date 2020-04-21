using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droid_script : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        followPlayer();
    }

    void followPlayer(){

        // transform.position = player.position + new Vector3(0.8f,0.2f,0.8f);
        Vector3 relativePos = (player.position + new Vector3(0, 1.5f, 0)) - transform.position;
         Quaternion rotation = Quaternion.LookRotation(relativePos);
         
         Quaternion current = transform.localRotation;
         
         transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime);
         transform.Translate(0, 0, 3 * Time.deltaTime);
    }
}
