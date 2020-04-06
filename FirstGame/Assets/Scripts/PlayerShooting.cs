using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public Transform shootingPoint;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }
    void Shoot(){
        
        RaycastHit cast; // Cast a raybeam 
        //When beam hits object log in console
        if(Physics.Raycast(shootingPoint.position,shootingPoint.forward,out cast, range)){
            Debug.Log(cast.transform.name);

            Enemy enemy = cast.transform.GetComponent<Enemy>();
            if(enemy != null){
                enemy.ReduceHealth(damage);
            }
        }

    }
}
