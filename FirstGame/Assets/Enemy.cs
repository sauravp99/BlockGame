using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 50f;

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReduceHealth(float damagePoint){
        health -= damagePoint;
        if(health <= 0f){
           Despawn(); 
        }
    }
    void Despawn(){
        Destroy(gameObject);
    }
}
