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

            GameObject laser = GameObject.Instantiate(m_shotPrefab, transform.position, transform.rotation) as GameObject;
            laser.GetComponent<ShotBehavior>().setTarget(hit.point);
            
            Enemy enemy = cast.transform.GetComponent<Enemy>();
            if(enemy != null){
                enemy.ReduceHealth(damage);
            }
        }

    }
}

// using System.Collections;

// public class PlayerShooting : MonoBehaviour
// {
//     public float shootRate;
//     private float m_shootRateTimeStamp;

//     public GameObject m_shotPrefab;

//     RaycastHit hit;
//     float range = 1000.0f;


//     void Update()
//     {

//         if (Input.GetMouseButton(0))
//         {
//             if (Time.time > m_shootRateTimeStamp)
//             {
//                 shootRay();
//                 m_shootRateTimeStamp = Time.time + shootRate;
//             }
//         }

//     }

//     void shootRay()
//     {
//         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//         if (Physics.Raycast(ray, out hit, range))
//         {
//             GameObject laser = GameObject.Instantiate(m_shotPrefab, transform.position, transform.rotation) as GameObject;
//             laser.GetComponent<ShotBehavior>().setTarget(hit.point);
//             GameObject.Destroy(laser, 2f);


//         }

//     }



// }