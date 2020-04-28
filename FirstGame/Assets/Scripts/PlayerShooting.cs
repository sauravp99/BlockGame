using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {
    
    public float damage = 10f;
    public float range = 100f;
    public Transform shootingPoint;
    public float shootRate;
    public GameObject m_shotPrefab;
    
    // Update is called once per frame
    void FixedUpdate() {
        
        if (Input.GetButtonDown("Fire1")) {
            RaycastHit cast; // Cast a raybeam 
            
            Vector3 forward = shootingPoint.TransformDirection(Vector3.forward) * 30;
            Debug.DrawRay(shootingPoint.position, forward, Color.green);
            
            if (Physics.Raycast(shootingPoint.position + new Vector3(0,2.5f,0),shootingPoint.forward,out cast, range)) {
                Debug.Log(cast.transform.name);
                
                StartCoroutine(ShootLaser(cast));
        }
    }

    IEnumerator ShootLaser(RaycastHit hit) {
        
            //Instantiate a bullet obj
            GameObject laser = GameObject.Instantiate(m_shotPrefab, transform.position, transform.rotation) as GameObject;
            laser.tag = "Bullet";
            laser.GetComponent<ShotBehavior>().setTarget(hit.point);
            
            Enemy enemy = hit.transform.GetComponent<Enemy>();

            if (enemy != null) {

                enemy.ReduceHealth(damage);

            }
            
            yield return new WaitForSeconds(0.5f);
            Destroy(laser);
        }
    }
}